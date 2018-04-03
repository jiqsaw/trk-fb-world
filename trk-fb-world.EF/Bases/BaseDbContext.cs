using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TurkcellFacebookDunyasi.EF.Bases
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext() : base("name=DbConn") { }
    }
}
