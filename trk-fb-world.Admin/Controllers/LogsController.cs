using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.Services;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Web.Mvc;
using System.Linq;


namespace TurkcellFacebookDunyasi.Admin.Controllers
{
    public class LogsController : BaseAuthorizedController
    {
        //
        // GET: /Logs/


        private readonly IWebServiceLogRepository repository;
        private readonly WebServiceLogService service;
        private readonly IWebServiceRepository repositoryWebService;


        public LogsController(IWebServiceLogRepository repository, WebServiceLogService service, IWebServiceRepository repositoryWebService)
        {
            this.repository = repository;
            this.service = service;
            this.repositoryWebService = repositoryWebService;
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(repository.GetLiveWebServiceLog().ToDataSourceResult(request));
        }

        public JsonResult GetNamings()
        {
            return Json(repositoryWebService.GetAll().Where(s => s.PlatformCode == 1).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Form(int? Id)
        {
            if (Id != null)
            {
                var modelData = repository.GetById(Id.Value);
                return View(modelData);
            }

            return View();
        }

    }
}
