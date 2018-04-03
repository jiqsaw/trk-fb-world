using TurkcellFacebookDunyasi.Admin.App_Manager;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TurkcellFacebookDunyasi.Com.Helpers.UrlHelperExtensions;

namespace TurkcellFacebookDunyasi.Admin.Models
{
    public class UploadModel
    {
        public string UploadElementName { get; set; }

        [DataType(DataType.Upload)]
        public string FileName { get; set; }

        public PathHelper.Images.Type ImageType { get; set; }

        [EnumDataType(typeof(TurkcellFacebookDunyasi.Admin.App_Manager.ConfigManager.ConfigName))]
        public string PhysicalImagePath { get; set; }

        public bool ResizeDefault { get; set; }
        public Parameter.ImageSizes ResizeDefaultW { get; set; }
        public Parameter.ImageSizes ResizeDefaultH { get; set; }

        public bool NotLiveImg { get; set; }
        public bool NotRequired { get; set; }

        public string srcBig { get {
            if (!String.IsNullOrEmpty(FileName))
            {
                var path = PathHelper.Images.PathByType(ImageType, FileName, Parameter.ImageSizeNaming.Default);
                return (NotLiveImg) ? path : path.ToFullPath();
            }
            return "";
        } }

        public string srcPreview { get {
            if (!String.IsNullOrEmpty(FileName))
            {
                var path = PathHelper.Images.PathByType(ImageType, FileName, Parameter.ImageSizeNaming.Preview);
                return (NotLiveImg) ? path : path.ToFullPath();
            }
            return "";
        } }
    }
}