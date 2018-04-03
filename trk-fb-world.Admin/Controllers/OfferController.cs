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
    public class OfferController : BaseAuthorizedController
    {
        private readonly IOfferRepository repository;
        private readonly OfferService service;

        public OfferController(IOfferRepository repository, OfferService service)
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

        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, Offer item)
        {
            if (item != null)
            {
                string a = item.CreateDate.ToString();
                repository.DeleteAndCommit(item);
            }

            return k_jRead(request);
        }

        public JsonResult GetOfferTypes()
        {
            return Json(DataSourceManager.GetOfferTypes(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Form(int? Id)
        {
            if (Id != null) return View(repository.GetById(Id.Value));

            return View();
        }

        [HttpPost]
        public ActionResult Form(Offer entity)
        {
            try
            {
                if (session.LastUploadedFile != String.Empty)
                {
                    entity.FileName = session.LastUploadedFile;
                    ImageResizing(entity.OfferTypeCode, entity.FileName);
                    session.LastUploadedFile = String.Empty;
                }

                repository.SaveAndCommit(entity);
                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }


        private void ImageResizing(int OfferTypeCode, string FileName)
        {
            Parameter.OfferType OfferType = (Parameter.OfferType)OfferTypeCode;            

            int W = 0;
            int H = 0;
            
            var OriginalPath = PathHelper.Images.OfferPhysc(FileName, Parameter.ImageSizeNaming.Original);
            var DefaultPath = PathHelper.Images.OfferPhysc(FileName);

            LIB.ImageHelper imgHelper = new LIB.ImageHelper();

            W = (int)Parameter.ImageSizes.Offer_Default_W;
            H = (int)Parameter.ImageSizes.Offer_Default_H;
            imgHelper.Crop(OriginalPath, DefaultPath, W, H, true);
        }

        [OutputCache(Duration = 0)]
        public ActionResult Sortable(int? OfferType)
        {
            if (OfferType == null)
                return View();
            else
            {
                return View(service.GetAllPublishedByType((Parameter.OfferType)OfferType));
            }
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
