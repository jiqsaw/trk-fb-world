using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.Admin.Filters;

namespace TurkcellFacebookDunyasi.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new InternationalizationAttribute());
        }
    }
}