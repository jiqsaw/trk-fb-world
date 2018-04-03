using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class KalanKullanimBilgisi : BaseServiceModel
    {
        public IList<Partials.FreeUnits> FreeUnits { get; set; }
        public string ErrorMessage { get; set; }

        public KalanKullanimBilgisi()
        {
            FreeUnits = new List<Partials.FreeUnits>();
        }
    }
}
