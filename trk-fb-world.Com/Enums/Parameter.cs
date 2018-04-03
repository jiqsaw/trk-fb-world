using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TurkcellFacebookDunyasi.Com.Enums
{
    public class Parameter
    {
        public enum Language
        {
            NoLanguage = 0,

            [Display(Name = "Türkçe")]
            Turkish = 1,

            [Display(Name = "English")]
            English = 2,

            [Display(Name = "Russian")]
            Russian = 3,

            [Display(Name = "Persian")]
            Persian = 4
        }

        public enum PlaceType
        {
            Country = 1,
            City = 2,
            County = 3
        }

        public enum OfferTypePosition
        {
            [Display(Name = "OfferType_Suggestion", ResourceType = typeof(rsrcEnumDisplays))]
            Suggestion = 1,

            [Display(Name = "OfferType_Startup", ResourceType = typeof(rsrcEnumDisplays))]
            Startup = 2,

            [Display(Name = "OfferType_General", ResourceType = typeof(rsrcEnumDisplays))]
            General = 3

        }

        public enum WindowType
        {
            [Display(Name = "WindowPosition_self", ResourceType = typeof(rsrcEnumDisplays))]
            _self = 1,

            [Display(Name = "WindowPosition_blank", ResourceType = typeof(rsrcEnumDisplays))]
            _blank = 2,

            [Display(Name = "WindowPosition_top", ResourceType = typeof(rsrcEnumDisplays))]
            _top = 3,

            [Display(Name = "WindowPosition_parent", ResourceType = typeof(rsrcEnumDisplays))]
            _parent = 4
        }


        public enum SexCode
        {
            Male = 0,
            Female = 1
        }

        public enum ImageSizeNaming
        {
            Original = 0,
            Default = 1,
            Preview = 2
        }

        public enum ImageSizes
        {
            None = 0,

            AdminUser_Default_W = 200,

            Preview_W = 50,
            Preview_H = 50,

            Offer_Default_W = 68,
            Offer_Default_H = 60
        }

        public enum AdminModulGroup
        {
            IcerikYonetimi = 1,
            AdminKullaniciYonetimi = 2,
            ParametreYonetimi=11,
            LogYonetimi = 19,
            
            ContentManagement = 6,
            Admin = 7,
            Parameter=14,
            Log = 21
        }

        public enum OfferType
        {
            Suggestion = 1,
            Startup = 2,
            General = 3
        }

        public enum InviteType
        {
            Facebook = 1,
            SMS = 2
        }

        public enum UserType
        {   
            None = 0,
            posp = 1,
            prep = 2
        }

        public enum CustomerType
        {
            None = 0,
            flat = 1,
            corp = 2
        }

        public enum InvoiceType
        { 
            Single = 1,
            Multiple = 2
        }
    }
}
