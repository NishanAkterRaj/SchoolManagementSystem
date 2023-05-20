using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class TeacherDesignation
    {
        [Key]
        public long TeacherDesignationId { get; set; }
        public long? DesignationId { get; set; }
        public long? TeacherId { get; set; }

        public virtual Designation? Designation { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
