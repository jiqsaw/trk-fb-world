using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;

namespace TurkcellFacebookDunyasi.App.Controllers
{

    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class CallDetailsController : BaseController
    {
        //Postpaid ve prepaid hatlar icin
        public PartialViewResult TopCalledNumbers(string id)
        {
            var model = new EnCokArananArkadaslarModel();
            var handler = new CokArananNumaralarHandler();
            model.serviceData = id == null ? handler.PrepareData() : handler.PrepareData(id);

            //Birinci join, servisten gelen MSISDN ler icerisinde user'in arkadaslari olup
            //olmadigini joinliyor. Ayni msisdn birden fazla arkadas kaydina denk gelebilecegi
            //icin burada outer join yapiyoruz ve merge etmeden join edilmis kayitlari aliyoruz
            //ki duplicate kayit gelmesin.
            var friendsTableJoin = (from u in model.serviceData
                                    join p in UserFb.Friends on u.Msisdn equals p.Msisdn
                                    into a
                                    from f in a.DefaultIfEmpty(new UserFbFriendModel { Msisdn = u.Msisdn })
                                    select f).ToList();

            IList<EnCokArananlarMergeModel> mergeModel = (from u in friendsTableJoin
                                                          where u.IsClickToCallInvisible == false && u.IsClickToCallBlock == false
                                                          select new EnCokArananlarMergeModel
                                                          {
                                                              FbId = u.FbId,
                                                              FirstNameView = u.FirstName == null ? String.Empty : LIB.FormatHelper.NameCharLimit(u.FirstName.ToString(), GlobalVars.NameCharLimit, GlobalVars.NameExtChars),
                                                              LastNameView = u.LastName == null ? String.Empty : LIB.FormatHelper.NameCharLimit(u.LastName.ToString(), GlobalVars.NameCharLimit, GlobalVars.NameExtChars),
                                                              Msisdn = u.Msisdn,
                                                              PictureLink = u.PictureLink,
                                                              UserId = u.UserId,
                                                              IsClickToCallBlock = u.IsClickToCallBlock,
                                                              IsClickToCallInvisible = u.IsClickToCallInvisible
                                                          }).Take(4).ToList();

            return PartialView(mergeModel);
        }

        public PartialViewResult CallDetail(string Id)
        {
            FaturalarimModel model = new FaturalarimModel();

            FaturalarimHandler srvHandler = new FaturalarimHandler();
            model.serviceDataList = srvHandler.GetBillDatas(UserFb.Data.Msisdn);

            ViewBag.ActiveMonthIndex = Id;

            return PartialView(model);
        }

        public PartialViewResult FriendCallDetail(int dateRangeId, string userId)
        {
            FaturalarimModel model = new FaturalarimModel();

            FaturalarimHandler srvHandler = new FaturalarimHandler();
            model.serviceDataList = srvHandler.GetBillDatas(UserFb.Data.Msisdn);

            ViewBag.ActiveMonthIndex = dateRangeId;
            ViewBag.FriendFbId = userId;

            return PartialView(model);
        }

        public PartialViewResult FriendCallDetailPosp(string Period, string userId)
        {
            FaturalarimModel model = new FaturalarimModel();

            FaturalarimHandler srvHandler = new FaturalarimHandler();
            model.serviceDataList = srvHandler.GetBillDatas(UserFb.Data.Msisdn);

            ViewBag.Period = Period;
            ViewBag.FriendFbId = userId;

            return PartialView("FriendCallDetail",model);
        }

        public JsonResult GetCallDetails([DataSourceRequest] DataSourceRequest request, string Period)
        {
            ServiceManager.ServiceHandlers.CallDetailHandler srvHandler = new CallDetailHandler();

            var srvData = srvHandler.PrepareData(Period);

            IList<CallDetailModel> modelList = (from u in srvData
                                                join p in UserFb.Friends on LIB.StringHelper.Right(u.OpAddress.TrimEnd(), 10) equals p.Msisdn
                                                into a
                                                from f in a.DefaultIfEmpty(new UserFbFriendModel())
                                                select new CallDetailModel
                                                {
                                                    Amount = u.Amount,
                                                    DataVolume = u.DataVolume,
                                                    DateDisplay = u.DateDisplay,
                                                    Description = u.Description,
                                                    OpAddress = ProjectUtil.CallDetailOpAddres(u.OpAddress),

                                                    PictureLink = f.PictureLink,
                                                    UserId = f.UserId,
                                                    FbId = f.FbId,
                                                    FirstNameView = f.FirstNameView,
                                                    IsClickToCallBlock = f.IsClickToCallBlock,
                                                    IsClickToCallInvisible = f.IsClickToCallInvisible,
                                                    LastNameView = f.LastNameView,

                                                }).ToList();

            return Json(modelList.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPrepCallDetails([DataSourceRequest] DataSourceRequest request, string id)
        {
            IList<DateTime> dateRange = CallDetailsModel.GetDateRange();
            int startDateIndex = Convert.ToInt32(id);
            string startDate = String.Format("{0:dd'/'MM'/'yyyy}", dateRange[startDateIndex + 1]);
            string endDate = String.Format("{0:dd'/'MM'/'yyyy}", dateRange[startDateIndex]);

            ServiceManager.ServiceHandlers.CallDetailHandler srvHandler = new CallDetailHandler();
            var srvData = srvHandler.PrepareData(startDate, endDate);

            IList<CallDetailModel> modelList = (from u in srvData
                                                join p in UserFb.Friends on LIB.StringHelper.Right(u.OpAddress.TrimEnd(), 10) equals p.Msisdn
                                                into a
                                                from f in a.DefaultIfEmpty(new UserFbFriendModel())
                                                select new CallDetailModel
                                                {
                                                    Amount = u.Amount,
                                                    DataVolume = u.DataVolume,
                                                    DateDisplay = u.DateDisplay,
                                                    Description = u.Description,
                                                    OpAddress = ProjectUtil.CallDetailOpAddres(u.OpAddress),

                                                    PictureLink = f.PictureLink,
                                                    UserId = f.UserId,
                                                    FbId = f.FbId,
                                                    FirstNameView = f.FirstNameView,
                                                    IsClickToCallBlock = f.IsClickToCallBlock,
                                                    IsClickToCallInvisible = f.IsClickToCallInvisible,
                                                    LastNameView = f.LastNameView,

                                                }).ToList();

            return Json(modelList.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFriendCallDetailsPosp([DataSourceRequest] DataSourceRequest request, string Period, string friendFbId)
        {
            ServiceManager.ServiceHandlers.CallDetailHandler srvHandler = new CallDetailHandler();

            var srvData = srvHandler.PrepareData(Period);

            IList<CallDetailModel> modelList = (from u in srvData
                                                join p in UserFb.Friends on LIB.StringHelper.Right(u.OpAddress.TrimEnd(), 10) equals p.Msisdn
                                                into a
                                                from f in a.DefaultIfEmpty(new UserFbFriendModel())
                                                select new CallDetailModel
                                                {
                                                    Amount = u.Amount,
                                                    DataVolume = u.DataVolume,
                                                    DateDisplay = u.DateDisplay,
                                                    Description = u.Description,
                                                    OpAddress = ProjectUtil.CallDetailOpAddres(u.OpAddress),

                                                    PictureLink = f.PictureLink,
                                                    UserId = f.UserId,
                                                    FbId = f.FbId,
                                                    FirstNameView = f.FirstNameView,
                                                    IsClickToCallBlock = f.IsClickToCallBlock,
                                                    IsClickToCallInvisible = f.IsClickToCallInvisible,
                                                    LastNameView = f.LastNameView,

                                                })
                                                .Where(f => f.FbId == friendFbId)
                                                .ToList();

            return Json(modelList.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFriendCallDetailsPrep([DataSourceRequest] DataSourceRequest request, int dateIndex, string friendFbId)
        {
            IList<DateTime> dateRange = CallDetailsModel.GetDateRange();
            string startDate = String.Format("{0:dd'/'MM'/'yyyy}", dateRange[dateIndex + 1]);
            string endDate = String.Format("{0:dd'/'MM'/'yyyy}", dateRange[dateIndex]);

            ServiceManager.ServiceHandlers.CallDetailHandler srvHandler = new CallDetailHandler();
            var srvData = srvHandler.PrepareData(startDate, endDate);

            IList<CallDetailModel>modelList = (from u in srvData
                                               join p in UserFb.Friends on LIB.StringHelper.Right(u.OpAddress.TrimEnd(), 10) equals p.Msisdn
                                               into a
                                               from f in a.DefaultIfEmpty(new UserFbFriendModel())
                                               select new CallDetailModel
                                               {
                                                   Amount = u.Amount,
                                                   DataVolume = u.DataVolume,
                                                   DateDisplay = u.DateDisplay,
                                                   Description = u.Description,
                                                   OpAddress = ProjectUtil.CallDetailOpAddres(u.OpAddress),

                                                   PictureLink = f.PictureLink,
                                                   UserId = f.UserId,
                                                   FbId = f.FbId,
                                                   FirstNameView = f.FirstNameView,
                                                   IsClickToCallBlock = f.IsClickToCallBlock,
                                                   IsClickToCallInvisible = f.IsClickToCallInvisible,
                                                   LastNameView = f.LastNameView,
                                                })
                                                .Where(f => f.FbId == friendFbId)
                                                .ToList();
            return Json(modelList.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}