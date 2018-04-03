using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.ServiceManager.Models.Partials;
using LIB.ExtentionMethods;
using TurkcellFacebookDunyasi.Com.Enums;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class HatOzetimHandler : BaseHandler
    {
        /* KULLANILAN WEB SERVİSLER
            TariffQuery
        */        

        public HatOzetim Data;

        public HatOzetimHandler()
        {
            Data = new HatOzetim();
        }

        public HatOzetim PrepareData()
        {
            //TARİFE BİLGİLERİ
            try
            {
                TariffQueryResponse TarifQueryObj = WebServiceLoader.TariffQuery();

                Data.AdvPackName = TarifQueryObj.TariffQuery.AdvPackName;
                Data.TariffDesc = TarifQueryObj.TariffQuery.TariffDesc;

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }        

    }
}