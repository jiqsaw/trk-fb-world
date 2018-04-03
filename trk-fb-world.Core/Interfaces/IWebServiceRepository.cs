using System.Collections.Generic;

namespace TurkcellFacebookDunyasi.Core.Interfaces
{
    public interface IWebServiceRepository : IRepositoryDefault<WebService> 
    {
        IEnumerable<WebService> GetAllPublishedByPlatform(Com.WebServiceDefinitions.PlatformCode PlatformCode);
        string GetWebServiceUrl(string Naming);
    }
}