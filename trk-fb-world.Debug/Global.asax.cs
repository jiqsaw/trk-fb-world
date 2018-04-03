using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Mvc.Facebook;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.EF;
using StructureMap;
using TurkcellFacebookDunyasi.Core;

namespace TurkcellFacebookDunyasi.App
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ObjectFactoryInit();

            AreaRegistration.RegisterAllAreas();

            FacebookConfig.Register(GlobalFacebookConfiguration.Configuration);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void ObjectFactoryInit()
        {
            ObjectFactory.Initialize(cfg =>
            {
                cfg.For<IFaqRepository>().Use<FaqRepository>();
                cfg.For<IOfferRepository>().Use<OfferRepository>();
                cfg.For<IUserFbRepository>().Use<UserFbRepository>();
                cfg.For<IUserRequestTLRepository>().Use<UserRequestTLRepository>();
                cfg.For<IUserSentTLRepository>().Use<UserSentTLRepository>();                
                cfg.For<IWebServiceRepository>().Use<WebServiceRepository>();
                cfg.For<IClickToCallRepository>().Use<ClickToCallRepository>();
                cfg.For<IClickToCallFreeRepository>().Use<ClickToCallFreeRepository>();
                cfg.For<IClickToCallUserBlockRepository>().Use<ClickToCallUserBlockRepository>();
                cfg.For<IClickToCallPreferenceRepository>().Use<ClickToCallPreferenceRepository>();
                cfg.For<IUserSmsRepository>().Use<UserSmsRepository>();
                cfg.For<ITransferAmountRepository>().Use<TransferAmountRepository>();
                cfg.For<IWebServiceLogRepository>().Use<WebServiceLogRepository>();
                cfg.For<ITransactionLogRepository>().Use<TransactionLogRepository>();

            });

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

    }
}