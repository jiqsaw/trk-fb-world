using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurkcellFacebookDunyasi.Admin.Filters;

namespace TurkcellFacebookDunyasi.Admin.Controllers
{
    [AuthorizeAttribute]
    public class BaseAuthorizedController : BaseController
    {
    }
}