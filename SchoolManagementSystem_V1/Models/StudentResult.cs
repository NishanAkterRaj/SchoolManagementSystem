using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class StudentResult
    {
        [Key]
        public long StudentResultId { get; set; }
        public long? StudentId { get; set; }
        public long? SubjectId { get; set; }
        public long? GradeId { get; set; }
        public decimal? ObtainedMark { get; set; }

        public virtual GradingSystem? Grade { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
