using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class FaturalarimModel : BaseModel
    {
        public IList<ServiceManager.Models.Faturalarim> serviceDataList { get; set; }

        public string jsObjectData { 
            get {

                var strItem = "{ 'invoiceNumber': '# INVOICE_NUMBER #', 'period': '# PERIOD #', 'month': '# MONTH #', 'rate': '# RATE #', 'amount': '# AMOUNT #', 'invoiceDate': '# INVOICE_DATE #', 'paymentLastDate': '# PAYMENT_LAST_DATE #' },";

                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                foreach (var item in serviceDataList)
                {
                    sb.Append(
                        strItem.Replace("# INVOICE_NUMBER #", item.InvoiceNumber)
                                .Replace("# PERIOD #", item.Period)
                                .Replace("# MONTH #", item.MonthDisplay)
                                .Replace("# RATE #", item.Rate.ToString())
                                .Replace("# AMOUNT #", LIB.FormatHelper.PriceToString(item.Amount))
                                .Replace("# INVOICE_DATE #", item.InvoiceDate.ToString())
                                .Replace("# PAYMENT_LAST_DATE #", item.PaymentLastDate.ToShortDateString())
                    );
                }
                sb.Append("]");
                return sb.ToString().Replace(",]", "]");
            }
        }
    }
}