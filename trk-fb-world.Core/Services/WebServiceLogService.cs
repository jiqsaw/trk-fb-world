using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class WebServiceLogService
    {
        private readonly IWebServiceLogRepository repository;

        public WebServiceLogService(IWebServiceLogRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<WebServiceLog> GetLiveWebServiceLog()
        {
            return repository.GetLiveWebServiceLog();
        }


    }   

}
