using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class ClassRoutine
    {
        public ClassRoutine()
        {
            StudentClassRoutines = new HashSet<StudentClassRoutine>();
            TeacherClassRoutines = new HashSet<TeacherClassRoutine>();
        }

        [Key]
        public long ClassRoutineId { get; set; }
        public long? ClassId { get; set; }
        public long? SubjectId { get; set; }
        public long? RoomId { get; set; }
        public long? Shiftid { get; set; }
        public long? SectionId { get; set; }
        public string? WeekDay { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? Duration { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Room? Room { get; set; }
        public virtual Section? Section { get; set; }
        public virtual Shift? Shift { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<StudentClassRoutine> StudentClassRoutines { get; set; }
        public virtual ICollection<TeacherClassRoutine> TeacherClassRoutines { get; set; }
    }
}
