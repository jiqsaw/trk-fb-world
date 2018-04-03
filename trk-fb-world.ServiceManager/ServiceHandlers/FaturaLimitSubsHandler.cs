using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.ServiceConnector;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class FaturaLimitSubsHandler : BaseHandler
    {
        public FaturaLimitBilgisi Data;

        public FaturaLimitSubsHandler()
        {
            Data = new FaturaLimitBilgisi();
        }

        public FaturaLimitBilgisi PrepareData()
        {
            //KONTROL LIMITIM
            try
            {
                FaturaLimitSubsResponse FaturaLimitsQueryObj = WebServiceLoader.FaturaLimitSubsQuery();

                Data.CurrentAmount = Convert.ToDouble(FaturaLimitsQueryObj.FaturaLimitSubs.CurrentAmount.Replace(".", ","));
                Data.LimitAmount = Math.Max(0, Convert.ToDouble(FaturaLimitsQueryObj.FaturaLimitSubs.LimitAmount.Replace(".", ",")));

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
