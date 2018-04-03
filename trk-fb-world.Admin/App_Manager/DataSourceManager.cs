using TurkcellFacebookDunyasi.Com.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.Admin.App_Manager
{
    public class DataSourceManager
    {
        public static List<SelectListItem> GetOfferTypes()
        { 
            return App_Manager.SelectListHelper.SelectListEnum(typeof(Parameter.OfferTypePosition));
        }
    }
}