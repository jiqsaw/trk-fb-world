using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurkcellFacebookDunyasi.Core
{
    public class WebServiceLog : BaseLog, ILog, IWebServiceLog
    {
        [EnumDataType(typeof(TurkcellFacebookDunyasi.Com.WebServiceDefinitions.Naming))]
        public int PlatformCode { get; set; }
        
        public string RequestUrl { get; set; }
        
        [DataType(DataType.Text)]
        public string ResponseData { get; set; }
    }
}
