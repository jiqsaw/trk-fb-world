using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.Admin.App_Manager;
using TurkcellFacebookDunyasi.Admin.Models;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using LIB;
using LIB.ExtentionMethods;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.EF;

namespace TurkcellFacebookDunyasi.Admin.Controllers
{
    public class BaseController : Controller
    {        
        protected SessionManager session { get { return SessionManager.GetInstance(); } }

        protected ConfigManager config { get { return ConfigManager.GetInstance(); } }

        protected ActionResult PartialResultSuccess()
        {
            return PartialView("Common/Result", 
                new ResultModel { 
                    Type = ResultModel.ResultType.success, 
                    Message = (string)HttpContext.GetGlobalResourceObject("Notices", "Success") 
                });
        }

        protected ActionResult PartialResultError()
        {
            return PartialView("Common/Result",
                new ResultModel
                {
                    Type = ResultModel.ResultType.error,
                    Message = (string)HttpContext.GetGlobalResourceObject("Notices", "Error")
                });
        }

        protected ActionResult ViewMain() {
            return RedirectToAction("Default", "Default");
        }

        protected ActionResult ViewLogin()
        {            
            return RedirectToAction("Default", "Login");
        }
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }

    }
}