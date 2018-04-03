using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.EF
{
    public class UserFbRepository : RepositoryDefault<UserFb>, IUserFbRepository
    {
        public UserFbRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<UserFb> GetAllFbUsers()
        {
            return _context.UserFb
                .Where(p => p.IsDeleted == false
                    )
                .OrderByDescending(p => p.Id).ToList();
        }

        public UserFb GetByFbId(string FbId)
        {
            return _context.UserFb
                            .Where(p => 
                                p.IsDeleted == false &&
                                p.FbId == FbId).SingleOrDefault();
        }

        public IList<UserFbDataModel> GetUserFriendsData(int UserId, string FbId, List<string> FriendsFbIds)
        {
            return _context.Database.SqlQuery<UserFbDataModel>("GetUserFriendsData @UserId, @FbId, @FriendsFbIds",
                                                                    new SqlParameter("UserId", UserId),
                                                                    new SqlParameter("FbId", FbId),
                                                                    new SqlParameter("FriendsFbIds", String.Join(",", FriendsFbIds.ToArray()))
                                                                ).ToList();            
        }
    }    
}