using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            string msisdn = controllerDefault.UserManager == null ? "" : controllerDefault.UserManager.Data.Msisdn;
            int userId = controllerDefault.UserManager == null ? 0 : controllerDefault.UserManager.Data.Id;
            string userFbId = controllerDefault.UserManager == null ? "" : controllerDefault.UserManager.Data.FbId;

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