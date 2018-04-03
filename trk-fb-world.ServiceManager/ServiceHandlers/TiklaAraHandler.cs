#define WSDLTestPlatform

using LIB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Logger;

#if WSDLTestPlatform
using TurkcellFacebookDunyasi.ServiceConnector.TiklaKonus;
using TurkcellFacebookDunyasi.Core;
#else
#endif

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class TiklaAraHandler : BaseHandler
    {
        readonly string CampaignCode = ConfigurationManager.AppSettings["ClickToCallCampaignCode"].ToString();
        readonly string CampaignCodeFree = ConfigurationManager.AppSettings["ClickToCallCampaignCodeFree"].ToString();

        public long StartCall(string ParticipantA, string ParticipantB, bool IsFree = false)
        {
            if (Com.WebServiceDefinitions.Platform == Com.WebServiceDefinitions.PlatformCode.Static)
                return 1234;

            string callRequestString = "ParticipantA:" + ParticipantA + ";ParticipantB:" + ParticipantB;
            try
            {
                var serializer = new LIB.Serialize();

                var req = new startCallRequest();
                req.campaignCode = !IsFree ? this.CampaignCode : this.CampaignCodeFree;
                req.participantA = ParticipantA;
                req.participantB = ParticipantB;

                startCallResponse resp = WebServiceLoader.TiklaKonusClient().startCall(req);

                var a = GetCallInformation(resp.callId);

                try
                {
                    callRequestString = serializer.SerializeObject(req);
                    string callInformationString = serializer.SerializeObject(a);

                    WebServiceLoader.Log(new WebServiceLog
                    {
                        Status = LogService.LogStatus.Success.ToString(),
                        Naming = Com.WebServiceDefinitions.Naming.TiklaKonusWsdl.ToString(),
                        RequestUrl = callRequestString,
                        ResponseData = callInformationString
                    });
                }
                catch (Exception) { }

                return resp.callId;
            }
            catch (Exception ex)
            {
                //LOG KAYIT
                WebServiceLoader.Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = Com.WebServiceDefinitions.Naming.TiklaKonusWsdl.ToString(),
                    RequestUrl = callRequestString,
                    ResponseData = ex.Message
                });
                return 0;
            }            
        }

        public long StartCallFree(string ParticipantA, string ParticipantB)
        {
            //ParticipantB aramak istedigimiz arkadasimizin msisdn numarasi.
            //Bu numaradan FbUser aliyoruz ve dogum günü olan arkadslarimizla match
            //ediyoruz.

            return StartCall(ParticipantA, ParticipantB, true);

        }

        public getCallInformationResponse GetCallInformation(long CallId)
        {
            string callRequestString = "getCallInformationRequest(" + CallId.ToString() + ")";

            try
            {
                getCallInformationRequest g = new getCallInformationRequest();
                g.callId = CallId;

                var resp = WebServiceLoader.TiklaKonusClient().getCallInformation(g);

                try
                {

                    var serializer = new LIB.Serialize();
                    callRequestString = serializer.SerializeObject(g);

                    string callInformationString = serializer.SerializeObject(resp);

                    WebServiceLoader.Log(new WebServiceLog
                    {
                        Status = LogService.LogStatus.Success.ToString(),
                        Naming = Com.WebServiceDefinitions.Naming.TiklaKonusWsdl.ToString(),
                        RequestUrl = callRequestString,
                        ResponseData = callInformationString
                    });
                }
                catch (Exception) { }

                return resp;
            }
            catch (Exception ex)
            {
                //LOG KAYIT
                WebServiceLoader.Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = Com.WebServiceDefinitions.Naming.TiklaKonusWsdl.ToString(),
                    RequestUrl = callRequestString,
                    ResponseData = ex.Message + " - innerEx: " + ex.InnerException
                });
                return null;
            }                        
        }

        public double GetRemainingBalance(string ParticipantA) {

            if (Com.WebServiceDefinitions.Platform == Com.WebServiceDefinitions.PlatformCode.Static)
                return 25;

            try
            {
                var req = new getRemainingBalanceRequest();
                req.campaignCode = this.CampaignCode;
                req.participantA = ParticipantA;

                balanceItem[] results = WebServiceLoader.TiklaKonusClient().getRemainingBalance(req);

                return TimeSpanUtil.ConvertMillisecondsToMinutes(Convert.ToDouble(results[0].duration));
            }
            catch (Exception)
            {
                //LOG KAYIT
                return 0;
            }

        }

        public bool IsBusy(long CallId) {
            try
            {
                getCallInformationResponse resp = GetCallInformation(CallId);
                return (
                    (resp.participantStatusA == participantStatus.UNKNOWN) &&
                    (resp.participantStatusB == participantStatus.UNKNOWN) &&
                    (resp.status == callStatus.CLOSED)
                    );
            }
            catch (Exception) { return false; }
        }
    }
}
