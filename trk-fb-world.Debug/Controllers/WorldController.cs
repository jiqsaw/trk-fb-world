using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                            ViewBag.MsisdnFbMatching = false;
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
                ViewBag.Title = "DOĞUM GÜNÜ YAKLAŞANLAR";
                ViewBag.Display = "block";
            }
            else
            {
                ViewBag.Display = "none";
                ViewBag.Title = "BUGÜN DOĞAN ARKADAŞLARIN";
            }

            return PartialView(model);
        }

        public JsonResult BirthdaySmsSent(string ToId)
        {
            try
            {
                bool ServiceRequestStatus = true;
                //TODO: Burada "SMS GÖNDERME SERVİSİ" çağırılacak.
                if (ServiceRequestStatus == true)
                {
                    service.Add(UserFb.Data.Id, ToId, 0, 0, "", true);
                }
                else { ToId = "0"; }
            }
            catch { ToId = "0"; }

            return Json(new { ToId = ToId }, JsonRequestBehavior.AllowGet);
        }
    }
}
