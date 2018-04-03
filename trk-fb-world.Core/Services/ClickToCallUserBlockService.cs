using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class ClickToCallUserBlockService
    {
        private readonly IClickToCallUserBlockRepository repository;

        public ClickToCallUserBlockService(IClickToCallUserBlockRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ClickToCallUserBlock> GetByUserId(int UserId)
        {
            return repository.GetByUserId(UserId).Take(500);
        }

        public void Add(int UserId, IEnumerable<string> arrFriendIds) {

            IEnumerable<ClickToCallUserBlock> UserBlockList = repository.GetByUserId(UserId);

            foreach (var item in arrFriendIds)
            {
                if (UserBlockList.Where(p => p.UserFriendFbId == item).Count() < 1)
                {
                    ClickToCallUserBlock obj = new ClickToCallUserBlock();
                    obj.UserId = UserId;
                    obj.UserFriendFbId = item;
                    repository.Save(obj);
                }
            }
            repository.Commit();
        }

        public void DeleteByFbId(int UserId, string FbId)
        {
            repository.DeleteByFbId(UserId, FbId);
        }
    }
}
