using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core
{
    public class Modul : BaseEntity, IEntity
    {
        [DefaultValue(0)]
        [Required]
        public int ParentId { get; set; }

        public int Language { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(100)]
        public string AdminPath { get; set; }

        [Required]
        public bool IsInAdminMenu { get; set; }

        [Required]
        public bool IsSubEndItem { get; set; }

        [Required]
        public bool HasLivePage { get; set; }

        [StringLength(500)]
        public string LivePageUrl { get; set; }
    }
}