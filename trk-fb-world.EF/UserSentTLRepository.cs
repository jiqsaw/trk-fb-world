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
    public class UserSentTLRepository : RepositoryDefault<UserSentTL>, IUserSentTLRepository
    {
        public UserSentTLRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<UserSentTL> GetLiveUserSentTL()
        {
            return _context.UserSentTL
                .Where(p => p.IsDeleted == false 
                    )
                .OrderBy(p => p.Id).ToList();
        }
    }
}
