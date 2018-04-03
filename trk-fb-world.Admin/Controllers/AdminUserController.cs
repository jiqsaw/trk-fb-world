using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.Services;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Web.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace TurkcellFacebookDunyasi.Admin.Controllers
{
    public class AdminUserController : BaseAuthorizedController
    {
        private readonly IAdminRepository repository;
        private readonly AdminService service;
        private readonly AdminAuthService adminAuthService;

        public AdminUserController(IAdminRepository repository, AdminService service, AdminAuthService adminAuthService)
        {
            this.repository = repository;
            this.service = service;
            this.adminAuthService = adminAuthService;
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(repository.GetAll().ToDataSourceResult(request));
        }

        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, TurkcellFacebookDunyasi.Core.Admin item)
        {
            if (item != null)
                repository.DeleteAndCommit(item);

            return k_jRead(request);
        }


        public ActionResult UserSelfForm()
        {
            return View(repository.GetById(session.AdminId));
        }

        [HttpPost]
        public ActionResult UserSelfForm(TurkcellFacebookDunyasi.Core.Admin entity)
        {
            try
            {
                entity.Id = session.AdminId;
                repository.SaveAndCommit(entity);

                session.FirstName = entity.FirstName;
                session.LastName = entity.LastName;
                session.UserPhoto = entity.FileName;

                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }

        public ActionResult Form(int? Id)
        {
            if (Id != null)
            {
                ViewBag.AdminAuths = adminAuthService.GetByAdminId(Id.Value);
                return View(repository.GetById(Id.Value));
            }

            return View();
        }

        [HttpPost]
        public ActionResult Form(Core.Admin entity)
        {
            try
            {
                List<string> RequestValues = null;

                if (Request.Form["chAuth"] != null)
                    RequestValues = new List<string>(Request.Form["chAuth"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                
                service.SaveWithPermission(entity, adminAuthService, RequestValues);
                
                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }
    }
}