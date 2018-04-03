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
    public class UserSmsRepository : RepositoryDefault<UserSms>, IUserSmsRepository
    {
        public UserSmsRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<UserSms> GetLiveUserSms()
        {
            return _context.UserSms
                .Where(p => p.IsDeleted == false
                    )
                .OrderBy(p => p.Id).ToList();
        }
    }
}
