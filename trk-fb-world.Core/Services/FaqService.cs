using TurkcellFacebookDunyasi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class FaqService
    {
        private readonly IFaqRepository repository;

        public FaqService(IFaqRepository repository)
        {
            this.repository = repository;
        }
    }
}
