using Microsoft.AspNet.Mvc.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TurkcellFacebookDunyasi.App.App_Manager;

namespace TurkcellFacebookDunyasi.App.Filters
{
    public class FbAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!SessionManager.GetInstance().IsFbLogin)
            {
                HttpContext.Current.Response.Redirect("~/Login/LogOut");
            }
        }
         
    }
}