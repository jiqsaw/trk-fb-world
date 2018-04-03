using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class UserInviteService
    {
        private readonly IUserInviteRepository repository;

        public UserInviteService(IUserInviteRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<UserInvite> GetLiveUserInvites()
        {
            return repository.GetLiveUserInvites();
        }
    }   

}
