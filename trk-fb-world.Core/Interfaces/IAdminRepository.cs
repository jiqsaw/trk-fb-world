using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkcellFacebookDunyasi.Core
{
    public interface IAdminRepository : IRepositoryDefault<Admin>
    {
        Admin Auth(string Username, string Password);
    }
}