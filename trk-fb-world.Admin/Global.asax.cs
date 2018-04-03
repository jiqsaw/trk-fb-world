using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.EF;


namespace TurkcellFacebookDunyasi.Admin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ObjectFactoryInit();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void ObjectFactoryInit()
        {
            ObjectFactory.Initialize(cfg =>
            {
                cfg.For<IAdminRepository>().Use<AdminRepository>();
                cfg.For<IAdminAuthRepository>().Use<AdminAuthRepository>();
                cfg.For<IUserFbRepository>().Use<UserFbRepository>();
                cfg.For<IFaqRepository>().Use<FaqRepository>();
                cfg.For<IModulRepository>().Use<ModulRepository>();
                cfg.For<IOfferRepository>().Use<OfferRepository>();
                cfg.For<IUserFbRepository>().Use<UserFbRepository>();
                cfg.For<IUserRequestTLRepository>().Use<UserRequestTLRepository>();
                cfg.For<IUserSentTLRepository>().Use<UserSentTLRepository>();
                cfg.For<IUserSmsRepository>().Use<UserSmsRepository>();
                cfg.For<ITransferAmountRepository>().Use<TransferAmountRepository>();
                cfg.For<IWebServiceLogRepository>().Use<WebServiceLogRepository>();
                cfg.For<IWebServiceRepository>().Use<WebServiceRepository>();

            });

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }
    }
}