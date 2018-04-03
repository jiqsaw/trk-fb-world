using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LIB;

namespace TurkcellFacebookDunyasi.Admin.App_Manager
{
    public class CookieManager
    {
        private CookieHelper cookie;

        public CookieManager()
        {
            this.cookie = new CookieHelper();
        }

        public enum CookieType
        {
            AdminId,
            Language,
            Culture
        }

        public void Write(CookieType CookieName, object Value)
        {
            cookie.Write(CookieName.ToString(), (int)CookieName, Value.ToString());
        }

        public string Read(CookieType CookieName)
        {
            return cookie.Read(CookieName.ToString());
        }

        public void Delete(CookieType CookieName)
        {           
            cookie.Delete(CookieName.ToString());
        }

        public void Clear()
        {
            cookie.Clear();
        }
    }
}