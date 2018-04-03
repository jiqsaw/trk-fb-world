using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.ServiceConnector;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class GuncelTLMiktariHandler : BaseHandler
    {
        public GuncelTLMiktari Data;

        public GuncelTLMiktariHandler()
        {
            Data = new GuncelTLMiktari();
        }

        public GuncelTLMiktari PrepareData()
        {
            try
            {
                KontorMetreQueryResponse KontorMetreQueryObj = WebServiceLoader.KontormetreQuery();
                Data.CurrentAmount = KontorMetreQueryObj.Kontormetre.CurrentCounter;

                UsagePeriodDisplayQueryResponse UsagePeriodQueryObj = WebServiceLoader.UsagePeriodDisplayQuery();
                Data.BothWayBaringDate = UsagePeriodQueryObj.UsagePeriod.BothWayBaringDate;
                Data.OneWayBaringDate = UsagePeriodQueryObj.UsagePeriod.OneWayBaringDate;
                Data.ServiceRemovalDate = UsagePeriodQueryObj.UsagePeriod.ServiceRemovalDate;
                Data.CounterRechargeDate = UsagePeriodQueryObj.UsagePeriod.CounterRechargeDate;

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
