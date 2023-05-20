using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class SuperAdmin
    {
        [Key]
        public long SuperAdminId { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Photo { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
