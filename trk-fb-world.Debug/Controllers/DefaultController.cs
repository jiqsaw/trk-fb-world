using Facebook;
using Microsoft.AspNet.Mvc.Facebook;
using MvcHelper.Facebook.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TurkcellFacebookDunyasi.App.App_Manager;
using TurkcellFacebookDunyasi.App.Filters;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    
    public class DefaultController : BaseController
    {
        public ActionResult Default()
        {
            return RedirectToAction("Default", "Start");
        }
    }
}
