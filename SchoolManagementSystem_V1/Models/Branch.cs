using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Campuses = new HashSet<Campus>();
        }
        [Key]
        public long BranchId { get; set; }
        public string? BranchName { get; set; }

        public virtual ICollection<Campus> Campuses { get; set; }
    }
}
