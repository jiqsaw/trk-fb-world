using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.Services;
using TurkcellFacebookDunyasi.EF;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [ActionLog]
    public class FaqController : BaseController
    {
        private readonly IFaqRepository repository;
        private readonly FaqService service;

        public FaqController(IFaqRepository repository, FaqService service)
        {
            this.repository = repository;
            this.service = service;
        }
        
        public PartialViewResult Default()
        {
            return PartialView();
        }

        public JsonResult GetAllTitles()
        {
            return Json(repository.GetAllPublished(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Detail(int Id)
        {
            return Json(repository.GetById(Id), JsonRequestBehavior.AllowGet);
        }

    }
}