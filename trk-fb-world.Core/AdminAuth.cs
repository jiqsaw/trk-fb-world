using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core
{
    public class AdminAuth : BaseEntityDefault, IEntityDefault
    {        
        [ForeignKey("Admin")]
        public int AdminId { get; set; }

        [ForeignKey("Modul")]
        public int ModulId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Modul Modul { get; set; }

    }
}
