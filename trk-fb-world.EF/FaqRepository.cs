using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace TurkcellFacebookDunyasi.EF
{
    public class FaqRepository : Repository<Faq>, IFaqRepository
    {
        public FaqRepository(TurkcellFacebookDunyasiDb context) : base(context) { }
    }
    
}
