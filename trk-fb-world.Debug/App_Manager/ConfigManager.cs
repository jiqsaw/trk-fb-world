using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using LIB.ExtentionMethods;

namespace TurkcellFacebookDunyasi.App.App_Manager
{
    public class ConfigManager
    {
        #region Structure

        private static ConfigManager _ConfigManager;

        private ConfigManager() {  }

        public static ConfigManager GetInstance() {
            if (_ConfigManager == null)
                _ConfigManager = new ConfigManager();
            return _ConfigManager;
        }

        private object GET(ConfigName ConfigName) { return ConfigurationManager.AppSettings[ConfigName.ToString()]; }
        public object GetManual(ConfigName ConfigName) { return ConfigurationManager.AppSettings[ConfigName.ToString()]; }
        public object GetFb(ConfigNameFb ConfigNameFb) { return ConfigurationManager.AppSettings[ConfigNameFb.ToString()]; }
        #endregion

        public enum ConfigName
        {
            /* Paths & Urls in Com.Helpers.UrlHelper */

            ByPassLogin,
            ByPassLoginMsisdn,            
            SsoLoginPath,
            SsoLoginResultPath,
            TimeOutPath,
            MainPath,
            WebPlatformCode,
            GAEnabled,
            AvailableWeekDayTimeBegin,
            AvailableWeekDayTimeEnd,
            AvailableWeekEndTimeBegin,
            AvailableWeekEndTimeEnd,
            TemplateMsg_Birthday,
            url_TLYukleIframe,

            SmsCharLength
        }

        public enum ConfigNameFb
        {            
            Facebook_AppPageName,
            Facebook_PageId,
            Facebook_PageUrl, 

            Facebook_Title,
            Facebook_Type,
            Facebook_PageAppTabUrl,
            Facebook_Image,
            Facebook_SiteName,
            Facebook_Description,
            Facebook_Admin1,
            Facebook_Admin2,

            Facebook_InviteMsg,
            Facebook_ShareCaption,
            Facebook_ShareDesc

        }

        public string SsoLoginPath { get { return GET(ConfigName.SsoLoginPath).ToString(); } }
        public string TimeOutPath { get { return GET(ConfigName.TimeOutPath).ToString(); } }
        public string SsoLoginResultPath { get { return GET(ConfigName.SsoLoginResultPath).ToString(); } }
        public string MainPath { get { return GET(ConfigName.MainPath).ToString(); } }
        public string TemplateMsg_Birthday { get { return GET(ConfigName.TemplateMsg_Birthday).ToString(); } }

        public string TLYukleIframeUrl { get { return GET(ConfigName.url_TLYukleIframe).ToString(); } }

        public string AvailableWeekDayTimeBegin { get { return GET(ConfigName.AvailableWeekDayTimeBegin).ToString(); } }
        public string AvailableWeekDayTimeEnd { get { return GET(ConfigName.AvailableWeekDayTimeEnd).ToString(); } }
        public string AvailableWeekEndTimeBegin { get { return GET(ConfigName.AvailableWeekEndTimeBegin).ToString(); } }
        public string AvailableWeekEndTimeEnd { get { return GET(ConfigName.AvailableWeekEndTimeEnd).ToString(); } }

        public string SmsCharLength { get { return GET(ConfigName.SmsCharLength).ToString(); } }
        public string WebPlatformCode { get { return GET(ConfigName.WebPlatformCode).ToString(); } }

        public bool ByPassLogin { get { return Convert.ToBoolean(GET(ConfigName.ByPassLogin)); } }
        public string ByPassLoginMsisdn { get { return GET(ConfigName.ByPassLoginMsisdn).ToString(); } }

        public bool GAEnabled { get { return Convert.ToBoolean(GET(ConfigName.GAEnabled)); } }        
    }
}