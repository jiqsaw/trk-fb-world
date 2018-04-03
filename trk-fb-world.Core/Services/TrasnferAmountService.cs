using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class TransferAmountService
    {
        private readonly ITransferAmountRepository repository;

        public TransferAmountService(ITransferAmountRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TransferAmount> GetLiveTransferAmounts()
        {
            return repository.GetLiveTransferAmounts();
        }
    }   

}
