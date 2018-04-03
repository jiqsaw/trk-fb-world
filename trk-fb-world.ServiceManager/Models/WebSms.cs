using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceManager.Models.Partials;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class WebSms : BaseServiceModel
    {
        public WebSms()
        {
            Recipients = new List<Recipient>();
        }

        public int _Balance;

        //Balance Query Datalari
        public string Msisdn { get; set; }
        public int Balance { get { return (_Balance < 0) ? 0 : _Balance; } set { _Balance = value; } }
        public int FreeTotal { get; set; }
        public string Error { get; set; }

        //Message Send Datalari
        public string Sender { get; set; }
        public string Message { get; set; }
        public IList<Recipient> Recipients { get; set; }
    }
}
