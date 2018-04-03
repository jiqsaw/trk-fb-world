using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class PaketVeServis : BaseServiceModel
    {
        public IList<Partials.Services> Services { get; set; }

        public PaketVeServis()
        {
            Services = new List<Partials.Services>();
        }
    }
}
