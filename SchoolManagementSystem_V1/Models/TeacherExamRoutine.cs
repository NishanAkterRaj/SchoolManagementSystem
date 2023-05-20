using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class TeacherExamRoutine
    {
        [Key]
        public long TeacherExamRoutineId { get; set; }
        public long? ExamId { get; set; }
        public long? TeacherId { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
