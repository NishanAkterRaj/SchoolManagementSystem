using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class TeacherSubject
    {
        [Key]
        public long TeacherSubjectId { get; set; }
        public long? SubjectId { get; set; }
        public long? TeacherId { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
