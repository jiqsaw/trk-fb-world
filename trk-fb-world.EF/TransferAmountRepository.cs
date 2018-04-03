using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.EF
{
    public class TransferAmountRepository : Repository<TransferAmount>, ITransferAmountRepository
    {
        public TransferAmountRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public IEnumerable<TransferAmount> GetLiveTransferAmounts()
        {
            return _context.TransferAmount
                .Where(p => p.IsDeleted == false 
                    )
                .OrderBy(p => p.Order).ToList();
        }
    }
}
