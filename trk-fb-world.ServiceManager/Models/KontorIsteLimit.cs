using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class KontorIsteLimit
    {
        public string RequestCountLimit { get; set; }
        public string CounterAmountLimit { get; set; }
        public int Percentage
        {
            get
            {
                return (int)(100 - (100 / (Convert.ToDouble(CounterAmountLimit) / (Convert.ToDouble(CounterAmountLimit) - Convert.ToDouble(RequestCountLimit)))));
            }
        }
    }
}
