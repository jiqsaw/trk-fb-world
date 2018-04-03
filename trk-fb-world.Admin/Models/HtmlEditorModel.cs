using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.Admin.Models
{
    public class HtmlEditorModel
    {
        public string Expression { get; set; }
        public string ErrorMessageRsrcKey { get; set; }
        public string Value { get; set; }
        
        public int Height { get; set; }
    }
}