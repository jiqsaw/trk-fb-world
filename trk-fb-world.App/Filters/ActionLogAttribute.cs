using LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.App_Manager;
using TurkcellFacebookDunyasi.App.Controllers;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Logger;

namespace TurkcellFacebookDunyasi.App.Filters
{
    public class ActionLogAttribute : ActionFilterAttribute
    {
        public string ActionDescription { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Bu attribute ile donatilmis her action,
            //kendi islemini kayit altina alir. TransactionLog olarak kayit eder.
            var IpAddress = HttpContext.Current.Request.UserHostAddress;
            var sessionData = HttpContext.Current.Session["TurkcellSessionId"];
            string TurkcellSession = sessionData == null ? null : sessionData.ToString();
            BaseController controllerDefault = (BaseController)filterContext.Controller;

            //SessionManager s = new SessionManager();
            UserFb userData = null;
            var sessionManager = SessionManager.GetInstance();
            var serializer = new Serialize();

            if (sessionManager.HasSessionUser)
            {
                //Sessionda user bilgileri var ise, bunlari deserilaze edip data'ya aktariyoruz.
                userData = (UserFb)serializer.DeserializeObject(sessionManager.SessionUser, typeof(UserFb));
            }

            string msisdn = userData == null ? "" : userData.Msisdn;
            int userId = userData == null ? 0 : userData.Id;
            string userFbId = userData == null ? "" : userData.FbId;


            TransactionLog log = new TransactionLog();
            log.Status = LogService.LogDefinitions.ActionCall.ToString();
            log.Naming = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "::" + filterContext.ActionDescriptor.ActionName;
            log.IP = IpAddress;
            log.Msisdn = msisdn;
            log.UserId = userId;
            log.FbId = userFbId;
            log.TcellSession = TurkcellSession;
            log.Details = ActionDescription;

            LogService logger = LogService.GetInstance();
            logger.Log<TransactionLog>(log);

            base.OnActionExecuting(filterContext);
        }
    }
}