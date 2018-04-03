﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;

namespace TurkcellFacebookDunyasi.Core.Interfaces
{
    public interface ITransferAmountRepository : IRepository<TransferAmount>
    {
        IEnumerable<TransferAmount> GetLiveTransferAmounts();
    }
}
