using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Controllers;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Logger;

namespace TurkcellFacebookDunyasi.App.Filters
{
    public class HandleExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {

            var controller = (BaseController)filterContext.Controller;
            var sessionUser = controller.UserManager;

            var sessionData = HttpContext.Current.Session["TurkcellSessionId"];
            string TurkcellSession = sessionData == null ? null : sessionData.ToString();

            string msisdn = sessionUser == null ? null : sessionUser.Data.Msisdn;
            string fbId = sessionUser == null ? null : sessionUser.Data.FbId;
            int userId = sessionUser == null ? 0 : sessionUser.Data.Id;

            var controllerName = (string) filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            LogService logger = LogService.GetInstance();
            TransactionLog log = new TransactionLog();
            log.Status = LogService.LogStatus.Failure.ToString();
            log.Naming = LogService.LogDefinitions.Exception.ToString();
            log.IP = HttpContext.Current.Request.UserHostAddress;
            log.Msisdn = msisdn;
            log.FbId = fbId;
            log.Msisdn = msisdn;
            log.TcellSession = TurkcellSession;
            log.Details = controllerName + "::" + actionName + "::" + filterContext.Exception.Message;
            logger.Log<TransactionLog>(log);

            var result = CreateActionResult(filterContext, (int)HttpStatusCode.InternalServerError);
            filterContext.Result = result;
            
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            //base.OnException(filterContext);
        }

        protected virtual ActionResult CreateActionResult(ExceptionContext filterContext, int statusCode)
        {
            var ctx = new ControllerContext(filterContext.RequestContext, filterContext.Controller);
            var statusCodeName = ((HttpStatusCode)statusCode).ToString();

            var viewName = "~/Views/Error/AppOffline.cshtml";
            var controllerName = (string) filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception,controllerName,actionName);
            var result = new ViewResult
            {
                ViewName = viewName,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
            };
            result.ViewBag.StatusCode = statusCode;
            return result;
        }
    }
}