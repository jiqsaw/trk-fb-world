using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace LIB
{
    public class CookieHelper
    {
        HttpRequest Request;
        HttpResponse Response;

        public CookieHelper()
        {
            this.Request = HttpContext.Current.Request;
            this.Response = HttpContext.Current.Response;
        }

        public void Write(string CookieName, int TimeOut, string Value)
        {
            if (Request != null)
            {
                if (Request.Cookies[CookieName] != null) { Response.Cookies.Set(Request.Cookies[CookieName]); }
                else { Response.Cookies.Set(new HttpCookie(CookieName)); }

                Response.Cookies[CookieName][CookieName] = Value;
                Response.Cookies[CookieName].Expires = DateTime.Now.AddMinutes(TimeOut);
            }
        }

        public string Read(string CookieName)
        {
            return (Request.Cookies[CookieName] != null) ? Request.Cookies[CookieName][CookieName].ToString() : String.Empty;
        }

        public void Delete(string CookieName)
        {
            if (this.Read(CookieName) != "")
                Request.Cookies.Remove(CookieName);
        }

        public void Clear()
        {
            Request.Cookies.Clear();
        }
    }

}