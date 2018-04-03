using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Com.Enums;
using System.IO;
using LIB.ExtentionMethods;
using TurkcellFacebookDunyasi.Com.Helpers;
using TurkcellFacebookDunyasi.Com.Helpers.UrlHelperExtensions;

namespace TurkcellFacebookDunyasi.Com.Helpers.UrlHelperExtensions
{
    public static class Extensions
    {
        public static string ToFullPath(this string val)
        {
            return LIB.Util.GetConfigValue(UrlHelper.Url.url_Static.ToString()).ToString().PathAppend(val);
        }
        public static string ToFullPathPhysc(this string val)
        {
            return LIB.Util.GetConfigValue(UrlHelper.Url.url_Static_phys.ToString()).ToString().PathAppend(val);
        }

        public static string ToFullPathAdmin(this string val)
        {
            return LIB.Util.GetConfigValue(UrlHelper.Url.url_Admin.ToString()).ToString().PathAppend(val);
        }
        public static string ToFullPathAdminPhysc(this string val)
        {
            return LIB.Util.GetConfigValue(UrlHelper.Url.url_Admin_phys.ToString()).ToString().PathAppend(val);
        }
    }
}

namespace TurkcellFacebookDunyasi.Com.Helpers
{
    public class UrlHelper : LIB.UrlHelper
    {
        public enum Url
        {
            url_Web,
            url_Admin,
            url_Web_phys,
            url_Admin_phys,
            url_Admin_Upload_phys,            
            url_Static,
            url_Static_phys,
            url_SsoLogout
        }

        public static string UrlWeb { get { return LIB.Util.GetConfigValue(Url.url_Web.ToString()); } }
        public static string UrlAdmin { get { return LIB.Util.GetConfigValue(Url.url_Admin.ToString()); } }
        public static string UrlWebPhys { get { return LIB.Util.GetConfigValue(Url.url_Admin_phys.ToString()); } }
        public static string UrlAdminPhys { get { return LIB.Util.GetConfigValue(Url.url_Admin_phys.ToString()); } }
        public static string UrlAdminUploadPhys { get { return LIB.Util.GetConfigValue(Url.url_Admin_Upload_phys.ToString()); } }
        public static string UrlStatic { get { return LIB.Util.GetConfigValue(Url.url_Static.ToString()); } }
        public static string SsoLogout { get { return LIB.Util.GetConfigValue(Url.url_SsoLogout.ToString()); } }

        public class Pages
        {
            public struct PageName
            {
                //public const string Default = "";
                
                //User Auth
            }

            public struct UrlKey
            {
                public const string ID = "j";
                public const string Language = "Lng";
                public const string Title = "Title";
                public const string ContentTİtle = "ContentTitle";
                public const string q = "q";  //Search Keyword
                public const string ReturnUrl = "ReturnUrl";
            }

        }

        public class Images {

            public static string root = LIB.Util.GetConfigValue("path_imagesRoot");

            //folder names
            public enum Type
            {
                contents,
                adminusers
            }

            public static string NameByType(Parameter.ImageSizeNaming ImageSize, string FileName)
            {
                return ((int)ImageSize).ToString() + "_" + FileName;
            }

            public static string PathByType(Type Type, string FileName, Parameter.ImageSizeNaming ImageSize)
            {
                return root.PathAppend(Type.ToString()).PathAppend(NameByType(ImageSize, FileName)).ToString();
            }

            public static string Content(string FileName, Parameter.ImageSizeNaming ImageSize = Parameter.ImageSizeNaming.Default)
            {
                return PathByType(Type.contents, FileName, ImageSize);
            }
            public static string AdminUser(string FileName, Parameter.ImageSizeNaming ImageSize = Parameter.ImageSizeNaming.Default)
            {
                return PathByType(Type.adminusers, FileName, ImageSize);
            }
            public static string Offer(string FileName, Parameter.ImageSizeNaming ImageSize = Parameter.ImageSizeNaming.Default)
            {
                return PathByType(Type.contents, FileName, ImageSize);
            }
            public static string OfferPhysc(string FileName, Parameter.ImageSizeNaming ImageSize = Parameter.ImageSizeNaming.Default)
            {
                return Offer(FileName, ImageSize).ToPhysical().ToFullPathPhysc();
            }
            
        }
    }
}