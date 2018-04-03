using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class WebServiceService
    {
        private readonly IWebServiceRepository repository;

        public WebServiceService(IWebServiceRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<WebService> GetAllPublishedByPlatform(Com.WebServiceDefinitions.PlatformCode PlatformCode)
        {
            return repository.GetAllPublishedByPlatform(PlatformCode);
        }

        public string GetWebServiceUrl(Com.WebServiceDefinitions.Naming Naming)
        {
            return repository.GetWebServiceUrl(Naming.ToString());
        }

    }   

}
