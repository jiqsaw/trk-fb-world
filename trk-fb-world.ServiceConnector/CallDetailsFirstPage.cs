using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceConnector
{
    public class CallDetailsFirstPage
    {
        [JsonProperty("isSubscriptionActive")]
        public bool IsSubscriptionActive { get; set; }
    }
}
