using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class TeacherClassRoutine
    {
        [Key]
        public long TeacherClassRoutineId { get; set; }
        public long? ClassRoutineId { get; set; }
        public long? TeacherId { get; set; }

        public virtual ClassRoutine? ClassRoutine { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
