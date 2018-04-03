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
    public class UserInviteRepository : RepositoryDefault<UserInvite>, IUserInviteRepository
    {
        public UserInviteRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<UserInvite> GetLiveUserInvites()
        {
            return _context.UserInvite
                .Where(p => p.IsDeleted == false
                    )
                .ToList();
        }
    }
}
