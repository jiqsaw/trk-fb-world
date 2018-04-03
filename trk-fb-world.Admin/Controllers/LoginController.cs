using System.Web.Mvc;
using TurkcellFacebookDunyasi.Admin.App_Manager;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Services;
using LIB.ExtentionMethods;
using System.Collections.Generic;
using TurkcellFacebookDunyasi.Admin.Models;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Admin.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IAdminRepository repository;
        private readonly AdminService service;
        private readonly AdminAuthService adminAuthService;
        private readonly ModulService modulService;

        public LoginController(IAdminRepository repository, AdminService service, AdminAuthService adminAuthService, ModulService modulService)
        {
            this.repository = repository;
            this.service = service;
            this.adminAuthService = adminAuthService;
            this.modulService = modulService;
        }

        public ActionResult Default()
        {
           if (config.AutoLogin) return AutoLogin();

            return HasCookie() ? ViewMain() : View();
        }

        [HttpPost]
        public ActionResult Default(TurkcellFacebookDunyasi.Core.Admin entity)
        {
            TurkcellFacebookDunyasi.Core.Admin _admin = service.Auth(entity);
            if (_admin != null)
            {
                Logon(_admin);
                return ViewMain();
            }
            ViewBag.LoginFailed = true;
            return View();
        }

        public ActionResult Exit()
        {
            session.Destroy();
            CookieManager Cookie = new CookieManager();
            Cookie.Delete(CookieManager.CookieType.AdminId);
            return RedirectToAction("Default");            
        }


        #region Private
        private ActionResult AutoLogin()
        {
            TurkcellFacebookDunyasi.Core.Admin _admin = repository.GetById(config.AdminId);            
            Logon(_admin);
            return ViewMain();
        }     

        private void Logon(Core.Admin entity)
        {
            FillSession(entity);
            if (entity.RememberMe)
                SetCookie();
        }

        private void SetCookie()
        {
            CookieManager cookie = new CookieManager();
            cookie.Write(CookieManager.CookieType.AdminId, session.AdminId);
        }

        private void FillSession(TurkcellFacebookDunyasi.Core.Admin entity)
        {
            session.IsLogin = true;
            session.AdminId = entity.Id;
            session.Username = entity.Username;
            session.FirstName = entity.FirstName;
            session.LastName = entity.LastName;
            session.UserPhoto = entity.FileName;
            session.FullAuth = entity.FullAuth;

            SetStatics();

            List<Core.CustomModels.PanelMenuModel> listPanelMenuModel = 
                (entity.FullAuth) ?
                modulService.GetPanelMenuList() :
                modulService.GetAdminPermissions(entity.Id);

            session.Permissions = listPanelMenuModel;
        }

        private void SetStatics()
        {
            GlobalVars.CurrAdminId = session.AdminId;
        }

        private bool HasCookie()
        {
            CookieManager Cookie = new CookieManager();
            int AdminId;
            if (int.TryParse(Cookie.Read(CookieManager.CookieType.AdminId), out AdminId))
            {
                Core.Admin entity = repository.GetById(AdminId);
                FillSession(entity);
                SetCookie();
                return true;
            }
            return false;
        }
        #endregion        

    }
}