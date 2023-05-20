using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class StudentExamRoutine
    {
        [Key]
        public long StudentExamRoutineId { get; set; }
        public long? ExamId { get; set; }
        public long? StudentId { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual Student? Student { get; set; }
    }
}
