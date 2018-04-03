using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;


namespace TurkcellFacebookDunyasi.Core.Interfaces
{
    public interface IClickToCallUserBlockRepository : IRepositoryDefault<ClickToCallUserBlock>
    {
        IEnumerable<ClickToCallUserBlock> GetByUserId(int UserId);
        void DeleteByFbId(int UserId, string FbId);
    }
}
