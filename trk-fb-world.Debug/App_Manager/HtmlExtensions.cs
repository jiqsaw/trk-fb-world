using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.App.App_Manager
{
    public static class HtmlExtensions
    {
        public static IHtmlString stringHelper(this HtmlHelper html, string value)
        {
            if (String.IsNullOrEmpty(value))
                return new HtmlString("&nbsp;");
            else
            {
                return new HtmlString(value);
            }
        }
    }
}