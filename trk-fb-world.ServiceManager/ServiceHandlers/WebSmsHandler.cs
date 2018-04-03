using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.ServiceManager.Models.Partials;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class WebSmsHandler : BaseHandler
    {
        public WebSms Data { get; set; }

        public WebSmsHandler()
        {
            Data = new WebSms();
        }

        /// <summary>
        /// WebSMS Servisinin balance sorgusunu calistirmak icin cagirilir.
        /// </summary>
        /// <param name="msisdn">Balance sorgusu yapilacak MSISDN</param>
        /// <returns>WebSms(Msisdn,Balance,FreeTotal,Error) yada null</returns>
        public WebSms PrepareData(string msisdn)
        {
            try
            {
                WebSmsBalanceQueryResponse BalanceQueryObj = WebServiceLoader.WebSmsBalanceQuery(msisdn);
                Data.Msisdn = BalanceQueryObj.Msisdn;
                Data.Balance = BalanceQueryObj.Balance;
                Data.FreeTotal = BalanceQueryObj.FreeTotal;
                Data.Error = BalanceQueryObj.Error;

                return Data;

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// WebSMS Servisinin sendsms sorgusunu calistirmak icin cagirilir.
        /// </summary>
        /// <param name="msisdn">Mesaj gönderen kisinin MSISDN numarasi</param>
        /// <param name="recipientMsisdn">Mesaj alicisinin MSISDN numarasi</param>
        /// <param name="message">Gönderilecek mesaj</param>
        /// <returns>WebSms(Sender,Recipients,Message,Balance,Error) yada null</returns>
        public WebSms PrepareData(string msisdn, string recipientMsisdn, string message)
        {
            try
            {
                WebSmsSendMessageResponse MessageQueryObj = WebServiceLoader.WebSmsSendMessageQuery(msisdn, recipientMsisdn, message);
                Data.Sender = MessageQueryObj.Sender;
                foreach (var r in MessageQueryObj.Recipients)
                {
                    Data.Recipients.Add(new TurkcellFacebookDunyasi.ServiceManager.Models.Partials.Recipient
                    {
                        Charge = r.Charge,
                        Msisdn = r.Msisdn,
                        Status = r.Status
                    });
                }
                Data.Message = MessageQueryObj.Message;
                Data.Balance = MessageQueryObj.Balance;
                Data.Error = MessageQueryObj.Error;

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public WebSms PrepareData(string msisdn, string[] recipients, string message)
        {
            try
            {
                WebSmsSendMessageResponse MessageQueryObj = WebServiceLoader.WebSmsSendMessageQuery(msisdn, recipients, message);
                Data.Sender = MessageQueryObj.Sender;
                foreach (var r in MessageQueryObj.Recipients)
                {
                    Data.Recipients.Add(new TurkcellFacebookDunyasi.ServiceManager.Models.Partials.Recipient
                        {
                            Charge = r.Charge,
                            Msisdn = r.Msisdn,
                            Status = r.Status
                        });
                }
                Data.Message = MessageQueryObj.Message;
                Data.Balance = MessageQueryObj.Balance;
                Data.Error = MessageQueryObj.Error;

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
