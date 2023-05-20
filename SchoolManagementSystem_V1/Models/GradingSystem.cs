using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class GradingSystem
    {
        public GradingSystem()
        {
            StudentResults = new HashSet<StudentResult>();
        }
        [Key]
        public long GradeId { get; set; }
        public long? Classid { get; set; }
        public string? GradeName { get; set; }
        public int? MaxMarks { get; set; }
        public int? MinimumMarks { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<StudentResult> StudentResults { get; set; }
    }
}
