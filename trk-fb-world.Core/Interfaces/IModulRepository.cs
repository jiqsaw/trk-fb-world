using TurkcellFacebookDunyasi.Core.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core.Interfaces
{
    public interface IModulRepository : IRepository<Modul>
    {

        IEnumerable<Modul> GetLiveModuls();
        IEnumerable<Modul> GetListForAdmin();
        IEnumerable<Modul> GetAdminModuls(int AdminId);
    }
}