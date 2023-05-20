using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Session
    {
        public Session()
        {
            Students = new HashSet<Student>();
        }
        [Key]
        public long SessionId { get; set; }
        public string? SessionName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
