using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.Services;
using TurkcellFacebookDunyasi.EF;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [ActionLog]
    public class OfferController : BaseController
    {
        private readonly IOfferRepository repository;
        private readonly OfferService service;

        public OfferController(IOfferRepository repository, OfferService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public PartialViewResult General()
        {
            return PartialView(repository.GetAllPublishedByTypeTake(Parameter.OfferType.General, 3));
        }

        public PartialViewResult Suggestion()
        {
            return PartialView(repository.GetAllPublishedByTypeTake(Parameter.OfferType.Suggestion, 5));
        }

        public PartialViewResult Startup()
        {
            return PartialView(repository.GetAllPublishedByTypeTake(Parameter.OfferType.Startup, 5));
        }
    }
}
