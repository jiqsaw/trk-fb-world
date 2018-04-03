using System;
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
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.ServiceManager.Models.Partials;
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class SmsGonderController : BaseController
    {
        private readonly IUserSmsRepository repository;
        private readonly UserSmsService service;

        public SmsGonderController(IUserSmsRepository repository, UserSmsService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public PartialViewResult Default(string u)
        {
            if (u != null)
            {
                var friend = UserFb.Friends.Where(f => f.UserId == Convert.ToInt32(u)).FirstOrDefault();
                ViewBag.userId = friend.UserId;
                ViewBag.fbId = friend.FbId;
                ViewBag.firstName = friend.FirstNameView;
                ViewBag.lastName = friend.LastNameView;
                ViewBag.pictureLink = friend.PictureLink;
                ViewBag.msisdn = friend.Msisdn;
            }
            return PartialView();
        }

        public PartialViewResult RemainingBalance()
        {
            try
            {
                WebSmsModel model = new WebSmsModel();
                WebSmsHandler handler = new WebSmsHandler();
                model.serviceData = handler.PrepareData(UserFb.Data.Msisdn);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView();
            }
        }

        [HttpPost]
        public ActionResult Default(UserSms entity, string ToIds, string ToMsisdns)
        {
            try
            {
                WebSmsModel model = new WebSmsModel();
                
                //WebSMS Servis Cagrisi.
                WebSmsHandler handler = new WebSmsHandler();
                string[] recipientMsisdns = ToMsisdns.Split(',');

                if (recipientMsisdns.Length > 1)
                {
                    //COKLU SMS GONDERIMI
                    model.serviceData = handler.PrepareData(UserFb.Data.Msisdn, recipientMsisdns, entity.Message);
                }
                else
                {
                    //TEK KISIYE SMS GONDERIMI
                    model.serviceData = handler.PrepareData(UserFb.Data.Msisdn, recipientMsisdns[0], entity.Message);
                }

                if (model.serviceData.Error != null)
                {
                    //Eger servisten Error parametresi dolu gelmis ise zaten temel bir hata olusmustur
                    //bu sebepten hiçbir mesaj gönderilememistir. Dogrudan error gösterilebilir.
                    return PartialResultError("SentSMSError");

                }
                else
                {
                    //Error gelmedi ise, dönen result set içerisinde gönderim yapılan numaralar mutlaka var.
                    //bunlari arkadaslar ile join edip birlestiriyoruz.
                    var joinResult = (from u in model.serviceData.Recipients
                                      join p in UserFb.Friends on u.Msisdn equals p.Msisdn
                                      into a
                                      from f in a.DefaultIfEmpty(new UserFbFriendModel())
                                      select new SmsGonderResultModel
                                      {
                                          FbId = f.FbId,
                                          UserId = f.UserId,
                                          PictureLink = f.PictureLink,
                                          FirstNameView = f.FirstNameView,
                                          LastNameView = f.LastNameView,

                                          Msisdn = u.Msisdn,
                                          Charge = u.Charge,
                                          Status = u.Status
                                      }).ToList();

                    //Mesut Müdür, Bu joinResult senin view tarafında basacağın arkadaş eşleştirmeli sms gönderim sonuçlarını içeriyor.
                    //SmsGonderResultModel'i inceleyerek hangi alanların geldiğini görebilirsin.

                    ToIds = ToIds.Remove(0, 1);
                    ToIds = ToIds.Remove((int)ToIds.Length - 1, 1);
                    service.Add(UserFb.Data.Id, ToIds.Split(',').ToArray(), entity.CharNumber, entity.SMSFreeLimit, String.Empty, false);
                    //return PartialResultSuccess("RequestSuccess");

                    return PartialView("SmsResult", joinResult.ToList());
                    
                }
            }
            catch (Exception)
            {
                return PartialResultError("SentSMSError");
            }
        }

    }
}
