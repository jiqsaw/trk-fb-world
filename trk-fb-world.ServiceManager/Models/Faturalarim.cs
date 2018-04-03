using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class Faturalarim
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string MonthDisplay { get { return String.Format("{0:y}", InvoiceDate); } }
        public int Rate { get; set; }
        public double Amount { get; set; }
        public bool IsInvoiceOpen { get; set; }
        public string Period { get; set; }
        public DateTime PaymentLastDate { get; set; }        
    }
}
