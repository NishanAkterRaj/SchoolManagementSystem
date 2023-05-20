using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Subject
    {
        public Subject()
        {
            ClassRoutines = new HashSet<ClassRoutine>();
            Exams = new HashSet<Exam>();
            StudentResults = new HashSet<StudentResult>();
            StudentSubjects = new HashSet<StudentSubject>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }
        [Key]
        public long SubjectId { get; set; }
        public long? ClassId { get; set; }
        public string? ClassName { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<StudentResult> StudentResults { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
