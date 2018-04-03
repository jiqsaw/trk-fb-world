using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.Admin.App_Manager;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Com.Helpers;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.Services;
using System.IO;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Kendo.Mvc.Extensions;


namespace TurkcellFacebookDunyasi.Admin.Controllers
{
    public class TransferAmountController : BaseAuthorizedController
    {
        private readonly ITransferAmountRepository repository;
        private readonly TransferAmountService service;

        public TransferAmountController(ITransferAmountRepository repository, TransferAmountService service)
        {
            this.repository = repository;
            this.service = service;
        }

        // Default
        public ActionResult Default()
        {
            return View();
        }
        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(repository.GetAll().ToDataSourceResult(request));
        }

        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, TransferAmount item)
        {
            if (item != null)
            {
                string a = item.CreateDate.ToString();
                repository.DeleteAndCommit(item);
            }

            return k_jRead(request);
        }

        public ActionResult Form(int? Id)
        {
            if (Id != null) return View(repository.GetById(Id.Value));

            return View();
        }

        [HttpPost]
        public ActionResult Form(TransferAmount entity)
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

        [OutputCache(Duration = 0)]
        public ActionResult Sortable()
        {
                return View(service.GetLiveTransferAmounts());
        }

        public JsonResult UpdateOrders(string Values)
        {
            string[] str = Values.Split(',');

            try
            {
                var i = 0;
                foreach (var item in str)
                {
                    var entity = repository.GetById(int.Parse(item));
                    entity.Order = i.ToString().PadLeft(GlobalVars.OrderLength, '0');
                    repository.Save(entity);

                    i++;
                }

                repository.Commit();
            }
            catch (Exception)
            { }
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

    }
}
