using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class CallDetailModel
    {
        public string Description { get; set; }
        public string OpAddress { get; set; }
        public string Amount { get; set; }
        public string DataVolume { get; set; }
        public string DateDisplay { get; set; }

        public int? UserId { get; set; }
        public string FbId { get; set; }
        public bool IsClickToCallInvisible { get; set; }
        public bool IsClickToCallBlock { get; set; }
        public string FirstNameView { get; set; }
        public string LastNameView { get; set; }
        public string PictureLink { get; set; }
    }
}