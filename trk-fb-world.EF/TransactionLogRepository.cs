using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core;

namespace TurkcellFacebookDunyasi.EF
{
    public class TransactionLogRepository : RepositoryDefault<TransactionLog>, ITransactionLogRepository
    {
        public TransactionLogRepository(TurkcellFacebookDunyasiDb context) : base(context) { }
    }
}
