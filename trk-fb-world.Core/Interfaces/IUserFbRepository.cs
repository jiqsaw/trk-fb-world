using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;

namespace TurkcellFacebookDunyasi.Core.Interfaces
{
    public interface IUserFbRepository : IRepositoryDefault<UserFb>
    {
        IEnumerable<UserFb> GetAllFbUsers();
        IList<UserFbDataModel> GetUserFriendsData(int UserId, string FbId, List<string> FriendsFbIds);
        UserFb GetByFbId(string FbId);        
    }
}