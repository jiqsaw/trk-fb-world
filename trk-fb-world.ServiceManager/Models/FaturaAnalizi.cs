using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class FaturaAnalizi
    {
        public string Description { get; set; }
        public double Amount { get; set; }

        public double Rate;
        public string RateDisplay { get { return String.Format("{0:0.00}", Rate); } }
    }
}