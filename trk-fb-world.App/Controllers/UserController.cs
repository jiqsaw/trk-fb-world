using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using TurkcellFacebookDunyasi.App.Filters;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class UserController : BaseController
    {
        public JsonResult GetAllFriends([DataSourceRequest] DataSourceRequest request)
        {
            return Json(UserFb.Friends.ToList().OrderByDescending(p => p.HasApp).ThenBy(p => p.FirstName).ThenBy(p => p.LastName), JsonRequestBehavior.AllowGet);
        }

    }
}