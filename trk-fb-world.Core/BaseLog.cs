using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core
{
    public class BaseLog : BaseEntityDefault, IEntityDefault, ILog
    {

        public int UserId { get; set; }

        public string Naming { get; set; }

        public string IP { get; set; }

        public string Status { get; set; }

        public string FbId { get; set; }

        public string Msisdn { get; set; }

        public string TcellSession { get; set; }
    }
}
