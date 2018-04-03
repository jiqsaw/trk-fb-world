using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TurkcellFacebookDunyasi.App.App_Manager;
using TurkcellFacebookDunyasi.Com;

namespace TurkcellFacebookDunyasi.App.Filters
{
    public class SSOAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!SessionManager.GetInstance().IsSsoLogin)
            {
                //if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                //    HttpContext.Current.Response.Redirect(ConfigManager.GetInstance().TimeOutPath);
                filterContext.Result = new RedirectResult(ConfigManager.GetInstance().TimeOutPath);
            }
            else
            {
                if (WebServiceDefinitions.Platform != WebServiceDefinitions.PlatformCode.Static)
                {
                    //Sessionda tutulan msisdn ile server header bilgisindeki msisdn eşleşmiyorsa çıkışa yönlendir
                    var ssoHeaders = System.Web.HttpContext.Current.Request.Headers;
                    var headerMsisdn = ssoHeaders["TCELL-UID"] == null ? String.Empty : ssoHeaders["TCELL-UID"].ToString();
                    string sessMsisdn = (new UserFbManager()).Data.Msisdn;

                    if (sessMsisdn != headerMsisdn)
                        //if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                        //    HttpContext.Current.Response.Redirect(ConfigManager.GetInstance().TimeOutPath);
                        filterContext.Result = new RedirectResult(ConfigManager.GetInstance().TimeOutPath);
                }
            }
        }
         
    }
}