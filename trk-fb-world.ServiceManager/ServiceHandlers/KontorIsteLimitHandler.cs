using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class KontorIsteLimitHandler : BaseHandler
    {
        public KontorIsteLimit Data;

        public KontorIsteLimitHandler()
        {
            Data = new KontorIsteLimit();
        }

        public KontorIsteLimit PrepareData()
        {
            try
            {
                KontorIsteLimitQueryResponse KontorIsteLimitObj = WebServiceLoader.KontorIsteLimitQuery();
                Data.CounterAmountLimit = KontorIsteLimitObj.KontorIsteLimitQuery.CounterAmountLimit;
                Data.RequestCountLimit = KontorIsteLimitObj.KontorIsteLimitQuery.RequestCountLimit;

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
