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
    public class ClickToCallPreferenceRepository : RepositoryDefault<ClickToCallPreference>, IClickToCallPreferenceRepository
    {
        public ClickToCallPreferenceRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public ClickToCallPreference GetByUserId(int UserId)
        {
            return _context.ClickToCallPreference
                            .Where(p =>
                                p.IsDeleted == false &&
                                p.UserId == UserId).SingleOrDefault();
        }
    }
}
