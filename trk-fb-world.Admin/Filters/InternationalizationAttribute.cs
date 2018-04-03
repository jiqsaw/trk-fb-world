using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.Admin.App_Manager;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;

namespace TurkcellFacebookDunyasi.Admin.Filters
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InternationalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CookieManager cookie = new CookieManager();

            //Cookie de Language Bilgisi varsa onu ata
            string cookieLanguage = cookie.Read(CookieManager.CookieType.Language);
            string cookieCulture = cookie.Read(CookieManager.CookieType.Culture);

            if (!String.IsNullOrEmpty(cookieLanguage) && !String.IsNullOrEmpty(cookieCulture))
            {
                GlobalVars.Language = cookieLanguage;
                GlobalVars.Culture = cookieCulture;
            }

            //Eğer dil değiştirilmişse yenisini ata ve cookie yi yenile
            string ChangeLanguage = HttpContext.Current.Request.QueryString["Lng"];            
            if (!String.IsNullOrEmpty(ChangeLanguage))
            {
                if (ChangeLanguage == "tr")
                {
                    GlobalVars.Language = "tr";
                    GlobalVars.Culture = "TR";
                }
                else 
                {
                    GlobalVars.Language = "en";
                    GlobalVars.Culture = "US";
                }

                cookie.Write(CookieManager.CookieType.Language, GlobalVars.Language);
                cookie.Write(CookieManager.CookieType.Culture, GlobalVars.Culture);
            }

            //Culture ı set et
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", GlobalVars.Language, GlobalVars.Culture));
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", GlobalVars.Language, GlobalVars.Culture));

            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = GlobalVars.dateFormat;
            culture.DateTimeFormat.DateSeparator = "/";
            culture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            
            Thread.CurrentThread.CurrentCulture = culture;                       
        }

    }
}
