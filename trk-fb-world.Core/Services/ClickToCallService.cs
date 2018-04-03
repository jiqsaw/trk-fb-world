using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class ClickToCallService
    {
        private readonly IClickToCallRepository repository;

        public ClickToCallService(IClickToCallRepository repository)
        {
            this.repository = repository;
        }
    }   

}
