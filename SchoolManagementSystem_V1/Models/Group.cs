using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }
        [Key]
        public long GroupId { get; set; }
        public string? GroupName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
