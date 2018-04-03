using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class UserSentTLService
    {
        private readonly IUserSentTLRepository repository;

        public UserSentTLService(IUserSentTLRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<UserSentTL> GetLiveUserSentTL()
        {
            return repository.GetLiveUserSentTL();
        }
    }   

}
