using TurkcellFacebookDunyasi.Admin.Controllers;
using TurkcellFacebookDunyasi.Admin.Models;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.CustomModels;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.Modul.Controllers
{
    public class ModulController : BaseController
    {
        private readonly ModulService service;

        public ModulController(ModulService service)
        {
            this.service = service;
        }

        public ActionResult Default(IEnumerable<AdminAuth> AdminAuths = null)
        {
            if (AdminAuths != null)
                ViewBag.AdminAuths = AdminAuths;

            return PartialView(service.GetListForAdmin());
        }


        public ActionResult PanelMenu()
        {
            return PartialView(session.Permissions);
        }

        public ActionResult PanelMenuGroup(string groupDesc, Parameter.AdminModulGroup AdminModulGroupEn, Parameter.AdminModulGroup AdminModulGroupTr)
        {
            PanelMenuGroupModel model = new PanelMenuGroupModel();
            model.GroupDescription = groupDesc;
            model.List = session.Permissions.Where(a => (a.ParentId == (int)AdminModulGroupEn || a.ParentId == (int)AdminModulGroupTr) && a.LanguageCode == GlobalVars.LanguageCode).ToList();
            return PartialView(model);
        }
    }
}