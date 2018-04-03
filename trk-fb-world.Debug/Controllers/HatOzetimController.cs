using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class HatOzetimController : BaseController
    {
        public PartialViewResult Default()
        {
            //HAT OZETIM SAYFASINDAKI HER SERVIS CAGRISI, PARTIAL SERVIS HANDLER OLARAK
            //DEGISTIRILDI. CAGIRILMASI GEREKEN PARTIAL SERVISLER:
            /*
             * TARIFE BILGINIZ:     HatOzetimHandler                MODEL: HatOzetimModel
             * KLUBUM:              KlubumHandler                   MODEL: KlubumModel
             * PAKET VE SERVISLER:  PaketServisHandler              MODEL: PaketServisModel
             * KALAN KULLANIM:      KalanKullanimBilgisiHandler     MODEL: KalanKullanimBilgisiModel
             */

            return PartialView();
        }

        public PartialViewResult TariffInfo()
        {
            HatOzetimModel model = new HatOzetimModel();

            HatOzetimHandler handler = new HatOzetimHandler();
            model.serviceData = handler.PrepareData();

            return PartialView(model);
        }

        public PartialViewResult Remaining()
        {
            KalanKullanimBilgisiModel model = new KalanKullanimBilgisiModel();

            KalanKullanimBilgisiHandler handler = new KalanKullanimBilgisiHandler(UserFb.Data.UserType);
            model.serviceData = handler.PrepareData();

            return PartialView(model);
        }

        public PartialViewResult Club()
        {

            KlubumModel model = new KlubumModel();

            KlubumHandler handler = new KlubumHandler();
            model.serviceData = handler.PrepareData();

            return PartialView(model);
        }

        public PartialViewResult ServicePackages()
        {
            PaketServisModel model = new PaketServisModel();

            PaketServisHandler handler = new PaketServisHandler();
            model.serviceData = handler.PrepareData();

            return PartialView(model);
        }

        public PartialViewResult UseOfPackage()
        {
            KalanKullanimBilgisiModel model = new KalanKullanimBilgisiModel();

            KalanKullanimBilgisiHandler handler = new KalanKullanimBilgisiHandler(UserFb.Data.UserType);
            model.serviceData = handler.PrepareData();

            return PartialView(model);
        }



    }
}