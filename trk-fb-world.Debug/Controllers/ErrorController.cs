using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public PartialViewResult Internal()
        {
            return PartialView();
        }

        public ActionResult AppOffline() { return View(); }

    }
}
