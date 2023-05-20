using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class TeacherPortal
    {
        [Key]
        public long TeacherPortalId { get; set; }
        public long? TeacherId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public virtual Teacher? Teacher { get; set; }
    }
}
