using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Filters;

namespace TurkcellFacebookDunyasi.App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleExceptionAttribute());
            //filters.Add(new HandleErrorAttribute());            
        }
    }
}