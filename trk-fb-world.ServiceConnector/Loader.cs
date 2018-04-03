using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Security.Cryptography;

using TurkcellFacebookDunyasi.Com;
using TurkcellFacebookDunyasi.EF;

using TurkcellFacebookDunyasi.ServiceConnector.TiklaKonus;
using TurkcellFacebookDunyasi.ServiceConnector.BigLdap;
using TurkcellFacebookDunyasi.ServiceConnector.BigLdapUpdate;

using TurkcellFacebookDunyasi.Logger;
using TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo;
using TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis;
using Newtonsoft.Json;
using TurkcellFacebookDunyasi.Core;

using System.Web;
using TurkcellFacebookDunyasi.Com.Enums;
using System.Collections.Specialized;



namespace TurkcellFacebookDunyasi.ServiceConnector
{
    public sealed class Loader : BaseLoader
    {

        #region Structure

        private static Loader _Loader;
        //private static object syncRoot = new Object();

        private LogService _logger;

        public string PageToken { get; set; }
        public string TcellSession { get; set; }

        private Loader()
        {
            _logger = LogService.GetInstance();
        }

        //Thread senkronizasyonu için lock kullaniyoruz ve lazy initialization ile de
        //nesnenin gereksiz yaratilmasini onluyoruz. Loader classimiz boylece hem thread-safe
        //hem de lazy-loadable oluyor.
        public static Loader GetInstance()
        {
            if (_Loader == null)
            {
                /*lock (syncRoot)
                {
                    if (_Loader == null)
                        _Loader = new Loader();
                }*/
                _Loader = new Loader();
            }

            return _Loader;
        }

        public void Log(WebServiceLog log)
        {
            log.IP = CurrentRequestIP;
            log.UserId = SessionUser.Id;
            log.Msisdn = SessionUser.Msisdn;
            log.FbId = SessionUser.FbId;
            log.TcellSession = this.Sid;
            log.PlatformCode = (int)WebServiceDefinitions.Platform;

            //Web Service Loglamasi
            _logger.Log<WebServiceLog>(log);

            //Web Servis cagrisi loglamasi (transaction)
            _logger.Log<TransactionLog>(new TransactionLog
            {
                Status = LogService.LogDefinitions.WebServiceCall.ToString(),
                Naming = log.Naming,
                Details = "SERVICE_LOG_ID:" + log.Id,
                FbId = log.FbId,
                IP = log.IP,
                Msisdn = log.Msisdn,
                TcellSession = log.TcellSession,
                UserId = log.UserId
            });
        }

        private string WrapInvalidJsonResult(string invalidJsonResult, string descriptor)
        {
            if (invalidJsonResult.StartsWith("["))
            {
                return "{\"" + descriptor + "\":" + invalidJsonResult + "}";
            }

            return invalidJsonResult;
        }

        private UserFb SessionUser
        {
            get
            {
                string sessionUserData = HttpContext.Current.Session["SessionUser"].ToString();
                var serializer = new LIB.Serialize();

                return (UserFb)serializer.DeserializeObject(sessionUserData, typeof(UserFb));
            }
        }

        private string CurrentRequestIP
        {
            get
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
        }

        #endregion

        private NameValueCollection GetDefaultParameters(bool forceEmptyCollection=false)
        {
            var defaultValues = new NameValueCollection();

            if (!forceEmptyCollection)
            {
                //Bu değer cookie ile gönderiliyor, querystringde gitmesine gerek yok
                //defaultValues.Add("TurkcellSession", TcellSession);

                //Bu değerin querystring e eklenmesi zorunlu değil, csi loglarında filtreleme için ihtiyaç olur diye her ihtimale karşın ekleniyor
                defaultValues.Add("pageToken", PageToken);
            }

            return defaultValues;
        }

        public SsoLoginQuery SsoLoginQuery(string msisdn)
        {
            string csiEntranceId = "1301";
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.SsoLogin);

            var queryString = GetDefaultParameters(true);
            queryString.Add("csiEntranceId",csiEntranceId);
            queryString.Add("msisdn",msisdn);

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            //string requestUrl = String.Format(parameterlessUrl + "?csiEntranceId={0}&msisdn={1}", csiEntranceId, msisdn);
            
