using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class SmsGonderResultModel
    {
        public int? UserId { get; set; }
        public string FbId { get; set; }
        public string PictureLink { get; set; }
        public string Msisdn { get; set; }
        public string FirstNameView { get; set; }
        public string LastNameView { get; set; }

        public string Charge { get; set; }
        public string Status { get; set; }
    }
}