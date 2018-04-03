using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models.Partials
{
    public class FreeUnits
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string UnitTypeDesc { get; set; }
        public string ZoneTypeDesc { get; set; }
        public string CreditUnit { get; set; }
        public string EndDate { get; set; }
        public double UsedBalance { get { return TotalBalance - AvailableBalance; } }
        public double AvailableBalance { get; set; }
        public double TotalBalance { get; set; }        

        public int Percentage { 
            get {                
                return (int)Math.Round((100 - (100 / (TotalBalance / (TotalBalance - UsedBalance)))));
            } 
        }
    }
}