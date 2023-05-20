using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class StudentPortal
    {
        [Key]
        public long StudentPortalId { get; set; }
        public long? StudentId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public virtual Student? Student { get; set; }
    }
}
