using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class FaturalarimController : BaseController
    {

        public PartialViewResult Default()
        {           
            FaturalarimModel model = new FaturalarimModel();
            model.serviceDataList = Last6Bills();
            return PartialView(model);
        }

        public IList<ServiceManager.Models.Faturalarim> Last6Bills() {
            FaturalarimHandler srvHandler = new FaturalarimHandler();
            return srvHandler.GetBillDatas(UserFb.Data.Msisdn);
        }

        public JsonResult Last6BillsJson()
        {
            FaturalarimHandler srvHandler = new FaturalarimHandler();            
            return Json(srvHandler.GetBillDatas(UserFb.Data.Msisdn).OrderByDescending(p => p.InvoiceDate).ToList(), JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Timeline() {
            return PartialView();
        }

        public PartialViewResult ControlLimit()
        {
            KontrolLimitimModel model = new KontrolLimitimModel();
            FaturaLimitSubsHandler handler = new FaturaLimitSubsHandler();
            model.serviceData = handler.PrepareData();
            return PartialView(model);
        }

        public PartialViewResult CurrentInvoiceInfo()
        {
            InvoiceInfoModel model = new InvoiceInfoModel();

            FaturalarimHandler handler = new FaturalarimHandler();
            model.serviceData = handler.PrepareData();

            return PartialView(model);
        }

        public PartialViewResult Detail()
        {
            return PartialView();
        }

        public PartialViewResult AnalysisDetail()
        {
            return PartialView();
        }


        public JsonResult InvoiceAnalysis(int Index)
        {
            return Json(new { result = "1" }, "text/plain");
        }

        public JsonResult GeInvoiceAnalysisData([DataSourceRequest] DataSourceRequest request, string InvoiceDate)
        {

            ServiceManager.ServiceHandlers.FaturalarimHandler srvHandler = new FaturalarimHandler();

            DateTime parInvoiceDate = DateTime.Parse(InvoiceDate);

            return Json(srvHandler.GetBillAnalysis(UserFb.Data.Msisdn, parInvoiceDate.ToShortDateString()).ToList(), JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult MonthSelector() {

            return PartialView();
        }

    }
}
