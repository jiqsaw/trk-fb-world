using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core.Interfaces
{
    public interface IWebServiceLogRepository : IRepositoryDefault<WebServiceLog>
    {
        IEnumerable<WebServiceLog> GetLiveWebServiceLog();
    }
}
