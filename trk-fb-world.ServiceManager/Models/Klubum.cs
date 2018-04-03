using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class Klubum : BaseServiceModel
    {
        public IList<Partials.Clubs> Clubs { get; set; }

        public Klubum()
        {
            Clubs = new List<Partials.Clubs>();
        }
    }
}
