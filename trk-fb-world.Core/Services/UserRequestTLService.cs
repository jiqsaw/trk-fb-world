using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class UserRequestTLService
    {
        private readonly IUserRequestTLRepository repository;

        public UserRequestTLService(IUserRequestTLRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<UserRequestTL> GetLiveUserRequestTL()
        {
            return repository.GetLiveUserRequestTL();
        }
    }   

}
