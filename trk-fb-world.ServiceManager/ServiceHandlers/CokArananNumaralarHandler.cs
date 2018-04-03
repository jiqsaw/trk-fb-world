using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class CokArananNumaralarHandler : BaseHandler
    {
        public IList<EnCokArananNumaralar> Data;

        public CokArananNumaralarHandler()
        {
            Data = new List<EnCokArananNumaralar>();
        }

        //Prepaid hatlar icin
        public IList<EnCokArananNumaralar> PrepareData()
        {
            try
            {
                FacebookOperationsQueryResponse FacebookOperationsQueryObj = WebServiceLoader.TopCalledNumbersQuery();

                EnCokArananNumaralar topCalledNumber;
                foreach (var number in FacebookOperationsQueryObj.TopCalledNumbers)
                {
                    topCalledNumber = new EnCokArananNumaralar();
                    topCalledNumber.Msisdn = number.Msisdn;
                    topCalledNumber.Order = number.Order;

                    Data.Add(topCalledNumber);
                }

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Postpaid hatlar icin
        public IList<EnCokArananNumaralar> PrepareData(string invoiceNumber)
        {
            try
            {
                FacebookOperationsQueryResponse FacebookOperationsQueryObj = WebServiceLoader.TopCalledNumbersQuery(invoiceNumber);
                
                EnCokArananNumaralar topCalledNumber;
                foreach (var number in FacebookOperationsQueryObj.TopCalledNumbers)
                {
                    topCalledNumber = new EnCokArananNumaralar();
                    topCalledNumber.Msisdn = number.Msisdn;
                    topCalledNumber.Order = number.Order;

                    Data.Add(topCalledNumber);
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
