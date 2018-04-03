using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TurkcellFacebookDunyasi.App.App_Manager;

namespace TurkcellFacebookDunyasi.App.Filters
{
    public class SSOAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!SessionManager.GetInstance().IsSsoLogin)
            {
                HttpContext.Current.Response.Redirect(ConfigManager.GetInstance().TimeOutPath);
            }
        }
         
    }
}