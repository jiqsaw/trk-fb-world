using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.EF
{
    public class UserRequestTLRepository : RepositoryDefault<UserRequestTL>, IUserRequestTLRepository
    {
        public UserRequestTLRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<UserRequestTL> GetLiveUserRequestTL()
        {
            return _context.UserRequestTL
                .Where(p => p.IsDeleted == false 
                    )
                .OrderBy(p => p.Id).ToList();
        }
    }
}
