using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.Admin.Models
{
    public class PanelMenuGroupModel
    {
        public string GroupDescription { get; set; }
        public List<PanelMenuModel> List { get; set; }
    }
}