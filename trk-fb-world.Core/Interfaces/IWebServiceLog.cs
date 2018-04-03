using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core
{
    public interface IWebServiceLog
    {
        int PlatformCode { get; set; }
        string RequestUrl { get; set; }
        string ResponseData { get; set; }
    }
}
