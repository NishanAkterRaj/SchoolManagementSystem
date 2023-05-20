using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Curriculum
    {
        public Curriculum()
        {
            Classes = new HashSet<Class>();
        }
        [Key]
        public long CurriculumId { get; set; }
        public long? CampusId { get; set; }
        public string? CurriculumName { get; set; }

        public virtual Campus? Campus { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