            //Statik servisler CSI parametrelerine gerek duymuyor.
            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl, false);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.SsoLogin.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<SsoLoginQuery>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.SsoLogin.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public CallDetailsQueryResponse CallDetailsQuery(string invoicePeriod, Parameter.CustomerType customerType = Parameter.CustomerType.flat)
        {
            string parameterlessUrl = "";

            switch (customerType)
            {
                case Parameter.CustomerType.None:
                    parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.CallDetailsQuery);
                    break;
                case Parameter.CustomerType.flat:
                    parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.CallDetailsQuery);
                    break;
                case Parameter.CustomerType.corp:
                    parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.CorporateCallDetailsQuery);
                    break;
            }

            var queryString = GetDefaultParameters();
            queryString.Add("referrer", "monthselect");
            queryString.Add("period", invoicePeriod);

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.CallDetailsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<CallDetailsQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.CallDetailsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        //prepaidCallDetails servisi 2 adimli servis.
        //bu bilgi daha sonradan geldigi icin ilk adimi bu asamada
        //implemente etmek yerine "gecici" olarak cevap almadan query atiyoruz.
        public CallDetailsQueryResponse CallDetailsSubscriptionQuery(string userType)
        {
            string parameterlessUrl = userType == Parameter.UserType.prep.ToString() ? this.GetUrl(WebServiceDefinitions.Naming.PrepaidCallDetailsQuery) : this.GetUrl(WebServiceDefinitions.Naming.CallDetailsQuery);

            var queryString = GetDefaultParameters();
            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);
            
            if (WebServiceDefinitions.Platform != WebServiceDefinitions.PlatformCode.Static)
            {
                try
                {
                    string json = this.GetJson(requestUrl);
                    Log(new WebServiceLog
                    {
                        Status = LogService.LogStatus.Success.ToString(),
                        Naming = WebServiceDefinitions.Naming.CallDetailsSubscription.ToString(),
                        RequestUrl = requestUrl,
                        ResponseData = json
                    });

                    return ParseJsonObject<CallDetailsQueryResponse>(json);
                }
                catch (System.Exception ex)
                {
                    Log(new WebServiceLog
                    {
                        Status = LogService.LogStatus.Failure.ToString(),
                        Naming = WebServiceDefinitions.Naming.CallDetailsSubscription.ToString(),
                        RequestUrl = requestUrl,
                        ResponseData = ex.Message
                    });
                    return null;
                }
            }

            //Statik çağrılarda her daim true gönderelim
            return new CallDetailsQueryResponse { CallDetailsFirstPage = new CallDetailsFirstPage { IsSubscriptionActive = true } };
        }

        public CallDetailsQueryResponse CallDetailsQuery(string startDate, string endDate)
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.PrepaidCallDetailsQuery);

            var queryString = GetDefaultParameters();
            queryString.Add("referrer", "monthselect");
            queryString.Add("startdate", startDate);
            queryString.Add("enddate", endDate);

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            //prepaidCallDetails icin gerekli 1. asama parametresiz istegi gonderiyoruz.
            //PrepaidCallDetailsPreQuery();

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.PrepaidCallDetailsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<CallDetailsQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.PrepaidCallDetailsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public TariffQueryResponse TariffQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.TariffQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.TariffQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<TariffQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.TariffQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public FreeServicesQueryResponse FreeServicesQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.FreeServicesQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.FreeServicesQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<FreeServicesQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.FreeServicesQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public PrepaidFreeServicesQueryResponse PrepaidFreeServicesQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.PrepaidFreeServicesQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.PrepaidFreeServicesQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<PrepaidFreeServicesQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.PrepaidFreeServicesQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public FacebookOperationsQueryResponse TopCalledNumbersQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.FacebookOperationsQuery);

            var queryString = GetDefaultParameters();
            queryString.Add("referrer", "topCalledNumbers");

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.FacebookOperationsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                //BU SERVIS JSON ILE PARSE EDILEBILECEK BIR RESULT DONMEDIGI ICIN
                //STRING SPLIT UYGULUYORUZ
                FacebookOperationsQueryResponse response = new FacebookOperationsQueryResponse();

                string rawData = json.Substring(1, json.Length - 2);
                if (rawData != "")
                {
                    string[] topCalledNumbersCollection = rawData.Split(',');
                    foreach (var topCalledNumberRaw in topCalledNumbersCollection)
                    {
                        string[] topCalledNumber = topCalledNumberRaw.Split(':');
                        response.TopCalledNumbers.Add(new TopCalledNumber
                        {
                            Msisdn = topCalledNumber[0].Substring(1, topCalledNumber[0].Length - 2),
                            Order = Convert.ToDouble(topCalledNumber[1])
                        });
                    }
                }

                return response;

            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.FacebookOperationsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public FacebookOperationsQueryResponse TopCalledNumbersQuery(string invoiceNumber)
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.FacebookOperationsQuery);

            var queryString = GetDefaultParameters();
            queryString.Add("referrer", "topCalledNumbers");
            queryString.Add("invno", invoiceNumber);

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.FacebookOperationsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                //BU SERVIS JSON ILE PARSE EDILEBILECEK BIR RESULT DONMEDIGI ICIN
                //STRING SPLIT UYGULUYORUZ
                FacebookOperationsQueryResponse response = new FacebookOperationsQueryResponse();

                string rawData = json.Substring(1, json.Length - 2);
                if (rawData != "")
                {
                    string[] topCalledNumbersCollection = rawData.Split(',');
                    foreach (var topCalledNumberRaw in topCalledNumbersCollection)
                    {
                        string[] topCalledNumber = topCalledNumberRaw.Split(':');
                        response.TopCalledNumbers.Add(new TopCalledNumber
                        {
                            Msisdn = topCalledNumber[0].Substring(1, topCalledNumber[0].Length - 2),
                            Order = Convert.ToDouble(topCalledNumber[1])
                        });
                    }
                }

                return response;

            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.FacebookOperationsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public CurrentInvoiceQueryResponse CurrentInvoiceQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.CurrentInvoiceQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.CurrentInvoiceQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<CurrentInvoiceQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.CurrentInvoiceQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public UsagePeriodDisplayQueryResponse UsagePeriodDisplayQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.UsagePeriodDisplayQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.UsagePeriodDisplayQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<UsagePeriodDisplayQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.UsagePeriodDisplayQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public KontorMetreQueryResponse KontormetreQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.KontormetreQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontormetreQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<KontorMetreQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontormetreQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public KontorIsteLimitQueryResponse KontorIsteLimitQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.KontorIsteLimitQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorIsteLimitQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<KontorIsteLimitQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorIsteLimitQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public CreditTransferResponse CreditTransferQueryStep1()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.KontorGonderQuery);

            var queryString = GetDefaultParameters();
            
            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl+"1";
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorGonderQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<CreditTransferResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorGonderQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public CreditTransferResponse CreditTransferQueryStep2(string bNumber, int creditIndex)
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.KontorGonderQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl+"2";
            }

            try
            {
                var postData = new System.Collections.Specialized.NameValueCollection();
                postData.Add("bNumber", bNumber);
                postData.Add("creditIndex", creditIndex.ToString());
                string json = WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static ? this.GetJson(requestUrl) : this.GetJsonFromPost(requestUrl, postData);

                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorGonderQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<CreditTransferResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorGonderQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public CreditTransferResponse CreditTransferQueryStep3()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.KontorGonderQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl+"3";
            }

            try
            {
                var postData = new System.Collections.Specialized.NameValueCollection();
                string json = WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static ? this.GetJson(requestUrl) : this.GetJsonFromPost(requestUrl, postData);

                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorGonderQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<CreditTransferResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorGonderQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public KontorIsteQueryResponse KontorIsteQuery(string toTelNo, int transferAmount)
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.KontorIsteQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            var postData = new System.Collections.Specialized.NameValueCollection();
            postData.Add("toTelNo", toTelNo);
            postData.Add("transferAmount", transferAmount.ToString());

            try
            {
                string json = WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static ? this.GetJson(requestUrl) : this.GetJsonFromPost(requestUrl, postData);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorIsteQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<KontorIsteQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.KontorIsteQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });

                return null;
            }
        }

        public BillCycleQueryResponse BillCycleQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.BillCycleQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);
           

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.BillCycleQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<BillCycleQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.BillCycleQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public FaturaLimitSubsResponse FaturaLimitSubsQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.FaturaLimitSubsQuery);

            var queryString = GetDefaultParameters();

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.FaturaLimitSubsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<FaturaLimitSubsResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.FaturaLimitSubsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public CustomerClubsQuery CustomerClubsQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.CustomerClubsQuery);

            var queryString = GetDefaultParameters();
            queryString.Add("referrer", "club");

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = WrapInvalidJsonResult(this.GetJson(requestUrl), "clubList");
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.CustomerClubsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<CustomerClubsQuery>(json);
            }
            catch (JsonSerializationException)
            {
                //clubList:-1 gelmesi durumunda yasaniyor genelde bu hata.
                return ParseJsonObject<CustomerClubsQuery>("{\"clubList\":[]}");
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.CustomerClubsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public CustomerSubscriptionsQuery CustomerSubscriptionsQuery()
        {
            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.CustomerSubsQuery);

            var queryString = GetDefaultParameters();
            queryString.Add("referrer", "service");

            string requestUrl = this.GenerateRequestUrl(parameterlessUrl, queryString);           

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = WrapInvalidJsonResult(this.GetJson(requestUrl), "customerSubscriptions");
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.CustomerSubsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });

                return ParseJsonObject<CustomerSubscriptionsQuery>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.CustomerSubsQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        /* WebSMS Servisleri */

        public WebSmsSendMessageResponse WebSmsSendMessageQuery(string senderMsisdn, string[] recipients, string message)
        {
            long rand = DateTime.Now.Ticks;
            string recipientList = String.Join("", recipients);
            string messageToHash = WebServiceDefinitions.WebSMSAppId + senderMsisdn + message + recipientList + rand;
            string token = HashWithHmac(messageToHash, WebServiceDefinitions.WebSMSSecretKey);

            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.WebSMSMessageQuery);
            string requestUrl = String.Format(parameterlessUrl + "?action={0}", "sendsms");

            var postData = new System.Collections.Specialized.NameValueCollection();
            postData.Add("appId", WebServiceDefinitions.WebSMSAppId);
            postData.Add("rand", rand.ToString());
            postData.Add("token", token);
            postData.Add("msisdn", senderMsisdn);
            postData.Add("message", message);

            
            //foreach (var recipient in recipients)
            //{
            //    postData.Add("recipient[]", recipient);
            //}

            //PHP baska turlu multiple post datayi cozumlemiyormus! -.-'
            string recipientsQueryString = "";
            foreach (var recipient in recipients)
            {
                recipientsQueryString += "&recipient[]=" + recipient;
            }

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static ? this.GetJson(requestUrl) : this.GetJsonFromPost(requestUrl, postData);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.WebSMSMessageQuery.ToString(),
                    RequestUrl = requestUrl + "&" + GenerateQueryStringFromPostData(postData) + recipientsQueryString,
                    ResponseData = json
                });
                return ParseJsonObject<WebSmsSendMessageResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.WebSMSMessageQuery.ToString(),
                    RequestUrl = requestUrl + "&" + GenerateQueryStringFromPostData(postData),
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public WebSmsSendMessageResponse WebSmsSendMessageQuery(string senderMsisdn, string recipientMsisdn, string message)
        {
            long rand = DateTime.Now.Ticks;
            string messageToHash = WebServiceDefinitions.WebSMSAppId + senderMsisdn + message + recipientMsisdn + rand;
            string token = HashWithHmac(messageToHash, WebServiceDefinitions.WebSMSSecretKey);

            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.WebSMSMessageQuery);
            string requestUrl = String.Format(parameterlessUrl + "?action={0}", "sendsms");

            var postData = new System.Collections.Specialized.NameValueCollection();
            postData.Add("appId", WebServiceDefinitions.WebSMSAppId);
            postData.Add("rand", rand.ToString());
            postData.Add("token", token);
            postData.Add("msisdn", senderMsisdn);
            postData.Add("message", message);
            postData.Add("recipient", recipientMsisdn);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static ? this.GetJson(requestUrl) : this.GetJsonFromPost(requestUrl, postData);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.WebSMSMessageQuery.ToString(),
                    RequestUrl = requestUrl + "&" + GenerateQueryStringFromPostData(postData),
                    ResponseData = json
                });
                return ParseJsonObject<WebSmsSendMessageResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.WebSMSMessageQuery.ToString(),
                    RequestUrl = requestUrl + "&" + GenerateQueryStringFromPostData(postData),
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public WebSmsBalanceQueryResponse WebSmsBalanceQuery(string msisdn)
        {
            long rand = DateTime.Now.Ticks;
            string messageToHash = WebServiceDefinitions.WebSMSAppId + msisdn + rand;
            string token = HashWithHmac(messageToHash, WebServiceDefinitions.WebSMSSecretKey);

            string parameterlessUrl = this.GetUrl(WebServiceDefinitions.Naming.WebSMSBalanceQuery);
            string requestUrl = String.Format(parameterlessUrl + "?action=balance&appId={0}&rand={1}&msisdn={2}&token={3}", WebServiceDefinitions.WebSMSAppId, rand, msisdn, token);

            if (WebServiceDefinitions.Platform == WebServiceDefinitions.PlatformCode.Static)
            {
                requestUrl = parameterlessUrl;
            }

            try
            {
                string json = this.GetJson(requestUrl);
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = WebServiceDefinitions.Naming.WebSMSBalanceQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = json
                });
                return ParseJsonObject<WebSmsBalanceQueryResponse>(json);
            }
            catch (System.Exception ex)
            {
                Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = WebServiceDefinitions.Naming.WebSMSBalanceQuery.ToString(),
                    RequestUrl = requestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        //WebSMS Servisi, HASH Olusturma prosedürü
        private string HashWithHmac(string message, string key)
        {
            
            //HMAC-SHA1 Hashlemesi kullaniyoruz.
            var keyBytes = RequestEncoding.GetBytes(key);
            var algorithm = new HMACSHA1(keyBytes);
            var messageBytes = RequestEncoding.GetBytes(message);

            algorithm.ComputeHash(messageBytes);

            return ByteToString(algorithm.Hash);
        }

        private string ByteToString(byte[] bytes)
        {
            string sBinary = "";
            for (int i = 0; i < bytes.Length; i++)
                sBinary += bytes[i].ToString("X2");

            //Eger degeri ToLowerInvariant() ile küçük harfe cevirmez isek
            //php tarafi token'i gecersiz sayiyor. Ayni token olmasina ragmen :p
            return sBinary.ToLowerInvariant();
        }

        public CallPortClient TiklaKonusClient()
        {
            return new CallPortClient();    
        }

        public GetPersonWsClient GetPersonClient()
        {
            return new GetPersonWsClient();
        }

        public UpdatePersonWsClient UpdatePersonClient()
        {
            return new UpdatePersonWsClient();
        }

        //Asagidaki servisleri explicit declare etmek durumundayiz. Using ile alirsak System.Exception
        //ile conflict veriyor.

        public MobileBillInfoClient MobileBillInfoClient()
        {
            return new MobileBillInfoClient();
        }

        public MobileBillAnalysisClient MobileBillAnalysisClient()
        {
            return new MobileBillAnalysisClient();
        }

        private string GenerateQueryStringFromPostData(System.Collections.Specialized.NameValueCollection postData)
        {
            List<string> items = new List<string>();
            foreach (string name in postData)
            {
                items.Add(String.Concat(name, "=", postData[name]));
            }

            return String.Join("&", items.ToArray());
        }
    }
}