using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Exam
    {
        public Exam()
        {
            StudentExamRoutines = new HashSet<StudentExamRoutine>();
            TeacherExamRoutines = new HashSet<TeacherExamRoutine>();
        }
        [Key]
        public long ExamId { get; set; }
        public long? SubjectId { get; set; }
        public string? ExamName { get; set; }
        public DateTime? ExamDate { get; set; }
        public string? ExamDuration { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public int? TotalMarks { get; set; }
        public int? PassingMarks { get; set; }
        public string? ExamStatus { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual ICollection<StudentExamRoutine> StudentExamRoutines { get; set; }
        public virtual ICollection<TeacherExamRoutine> TeacherExamRoutines { get; set; }
    }
}
