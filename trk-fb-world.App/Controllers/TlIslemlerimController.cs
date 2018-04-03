using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;
using TurkcellFacebookDunyasi.Com.Enums;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class TlIslemlerimController : BaseController
    {
        public PartialViewResult Default()
        {
            return PartialView();
        }

        public PartialViewResult PeriodSelector()
        {
            // 7 ser günlük, 2 ay gecmise kadar giden tarih araligi hesaplamasi
            var model = new CallDetailsModel();
            model.DateRange = CallDetailsModel.GetDateRange();

            return PartialView(model);
        }

        public PartialViewResult DetailPeriodSelector()
        {
            // 7 ser günlük, 2 ay gecmise kadar giden tarih araligi hesaplamasi
            var model = new CallDetailsModel();
            model.DateRange = CallDetailsModel.GetDateRange();

            return PartialView(model);
        }

        public PartialViewResult FriendPeriodSelector(string Id)
        {
            ViewBag.FbId = Id;
            // 7 ser günlük, 2 ay gecmise kadar giden tarih araligi hesaplamasi
            var model = new CallDetailsModel();
            model.DateRange = CallDetailsModel.GetDateRange();

            return PartialView(model);
        }

        public PartialViewResult GuncelTLMiktari()
        {
            var model = new GuncelTLMiktariModel();
            var handler = new GuncelTLMiktariHandler();
            model.serviceData = handler.PrepareData();

            return PartialView(model);
        }

        public PartialViewResult KrediIsteLimit()
        {
            var model = new KrediIsteModel();
            KontorIsteLimitHandler handler = new KontorIsteLimitHandler();
            model.serviceData = handler.PrepareData();

            return PartialView(model);

        }
        public PartialViewResult TLStatus()
        {
            GuncelTLMiktariModel model = new GuncelTLMiktariModel();

            GuncelTLMiktariHandler handler = new GuncelTLMiktariHandler();
            model.serviceData = handler.PrepareData();

            return PartialView(model);
        }

        public PartialViewResult CallDetails()
        {
            return PartialView();
        }

    }
}
