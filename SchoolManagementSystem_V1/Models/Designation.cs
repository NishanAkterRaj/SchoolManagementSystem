using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Designation
    {
        public Designation()
        {
            TeacherDesignations = new HashSet<TeacherDesignation>();
        }
        [Key]
        public long DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public virtual ICollection<TeacherDesignation> TeacherDesignations { get; set; }
    }
}
