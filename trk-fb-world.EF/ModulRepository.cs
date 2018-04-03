using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.CustomModels;

namespace TurkcellFacebookDunyasi.EF
{
    public class ModulRepository : Repository<Modul>, IModulRepository
    {
        public ModulRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<Modul> GetLiveModuls()
        {
            return _context.Modul.Where(p => p.IsDeleted == false && p.HasLivePage == true)
                .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                .ThenBy(p => p.Id).ToList();
        }

        public IEnumerable<Modul> GetListForAdmin()
        {
            return _context.Modul.Where(p => p.IsDeleted == false && p.IsActive == true)
                .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                .ThenBy(p => p.Id).ToList();
        }

        public IEnumerable<Modul> GetAdminModuls(int AdminId)
        {
            return _context.Modul.Join(_context.AdminAuth.Where(p => p.AdminId == AdminId),
                               m => m.Id,
                               a => a.ModulId,
                               (m, a)
                                  => m)
                        .Where(m => m.IsDeleted == false && m.IsActive == true)
                        .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                        .ThenBy(p => p.Id).ToList();
        }
    }
}
