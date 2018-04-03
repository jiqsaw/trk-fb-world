using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    public class GlobalController : Controller
    {
        public PartialViewResult LoadingSmall()
        {
            return PartialView();
        }

        public PartialViewResult PartialError()
        {
            return PartialView();
        }

        public PartialViewResult TermsOfUse()
        {
            return PartialView();
        }
    }
}
