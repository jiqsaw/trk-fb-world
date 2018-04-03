using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Logger;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis;
using TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo;
using TurkcellFacebookDunyasi.ServiceManager.Models;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class FaturalarimHandler : BaseHandler
    {
        public GuncelFaturaBilgisi Data { get; set; }

        public FaturalarimHandler()
        {
            Data = new GuncelFaturaBilgisi();
        }

        public GuncelFaturaBilgisi PrepareData()
        {
            //GUNCEL FATURA BILGILERI
            try
            {
                CurrentInvoiceQueryResponse InvoiceQueryObj = WebServiceLoader.CurrentInvoiceQuery();
                Data.OpenAmount = InvoiceQueryObj.CurrentInvoice.Invoice.GetOpenAmount;

                //FATURA KESIM TARIHI
                BillCycleQueryResponse BillCycleQueryObj = WebServiceLoader.BillCycleQuery();
                Data.LastBillCycleDate = DateTime.Parse(BillCycleQueryObj.BillCycleQuery.LastBillCycleDate);

                return Data;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public IList<Faturalarim> GetBillDatas(string Msisdn)
        {
            string srvRequestString = "GetInvoceList(" + Msisdn + ")";
            try
            {
                invoiceList data;

                if (LIB.Util.GetConfigValue("WebServicePlatform") == ((int)WebServiceDefinitions.PlatformCode.Static).ToString())
                    data = ServiceConnector.Dummy.MobileBillInfo.FillDummyData();
                else
                {
                    var srv = WebServiceLoader.MobileBillInfoClient();
                    data = srv.GetInvoceList(Msisdn);                    
                }

                double Total = 0;
                IList<Faturalarim> modelList = new List<Faturalarim>();
                foreach (var item in data.invoicelist)
                {
                    if ((int)item.invoiceType == ((int)Parameter.InvoiceType.Single))
                    {
                        var model = new Faturalarim();
                        model.Amount = item.invoiceAmount;
                        model.InvoiceDate = item.invoiceDate;
                        model.IsInvoiceOpen = item.invoiceOpen;
                        model.PaymentLastDate = item.paymentLastDate;
                        model.Period = item.period;
                        model.InvoiceNumber = item.invoiceNumber;                                                

                        modelList.Add(model);

                        Total += model.Amount;
                    }
                }

                var topAmount = modelList.OrderByDescending(p => p.Amount).Take(1).FirstOrDefault().Amount;

                foreach (var item in modelList)
                    item.Rate = (int)((item.Amount * (double)100) / topAmount);

                try
                {
                    

                    var serializer = new LIB.Serialize();
                    string srvResponseString = serializer.SerializeObject(data);

                    WebServiceLoader.Log(new WebServiceLog
                    {
                        Status = LogService.LogStatus.Success.ToString(),
                        Naming = Com.WebServiceDefinitions.Naming.MobileBillInfoServiceWsdl.ToString(),
                        RequestUrl = srvRequestString,
                        ResponseData = srvResponseString
                    });
                }
                catch (System.Exception) { }

                return modelList.OrderBy(p => p.InvoiceDate).ToList();
            }
            catch (System.Exception ex)
            {
                WebServiceLoader.Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = Com.WebServiceDefinitions.Naming.MobileBillInfoServiceWsdl.ToString(),
                    RequestUrl = srvRequestString,
                    ResponseData = ex.Message
                });
                
                return null;
            }
        }

        public IList<FaturaAnalizi> GetBillAnalysis(string Msisdn, string InvoiceDate) {
            string srvRequestString = "GetInvoiceAnalysisList(" + Msisdn + ", " + InvoiceDate + ")";
            try
            {
                invoiceLevel1[] data;
                if (LIB.Util.GetConfigValue("WebServicePlatform") == ((int)WebServiceDefinitions.PlatformCode.Static).ToString())
                    data = ServiceConnector.Dummy.MobileBillAnalysis.FillDummyData();
                else
                {
                    var srv = WebServiceLoader.MobileBillAnalysisClient();
                    data = srv.GetInvoiceAnalysisList(Msisdn, InvoiceDate).level1List;                         
                }

                double Total = 0;
                IList<FaturaAnalizi> modelList = new List<FaturaAnalizi>();
                foreach (var item in data)
                {
                    var model = new FaturaAnalizi();
                    model.Description = item.description;
                    model.Amount = item.amount;
                    modelList.Add(model);

                    if (model.Amount >= 0)
                        Total += model.Amount;
                }

                foreach (var item in modelList)
                    item.Rate = item.Amount <= 0 ? 0 : ((item.Amount * (double)100) / Total);
                
                #region :: LOG ::
                try
                {
                    var serializer = new LIB.Serialize();
                    string srvResponseString = serializer.SerializeObject(data);

                    WebServiceLoader.Log(new WebServiceLog
                    {
                        Status = LogService.LogStatus.Success.ToString(),
                        Naming = Com.WebServiceDefinitions.Naming.MobileBillAnalysisServiceWsdl.ToString(),
                        RequestUrl = srvRequestString,
                        ResponseData = srvResponseString
                    });
                }
                catch (System.Exception) { }
                #endregion

                return modelList;
            }
            catch (System.Exception ex)
            {
                WebServiceLoader.Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = Com.WebServiceDefinitions.Naming.MobileBillInfoServiceWsdl.ToString(),
                    RequestUrl = srvRequestString,
                    ResponseData = ex.Message
                });

                return null;
            }

        }

        public int Test() {
            invoiceList data;
            var srv = WebServiceLoader.MobileBillInfoClient();
            data = srv.GetInvoceList("5321528280");
            return data.invoicelist.Count();
        }

    }
}
