using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassRoutines = new HashSet<ClassRoutine>();
            GradingSystems = new HashSet<GradingSystem>();
            StudentPromotions = new HashSet<StudentPromotion>();
            Students = new HashSet<Student>();
            Subjects = new HashSet<Subject>();
        }
        [Key]
        public long ClassId { get; set; }
        public long? CurriculumId { get; set; }
        public string? ClassName { get; set; }

        public virtual Curriculum? Curriculum { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<GradingSystem> GradingSystems { get; set; }
        public virtual ICollection<StudentPromotion> StudentPromotions { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
