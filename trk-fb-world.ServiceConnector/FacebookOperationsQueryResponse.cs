using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceConnector
{
    public class FacebookOperationsQueryResponse
    {
        public IList<TopCalledNumber> TopCalledNumbers { get; set; }

        public FacebookOperationsQueryResponse()
        {
            TopCalledNumbers = new List<TopCalledNumber>();
        }
    }
}
