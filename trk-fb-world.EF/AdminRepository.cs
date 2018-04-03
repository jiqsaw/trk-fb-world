using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;

namespace TurkcellFacebookDunyasi.EF
{
    public class AdminRepository : RepositoryDefault<Admin>, IAdminRepository
    {
        public AdminRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public Admin Auth(string Username, string Password)
        {
            try
            {
                return _context.Admin.Single(p => p.Username == Username && p.Password == Password && p.IsActive == true && p.IsDeleted == false);
            }
            catch (Exception)
            {
                return null;
            }            
        }
    }
}