using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.Admin.App_Manager;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core.CustomModels;

namespace TurkcellFacebookDunyasi.Admin.Filters
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {

                if (!SessionManager.GetInstance().IsLogin)
                    new RedirectResult("~/Login").ExecuteResult(filterContext);
                    /*
                else
                {
                    string currentPath = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
                    bool hasAccess = false;
                    foreach (PanelMenuModel model in SessionManager.GetInstance().Permissions.ToList())
                    {
                        if (model.AdminPath == currentPath)
                        {
                            hasAccess = true;
                            break;
                        }
                    }
                    if (!hasAccess)
                    {
                        new RedirectResult("~/Default").ExecuteResult(filterContext);
                    }
                }
                     */
            }
        }
         
    }
}