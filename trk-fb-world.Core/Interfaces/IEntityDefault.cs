using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TurkcellFacebookDunyasi.Core
{
    public interface IEntityDefault
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime? ModifyDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
