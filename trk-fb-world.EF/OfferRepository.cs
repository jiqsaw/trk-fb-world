using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.EF
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        public OfferRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<Offer> GetLiveOffers()
        {
            return _context.Offer
                .Where(p => p.IsDeleted == false &&
                    (p.StartDate == null || (p.StartDate <= DateTime.Now)) &&
                    (p.EndDate == null || (p.EndDate > DateTime.Now))
                    )
                .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                .ThenBy(p => p.Id).ToList();
        }

        public IEnumerable<Offer> GetAllPublishedByType(Parameter.OfferType OfferTypeCode)
        {
            return _context.Offer.Where(p => p.IsActive == true && p.OfferTypeCode == (int)OfferTypeCode && p.IsDeleted == false &&
                (p.StartDate == null || (p.StartDate <= DateTime.Now)) &&
                 (p.EndDate == null || (p.EndDate > DateTime.Now)))
                .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                .ThenBy(p => p.Id).ToList();
        }

        public IEnumerable<Offer> GetAllPublishedByTypeTake(Parameter.OfferType OfferTypeCode, int Take)
        {
            return _context.Offer.Where(p => p.IsActive == true && p.OfferTypeCode == (int)OfferTypeCode && p.IsDeleted == false &&
                    (p.StartDate == null || (p.StartDate <= DateTime.Now)) &&
                    (p.EndDate == null || (p.EndDate > DateTime.Now)))
                .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                .ThenBy(p => p.Id).Take(Take).ToList();
        }
    }
}