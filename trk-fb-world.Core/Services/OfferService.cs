using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class OfferService
    {
        private readonly IOfferRepository repository;

        public OfferService(IOfferRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Offer> GetLiveOffers()
        {
            return repository.GetLiveOffers();
        }

        public IEnumerable<Offer> GetAllPublishedByType(Parameter.OfferType OfferTypeCode)
        {
            return repository.GetAllPublishedByType(OfferTypeCode);
        }

        public IEnumerable<Offer> GetAllPublishedByType(Parameter.OfferType OfferTypeCode, int Take)
        {
            return repository.GetAllPublishedByTypeTake(OfferTypeCode, Take);
        }
    }   

}
