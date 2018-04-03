using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core
{
    public interface ILog
    {
        int UserId { get; set; }
        string Naming { get; set; }
        string IP { get; set; }
        string Status { get; set; }
        string FbId { get; set; }
        string Msisdn { get; set; }
        string TcellSession { get; set; }
    }
}
