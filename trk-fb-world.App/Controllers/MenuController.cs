using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Filters;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class MenuController : BaseController
    {
        public PartialViewResult Top()
        {
            return PartialView();
        }

        public PartialViewResult BigModul()
        {
            return PartialView();
        }

    }
}
