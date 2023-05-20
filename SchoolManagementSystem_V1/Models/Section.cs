using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Section
    {
        public Section()
        {
            ClassRoutines = new HashSet<ClassRoutine>();
            Students = new HashSet<Student>();
        }
        [Key]
        public long SectionId { get; set; }
        public string? SectionName { get; set; }

        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
