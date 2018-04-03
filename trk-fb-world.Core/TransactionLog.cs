using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core
{
    public class TransactionLog : BaseLog, ILog, ITransactionLog
    {
        public string Details { get; set; }
    }
}
