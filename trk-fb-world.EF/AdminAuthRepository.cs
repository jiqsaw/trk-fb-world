using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core.CustomModels;


namespace TurkcellFacebookDunyasi.EF
{
    public class AdminAuthRepository : RepositoryDefault<AdminAuth>, IAdminAuthRepository
    {
        public AdminAuthRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<AdminAuth> GetByAdminId(int AdminId)
        {
            return  _context.AdminAuth.Where(e => e.AdminId == AdminId).ToList();
        }            
    }
    
}
