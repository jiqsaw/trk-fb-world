using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.EF
{
    public class WebServiceLogRepository : RepositoryDefault<WebServiceLog>, IWebServiceLogRepository
    {
        public WebServiceLogRepository(TurkcellFacebookDunyasiDb context) : base(context) { }


        public IEnumerable<WebServiceLog> GetLiveWebServiceLog()
        {
            return _context.WebServiceLogs
                .Where(p => p.IsDeleted == false
                    )
                .OrderBy(p => p.Id).Take(1000).ToList();
        }
    }
}
