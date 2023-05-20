using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class StudentSubject
    {
        [Key]
        public long StudentSubjectId { get; set; }
        public long? SubjectId { get; set; }
        public long? StudentId { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
