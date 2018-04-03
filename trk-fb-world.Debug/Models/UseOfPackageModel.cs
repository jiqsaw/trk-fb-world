using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class UseOfPackageModel
    {
        public string PackageName { get; set; }
        public int RemainingDays { get; set; }
        public int VoiceRate { get; set; }
        public int DataRate { get; set; }
    }
}