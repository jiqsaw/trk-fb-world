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
    public class ClickToCallUserBlockRepository : RepositoryDefault<ClickToCallUserBlock>, IClickToCallUserBlockRepository
    {
        public ClickToCallUserBlockRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<ClickToCallUserBlock> GetByUserId(int UserId)
        {
            return _context.ClickToCallUserBlock
                            .Where(p =>
                                p.IsDeleted == false &&
                                p.UserId == UserId).ToList();
        }

        public void DeleteByFbId(int UserId, string FbId)
        {
            var ent = GetByFbId(UserId, FbId);
            DeleteAndCommit(ent);
        }

        public ClickToCallUserBlock GetByFbId(int UserId, string FriendFbId) {
            return _context.ClickToCallUserBlock
                            .Where(p =>
                                (p.IsDeleted == false) &&
                                (p.UserId == UserId) &&
                                (p.UserFriendFbId == FriendFbId)).SingleOrDefault();
        }

    }
}