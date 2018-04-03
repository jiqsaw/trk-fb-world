using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class TLGonderHandler : BaseHandler
    {
        public TLGonder Data;

        public TLGonderHandler()
        {
            Data = new TLGonder();
        }

        public TLGonder PrepareData(TLGonderMethod method)
        {
            CreditTransferResponse CreditTransferObj;
            
            try
            {
                switch (method)
                {
                    case TLGonderMethod.GET:
                        CreditTransferObj = WebServiceLoader.CreditTransferQueryStep1();
                        Data.AvailableLimits = CreditTransferObj.CreditTransfer.AvailableLimits;

                        break;

                    case TLGonderMethod.POST:
                        CreditTransferObj = WebServiceLoader.CreditTransferQueryStep3();
                        Data.ServiceResponse = CreditTransferObj.ServiceResult;

                        break;
                }

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TLGonder PrepareData(string bNumber, int creditIndex)
        {
            try
            {
                CreditTransferResponse CreditTransferObj = WebServiceLoader.CreditTransferQueryStep2(bNumber, creditIndex);
                if (!String.IsNullOrEmpty(CreditTransferObj.ErrorCode))
                    Data.ErrorMessage = CreditTransferObj.Error;
                else
                {
                    Data.BNumber = CreditTransferObj.CreditTransfer.BNumber;
                    Data.CreditAmount = CreditTransferObj.CreditTransfer.CreditAmount;
                }

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public enum TLGonderMethod
        {
            GET,
            POST
        }
    }
}
