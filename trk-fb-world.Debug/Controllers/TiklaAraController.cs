using Kendo.Mvc.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.App_Manager;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.Services;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class TiklaAraController : BaseController
    {
        private readonly ClickToCallPreferenceService servicePreference;
        private readonly IClickToCallRepository repClickToCall;
        private readonly ClickToCallUserBlockService servClickToCallUserBlock;
        private readonly ClickToCallFreeService servClickToCallFree;

        public TiklaAraController(ClickToCallPreferenceService servicePreference, IClickToCallRepository repClickToCall, ClickToCallUserBlockService servClickToCallUserBlock, ClickToCallFreeService srvClickToCallFree)
        {
            this.servicePreference = servicePreference;
            this.repClickToCall = repClickToCall;
            this.servClickToCallUserBlock = servClickToCallUserBlock;
            this.servClickToCallFree = srvClickToCallFree;
        }

        public PartialViewResult Default()
        {
            TiklaAraModel model = new TiklaAraModel(); 
            return PartialView(model);
        }

        public PartialViewResult Call(int Id)
        {
            CallModel model = new CallModel();

            model.IsAvailable = servicePreference.IsAvailable(Id);
            model.FriendData = UserFb.Friends.Where(p => p.UserId == Id).SingleOrDefault();

            ServiceManager.ServiceHandlers.TiklaAraHandler srvTiklaAra = new ServiceManager.ServiceHandlers.TiklaAraHandler();
            model.RemainingBalance = srvTiklaAra.GetRemainingBalance(UserFb.Data.Msisdn);

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult CallStart(int FriendUserId)
        {
            bool IsBirthdayCall = UserFb.TodayBornFriends.Any(f => f.UserId == FriendUserId);
            bool HadFreeCall = servClickToCallFree.HadFreeCallWith(UserFb.Data.Id, FriendUserId);
            bool IsFreeCall = (IsBirthdayCall && HadFreeCall != true);

            //Yukaridaki iki alan, yapilan aramanin bir dogum günü aramasi olup olmadigini ve 
            //dogum gunu ise bile, bu kullanici ile son 1 yil icerisinde ücretsiz arama yapilip
            //yapilmadigini tutuyor. Sonrasi, TiklaAraHandler.StartCall cagrisina uygun sekilde
            //isFree = true ya da false gecirmeye kaliyor.

            try
            {
                string ParticipantAMsisdn = UserFb.Data.Msisdn;
                string ParticipantBMsisdn = UserFb.Friends.Where(p => p.UserId == FriendUserId).SingleOrDefault().Msisdn;

                ServiceManager.ServiceHandlers.TiklaAraHandler srvTiklaAra = new ServiceManager.ServiceHandlers.TiklaAraHandler();
                long CallId = srvTiklaAra.StartCall(ParticipantAMsisdn, ParticipantBMsisdn, IsFreeCall);

                //ClickToCallRepository'ye kayit dustukten sonra, eger gorusme ücretsiz yapildi ise
                //ClickToCallFreeRepository'ye de ayni kayit dusulmeli.
                if (IsFreeCall)
                {
                    var entClickToCallFree = new Core.ClickToCallFree
                    {
                        CallId = CallId,
                        ParticipantAUserId = UserFb.Data.Id,
                        ParticipantBUserId = FriendUserId,
                    };
                    servClickToCallFree.SaveAndCommit(entClickToCallFree);
                }

                var entClickToCall = new Core.ClickToCall();
                entClickToCall.CallId = CallId;
                entClickToCall.ParticipantAMsisdn = ParticipantAMsisdn;
                entClickToCall.ParticipantAUserId = UserFb.Data.Id;
                entClickToCall.ParticipantBMsisdn = ParticipantBMsisdn;
                entClickToCall.ParticipantBUserId = FriendUserId;

                repClickToCall.SaveAndCommit(entClickToCall);

                return Json(new { result = 1 });
            }
            catch (Exception)
            {
                return Json(new { result = 0 });
            }
        }

        public PartialViewResult HowItWorks() {
            return PartialView();
        }

        public PartialViewResult Preferences()
        {
            TiklaAraTercihlerModel model = new TiklaAraTercihlerModel();

            ServiceManager.ServiceHandlers.TiklaAraHandler srvTiklaAra = new ServiceManager.ServiceHandlers.TiklaAraHandler();
            model.RemainingBalance = srvTiklaAra.GetRemainingBalance(UserFb.Data.Msisdn);

            return PartialView(model);
        }


        public PartialViewResult PreferencesForm()
        {
            return PartialView(servicePreference.GetByUserId(UserFb.Data.Id));
        }

        [HttpPost]
        public PartialViewResult PreferencesForm(ClickToCallPreference entity)
        {
            servicePreference.Save(entity);

            return PartialView("Result",
                new ResultModel
                {
                    Type = ResultModel.ResultType.success
                });
        }


        public PartialViewResult UserBlocks()
        {            
            return PartialView();
        }

        [HttpPost]
        public JsonResult UserBlocks(string FriendIds)
        {           
            servClickToCallUserBlock.Add(UserFb.Data.Id, FriendIds.Split(',').ToArray());            
            return Json(new { result = "1" }, "text/plain");
        }

        [HttpPost]
        public JsonResult RemoveBlock(string FbId)
        {
            servClickToCallUserBlock.DeleteByFbId(UserFb.Data.Id, FbId);
            return Json(new { result = "1" }, "text/plain");
        }



        public PartialViewResult UserBlockList()
        {
            ClickToCallUserBlockListModel model = new ClickToCallUserBlockListModel();

            model.BlockListData = servClickToCallUserBlock.GetByUserId(UserFb.Data.Id);

            return PartialView(model);
        }


        public PartialViewResult Promote() {
            return PartialView();
        }

        public JsonResult PrmoteFriends()
        {
            bool HasClickToCallRecords = false;

            var PromotedClickToCalls = new List<Core.ClickToCallPromoteModel>();
            var ClickToCallPrmoteFriends = new List<ClickToCallFriendModel>();

            //SON ARAMA KAYITLARI
            var LastCalls = repClickToCall.LastCalls(UserFb.Data.Id).Take(6).ToList();

            if (LastCalls.Count() > 0)
            {
                HasClickToCallRecords = true;
                PromotedClickToCalls.AddRange(LastCalls);

                //SIK KONUŞTUKLARIN
                var frequentlyCalled = repClickToCall.FrequentlyCalled(UserFb.Data.Id).Take(6).ToList();
                PromotedClickToCalls.AddRange(frequentlyCalled);

                ClickToCallPrmoteFriends = PromotedClickToCalls.Join(UserFb.Friends,
                                                            p => p.FriendUserId,
                                                            l => l.UserId,
                                                            (l, p) => new ClickToCallFriendModel
                                                            {
                                                                UserId = l.FriendUserId,
                                                                FbId = p.FbId,
                                                                FirstNameView = p.FirstNameView,
                                                                LastNameView = p.LastNameView,
                                                                PictureLink = p.PictureLink,
                                                                IsClickToCallBlock = p.IsClickToCallBlock,
                                                                IsClickToCallInvisible = p.IsClickToCallInvisible,
                                                                PromoteType = l.PromoteType,
                                                            }).ToList();
            }
            
            //ARKADAŞ LİSTENDEN RANDOM 6 KİŞİYİ ClickToCallFriendModel e aktar
            var randomFriends = UserFb.Friends.Join(UserFb.Friends.Where(p => p.IsClickToCallInvisible == false && p.IsClickToCallBlock == false),
                                                        p => p.UserId,
                                                        l => l.UserId,
                                                        (l, p) => new ClickToCallFriendModel
                                                        {
                                                            UserId = l.UserId,
                                                            FbId = p.FbId,
                                                            FirstNameView = p.FirstNameView,
                                                            LastNameView = p.LastNameView,
                                                            PictureLink = p.PictureLink,
                                                            IsClickToCallBlock = p.IsClickToCallBlock,
                                                            IsClickToCallInvisible = p.IsClickToCallInvisible,
                                                            PromoteType = Core.ClickToCallPromoteModel.PromoteTypes.RandomFriends,
                                                        })
                                                        .AsEnumerable().OrderBy(en => Guid.NewGuid()).Take(6).ToList();

            ClickToCallPrmoteFriends.AddRange(randomFriends);

            return Json(new { clickToCallPrmoteFriends = ClickToCallPrmoteFriends, hasClickToCallRecords = HasClickToCallRecords }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult RemainingBalance()
        {
            //CallModel model = new CallModel();

            //ServiceManager.ServiceHandlers.TiklaAraHandler srvTiklaAra = new ServiceManager.ServiceHandlers.TiklaAraHandler();
            //model.RemainingBalance = srvTiklaAra.GetRemainingBalance(UserFb.Data.Msisdn);

            //return PartialView(model);
            return PartialView();
        }


        public PartialViewResult SingleUserBlock(string FriendFbId) {
            return PartialView();
        }

    }

    public class SelectedUserBlock {
        public string FbId { get; set; }
        public string Name { get; set; }
    }
}