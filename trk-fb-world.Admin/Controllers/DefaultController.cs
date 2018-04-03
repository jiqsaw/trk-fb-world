using TurkcellFacebookDunyasi.Admin.App_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.Admin.Controllers
{
    public class DefaultController : BaseAuthorizedController
    {

        public ActionResult Default()
        {
            ViewBag.UserName = session.Username;
            return View();
        }

    }
}
