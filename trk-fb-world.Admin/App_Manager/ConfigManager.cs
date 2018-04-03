using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using LIB.ExtentionMethods;

namespace TurkcellFacebookDunyasi.Admin.App_Manager
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
        #endregion

        public enum ConfigName
        {
            /* Paths & Urls in Com.Helpers.UrlHelper */
            AutoLogin,
            AdminId,
            IsContentMultiLanguageEnabled,            
            UploadDefaultMaxKB
        }

        public bool AutoLogin { get { return Convert.ToBoolean(GET(ConfigName.AutoLogin).ToString()); } }
        public int AdminId { get { return Convert.ToInt32(GET(ConfigName.AdminId).ToString()); } }
        public bool IsContentMultiLanguageEnabled { get { return Convert.ToBoolean(GET(ConfigName.IsContentMultiLanguageEnabled).ToString()); } }        
        public int UploadDefaultMaxKB { get { return GET(ConfigName.UploadDefaultMaxKB).ToInt(); } }

    }
}