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
    public class FaqController : BaseAuthorizedController
    {
        private readonly IFaqRepository repository;
        private readonly FaqService service;

        public FaqController(IFaqRepository repository, FaqService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public ActionResult Default()
        {
            return View();
        }


        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(repository.GetAll().OrderBy(p => p.Title).ToDataSourceResult(request));
        }

        [ValidateInput(false)]
        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, Faq item)
        {
            if (item != null)
                repository.DeleteAndCommit(item);

            return k_jRead(request);
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Form(Faq entity)
        {
            try
            {
                repository.SaveAndCommit(entity);
                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }

    }
}