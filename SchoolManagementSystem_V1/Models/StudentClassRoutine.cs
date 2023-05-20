using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class StudentClassRoutine
    {
        [Key]
        public long StudentClassRoutineId { get; set; }
        public long? ClassRoutineId { get; set; }
        public long? StudentId { get; set; }

        public virtual ClassRoutine? ClassRoutine { get; set; }
        public virtual Student? Student { get; set; }
    }
}
