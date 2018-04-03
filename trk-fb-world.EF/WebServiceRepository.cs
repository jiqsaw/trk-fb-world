using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TurkcellFacebookDunyasi.EF
{
    public class WebServiceRepository : RepositoryDefault<WebService>, IWebServiceRepository
    {
        public WebServiceRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<WebService> GetAllPublishedByPlatform(Com.WebServiceDefinitions.PlatformCode PlatformCode)
        {
            return _context.WebService.Where(p => p.PlatformCode == (int)PlatformCode).ToList();
        }

        public string GetWebServiceUrl(string Naming)
        {
            return _context.WebService.Where(p =>
                p.IsDeleted == false &&
                p.Naming == Naming &&
                p.PlatformCode == (int)Com.WebServiceDefinitions.Platform).Take(1).Single().Url;
        }

    }    
}