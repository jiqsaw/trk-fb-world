using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.App_Manager;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using LIB;
using LIB.ExtentionMethods;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.App.Filters;
using Microsoft.AspNet.Mvc.Facebook;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    public class BaseController : Controller
    {        
        protected SessionManager session { get { return SessionManager.GetInstance(); } }

        protected ConfigManager config { get { return ConfigManager.GetInstance(); } }

        private UserFbManager _userManager;

        public UserFbManager UserManager
        {
            get
            {
                return _userManager;
            }
        }

        protected ActionResult PartialResultSuccess(string Message)
        {
            return PartialView("Result", new ResultModel
                {
                    Type = ResultModel.ResultType.success,
                    Message = (string)HttpContext.GetGlobalResourceObject("Global", Message)
                });
        }

        protected ActionResult PartialResultSuccess(string Message, int MessageType)
        {
            return PartialView("Result", new ResultModel
            {
                Type = ResultModel.ResultType.success,
                Message = Message
            });
        }

        protected ActionResult PartialResultError()
        {
            return PartialView("Result", new ResultModel
                {
                    Type = ResultModel.ResultType.error,
                    Message = (string)HttpContext.GetGlobalResourceObject("Global", "Error")
                });
        }

        protected ActionResult PartialResultError(string Message)
        {
            return PartialView("Result", new ResultModel
            {
                Type = ResultModel.ResultType.error,
                Message = (string)HttpContext.GetGlobalResourceObject("Global", Message)
            });
        }

        protected ActionResult PartialResultError(string Message, int MessageType)
        {
            return PartialView("Result", new ResultModel
            {
                Type = ResultModel.ResultType.error,
                Message = Message
            });
        }

        protected UserFbManager UserFb
        {
            get
            {
                if (_userManager == null)
                {
                    _userManager = new UserFbManager();
                }

                return _userManager;
            }
        } //UserFbManager.GetInstance(); } }

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