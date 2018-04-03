using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class TiklaAraModel : BaseModel
    {
        public bool HasIncomingCall { get; set; }
        public bool HasOutgoingCall { get; set; }
        public bool ShowFilterAll { get { return ((HasOutgoingCall) || (HasIncomingCall)); } }
    }
}