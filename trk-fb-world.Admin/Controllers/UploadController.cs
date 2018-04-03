using TurkcellFacebookDunyasi.Admin.App_Manager;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Com.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.Com.Helpers.UrlHelperExtensions;
using LIB.ExtentionMethods;

namespace TurkcellFacebookDunyasi.Admin.Controllers
{
    public class UploadController : BaseController
    {
        private PathHelper.Images.Type ImageType;
        private bool NotLiveImg;

        [HttpPost]
        public ActionResult PhotoUpload(HttpPostedFileBase FileUpload, PathHelper.Images.Type ImageType, bool ResizeDefault, int ResizeDefaultW, int ResizeDefaultH, bool NotLiveImg)
        {
            this.ImageType = ImageType;
            this.NotLiveImg = NotLiveImg;

            ViewBag.savedFileName = Com.General.ProjectUtil.GenerateImageName(Path.GetFileName(FileUpload.FileName));

            session.LastUploadedFile = ViewBag.savedFileName;
            
            FileUpload.SaveAs(FullPathPhysc(Parameter.ImageSizeNaming.Original));

            ImageResizePreview();
            
            if (ResizeDefault)
                ImageResize(ResizeDefaultW, ResizeDefaultH, Parameter.ImageSizeNaming.Default);

            var savedBig = (ResizeDefault) ? FullPath(Parameter.ImageSizeNaming.Default) : FullPath(Parameter.ImageSizeNaming.Original);

            return Json(new { savedFileName = ViewBag.savedFileName, savedBig = savedBig, pathPreview = FullPath(Parameter.ImageSizeNaming.Preview) }, "text/plain");
        }

        [HttpPost]
        public ActionResult PhotoRemove(string[] fileNames, PathHelper.Images.Type ImageType, bool NotLiveImg)
        {
            if (session.LastUploadedFile != "")
            {
                ViewBag.savedFileName = session.LastUploadedFile;

                this.ImageType = ImageType;
                this.NotLiveImg = NotLiveImg;

                DeleteImage(FullPathPhysc(Parameter.ImageSizeNaming.Original));
                DeleteImage(FullPathPhysc(Parameter.ImageSizeNaming.Default));
                DeleteImage(FullPathPhysc(Parameter.ImageSizeNaming.Preview));
                
                ViewBag.savedFileName = session.LastUploadedFile = "";
            }
            return Json(new { }, "text/plain");
        }


        private static void DeleteImage(string FullPath)
        {
            if (System.IO.File.Exists(FullPath))
                try
                {
                    System.IO.File.Delete(FullPath);
                }
                catch (Exception) { }
        }


        private void ImageResize(int ResizeDefaultW, int ResizeDefaultH, Parameter.ImageSizeNaming ImageSizeNaming)
        {
            LIB.ImageHelper imgHelper = new LIB.ImageHelper();

            if (ResizeDefaultH > 0)
                imgHelper.Crop(FullPathPhysc(Parameter.ImageSizeNaming.Original), FullPathPhysc(ImageSizeNaming), ResizeDefaultW, ResizeDefaultH, true);
            else
                imgHelper.Resize(FullPathPhysc(Parameter.ImageSizeNaming.Original), FullPathPhysc(ImageSizeNaming), ResizeDefaultW);
        }
        private void ImageResizePreview()
        {
            ImageResize((int)Parameter.ImageSizes.Preview_W, 0, Parameter.ImageSizeNaming.Preview);
        }

        private string FullPath(Parameter.ImageSizeNaming ImageSizeNaming)
        {
            return ((string)PathHelper.Images.PathByType(this.ImageType, ViewBag.savedFileName, ImageSizeNaming)).ToFullPath();
        }

        private string FullPathPhysc(Parameter.ImageSizeNaming ImageSizeNaming)
        {
            var path = ((string)PathHelper.Images.PathByType(this.ImageType, ViewBag.savedFileName, ImageSizeNaming)).ToPhysical();
            return (!this.NotLiveImg) ? path.ToFullPathPhysc() : path.ToFullPathAdminPhysc();
        }
    }
}
