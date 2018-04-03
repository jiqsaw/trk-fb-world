using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using System.Web;
using TurkcellFacebookDunyasi.Com.Enums;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class CallDetailHandler : BaseHandler
    {
        public IList<CallDetails> Data { get; set; }
        public bool IsSubscriptionActive { get; set; }

        public Parameter.CustomerType customerType { get; set; }

        public CallDetailHandler()
        {
            Data = new List<CallDetails>();
            IsSubscriptionActive = false;
        }

        public bool GetSubscriptionStatus(Parameter.UserType userType)
        {
            CallDetailsQueryResponse resp = WebServiceLoader.CallDetailsSubscriptionQuery(userType.ToString());
            if (resp.CallDetailsFirstPage != null)
            {
                return resp.CallDetailsFirstPage.IsSubscriptionActive;
            }

            return false;
        }

        public IList<CallDetails> PrepareData(string Period)
        {
            bool subscriptionStatus = GetSubscriptionStatus((Parameter.UserType)Enum.Parse(typeof(Parameter.UserType),"posp"));
            HttpContext.Current.Session["IsSubscriptionActive"] = subscriptionStatus;

            CallDetailsQueryResponse resp = WebServiceLoader.CallDetailsQuery(Period, this.customerType);
            IList<CallDetail> srvCallDetail = resp.CallDetailsSuccessPage.CallDetails;

            foreach (var item in srvCallDetail)
            {
                var model = new CallDetails();
                model.Amount = item.GetRatedflatAmount;
                model.DataVolume = item.GetDataVolume;
                model.DateDisplay = item.GetDay + " " + item.GetHour;
                model.Description = item.GetDescription;
                model.OpAddress = item.GetOpNumberAddress;

                Data.Add(model);
            }

            return Data;
        }

        public IList<CallDetails> PrepareData(string startDate, string endDate)
        {
            //Prepaid hatlar icin parametresiz sorgu zaten must
            bool subscriptionStatus = GetSubscriptionStatus((Parameter.UserType)Enum.Parse(typeof(Parameter.UserType), "prep"));
            HttpContext.Current.Session["IsSubscriptionActive"] = subscriptionStatus;


            CallDetailsQueryResponse resp = WebServiceLoader.CallDetailsQuery(startDate, endDate);
            IList<CallDetail> srvCallDetail = resp.PrepaidCallDetailsSuccessPage.CallDetails;

            foreach (var item in srvCallDetail)
            {
                var model = new CallDetails();
                model.Amount = item.GetUsedCounter;
                model.DataVolume = item.GetVolume;
                model.DateDisplay = item.GetDate + " " + item.GetHour;
                model.Description = item.GetDescription;
                model.OpAddress = item.GetCalledNumber;

                Data.Add(model);
            }

            return Data;
        }
    }
}
