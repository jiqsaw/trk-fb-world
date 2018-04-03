using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TurkcellFacebookDunyasi.Core
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsActive { get; set; }
        string Order { get; set; }
        DateTime CreateDate { get; set; }
        int CreatedBy { get; set; }
        DateTime? ModifyDate { get; set; }
        int? ModifiedBy { get; set; }
        bool IsDeleted { get; set; }

    }
}
