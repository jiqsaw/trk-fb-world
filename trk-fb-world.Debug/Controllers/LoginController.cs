using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Mvc.Facebook;
using Microsoft.AspNet.Mvc.Facebook.Client;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.App.Controllers;
using TurkcellFacebookDunyasi.App.App_Manager;
using System;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Services;
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.Com.Helpers;
using TurkcellFacebookDunyasi.Logger;
using System.Configuration;
using TurkcellFacebookDunyasi.Com;


namespace TurkcellFacebookDunyasi.App.Controllers
{
    public class LoginController : BaseController
    {
        private readonly UserFbService UserService;
        public LoginController(UserFbService UserService)
        {
            this.UserService = UserService;
        }

        [ActionLog]
        public ActionResult SsoResult()
        {
            string userMsisdn;

            if ((WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static) || (config.ByPassLogin))
                userMsisdn = config.ByPassLoginMsisdn;
            else
            {
                var ssoHeaders = System.Web.HttpContext.Current.Request.Headers;
                userMsisdn = ssoHeaders["TCELL-UID"] == null ? String.Empty : ssoHeaders["TCELL-UID"].ToString();                

                if (userMsisdn == String.Empty)
                    return RedirectToAction("AppOffline", "Error");
            }

            try
            {
                SsoLoginHandler handler = new SsoLoginHandler();
                var ssoLoginData = handler.PrepareData(userMsisdn);

                //Kurumsal Kullanıcı ise
                if (ssoLoginData.CustomerType != Parameter.CustomerType.flat.ToString())
                    return RedirectToAction("CorporateCustomerError");

                session.IsSsoLogin = true;
                UserFb.Data.UserType = (int)Enum.Parse(typeof(Parameter.UserType), ssoLoginData.CustomerPaymentType);
                UserFb.Data.Msisdn = ssoLoginData.CustomerMsisdn;

                //FbLogin isleminden sonra msisdn sessiondaki nesneye atilmamisti.
                //FormatHelper'in exception firlatmamasi icin msisdn eklendikten sonra
                //sessiondaki nesneyi güncelliyoruz.
                UserFb.UpdateSession();

                //Herhangi bir handler'in bu propertyleri static loader'in ilgili
                //propertylerini set ettigi icin dispose olmasindan korkmaya gerek yok.
                handler.PageToken = ssoLoginData.SessionToken;
                handler.TcellSession = ssoLoginData.Sid;
                
                session.PageToken = ssoLoginData.SessionToken;
                session.TurkcellSessionId = ssoLoginData.Sid;

                UserService.Update(UserFb.Data);
            }
            catch (Exception)
            {
                return RedirectToAction("AppOffline", "Error");
            }

            return View();
        }

        [ActionLog]
        public JsonResult LdapUpdate()
        {
            try
            {
                GetUpdatePersonHandler ldapHandler = new GetUpdatePersonHandler();
                ldapHandler.UpdatePerson(UserFb.Data.Msisdn, UserFb.Data.FbId);

                return Json(new { result = "1" }, "text/plain", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { result = "0" }, "text/plain", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CorporateCustomerError()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            session.Destroy();
            string ssoLogoutUrl = Com.Helpers.UrlHelper.SsoLogout + Com.Helpers.UrlHelper.UrlWeb + "/Login/SsoLogoutRedirect";
            return new RedirectResult(ssoLogoutUrl, true);
        }

        public ActionResult SsoLogoutRedirect()
        {
            ViewBag.PageTabUrl = ConfigurationManager.AppSettings["Facebook_PageAppTabUrl"].ToString();
            return View("LogOut");
        }

        public ActionResult TimeOut() {
            return View();
        }

        [FbAuthorize]
        public PartialViewResult Default(FacebookContext context)
        {
            LoginModel model = new LoginModel();
            return PartialView(model);
        }

    }
}
