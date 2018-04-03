using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class KontrolLimitimModel : BaseModel
    {
        public ServiceManager.Models.FaturaLimitBilgisi serviceData { get; set; }

        public int Percentage
        {
            get
            {
                int percentage = (int)(100 - (100 / (serviceData.LimitAmount / (serviceData.LimitAmount - serviceData.CurrentAmount))));
                return (percentage <= 0) ? 0 : percentage;
            }
        }
    }
}