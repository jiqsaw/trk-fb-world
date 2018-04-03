using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.App_Manager;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.Services;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class WorldController : BaseController
    {
        private readonly IUserSmsRepository repository;
        private readonly UserSmsService service;

        public WorldController(IUserSmsRepository repository, UserSmsService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public ActionResult Default()
        {                          
            return View();
        }

        public PartialViewResult Entry(int? Id)
        {
            ViewBag.MsisdnFbMatching = true;


            if (!session.IsLdapQueryDone)
            {
                try
                {
                    //LDAP servis cagrilari.
                    GetUpdatePersonHandler ldapHandler = new GetUpdatePersonHandler();
                    Msisdn2FbResponse ldapResponse = ldapHandler.GetPerson(UserFb.Data.Msisdn);

                    if (ldapResponse.Value == null)
                    {
                        //Eger girilen msisdn icin FbId tanimli degil ise, null donuyor. Bu noktada
                        //update user diyerek yeniden tanimlatiyoruz.
                        ldapHandler.UpdatePerson(UserFb.Data.Msisdn, UserFb.Data.FbId);
                    }
                    else
                    {
                        if (ldapResponse.Value != UserFb.Data.FbId)
                        {    
                            CookieManager cookie = new CookieManager();
                            if (cookie.Read(CookieManager.CookieType.ShowFbMsisdnMatching) == String.Empty)
                            {
                                ViewBag.MsisdnFbMatching = false;
                                cookie.Write(CookieManager.CookieType.ShowFbMsisdnMatching, UserFb.Data.FbId + "" + UserFb.Data.Msisdn);
                            }
                            else if (cookie.Read(CookieManager.CookieType.ShowFbMsisdnMatching) != UserFb.Data.FbId + "" + UserFb.Data.Msisdn)
                            {
                                ViewBag.MsisdnFbMatching = false;
                                cookie.Delete(CookieManager.CookieType.ShowFbMsisdnMatching);
                                cookie.Write(CookieManager.CookieType.ShowFbMsisdnMatching, UserFb.Data.FbId + "" + UserFb.Data.Msisdn);
                            }
                        }
                    }

                    session.IsLdapQueryDone = true;
                }
                catch(Exception) { }
            }

            return PartialView();
        }

        public PartialViewResult Birthday()
        {
            var model = new BirthDayFriendsModel();
            model.BirthdayFriends = UserFb.TodayBornFriends;
            model.UpcomingBirthdayFriends = UserFb.UpcomingBirthdayFriends;

            if (model.BirthdayFriends.Count == 0)
            {
                ViewBag.Title = "DOĞUM GÜNÜ YAKLAŞAN ARKADAŞLARIM";
                ViewBag.Display = "block";
            }
            else
            {
                ViewBag.Display = "none";
                ViewBag.Title = "BUGÜN DOĞAN ARKADAŞLARIM";
            }

            return PartialView(model);
        }

        public JsonResult BirthdaySmsSent(string ToId, string Message)
        {
            try
            {
                bool ServiceRequestStatus = true;

                WebSmsModel model = new WebSmsModel();
                
                //WebSMS Servis Cagrisi.
                WebSmsHandler handler = new WebSmsHandler();
                string recipientMsisdns = ToId;

                //TEK KISIYE SMS GONDERIMI
                model.serviceData = handler.PrepareData(UserFb.Data.Msisdn, recipientMsisdns, Message);

                if (model.serviceData.Error != null)
                {
                    //Eger servisten Error parametresi dolu gelmis ise zaten temel bir hata olusmustur
                    //bu sebepten hiçbir mesaj gönderilememistir. Dogrudan error gösterilebilir.
                    ServiceRequestStatus = false;

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
                }

                if (ServiceRequestStatus == true)
                {
                    service.Add(UserFb.Data.Id, ToId, 0, 0, Message, true);
                }
                else { ToId = "0"; }
            }
            catch { ToId = "0"; }

            return Json(new { ToId = ToId }, JsonRequestBehavior.AllowGet);
        }
    }
}
