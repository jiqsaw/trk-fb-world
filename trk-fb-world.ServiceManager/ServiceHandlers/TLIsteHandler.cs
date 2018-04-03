using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class TLIsteHandler : BaseHandler
    {
        public const string errorCodeNotAvailableTime = "5009";

        public TLIste Data;

        public TLIsteHandler()
        {
            Data = new TLIste();
        }

        public TLIste PrepareData(string toTelNo, int transferAmount)
        {
            try
            {
                KontorIsteQueryResponse KontorIsteQueryObj = WebServiceLoader.KontorIsteQuery(toTelNo, transferAmount);

                if (!String.IsNullOrEmpty(KontorIsteQueryObj.ErrorCode))
                    Data.ErrorMessage = KontorIsteQueryObj.Error;
                else
                {
                    Data.GetToMsisdn = KontorIsteQueryObj.KontorIsteApprovePage.TransferCounterEntry.GetToMsisdn;
                    Data.GetCounterAmount = KontorIsteQueryObj.KontorIsteApprovePage.TransferCounterEntry.GetCounterAmount;
                }

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
