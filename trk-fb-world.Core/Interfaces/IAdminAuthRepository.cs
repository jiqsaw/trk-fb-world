using TurkcellFacebookDunyasi.Core.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core.Interfaces
{
    public interface IAdminAuthRepository : IRepositoryDefault<AdminAuth>
    {
        IEnumerable<AdminAuth> GetByAdminId(int AdminId);        
    }
}
