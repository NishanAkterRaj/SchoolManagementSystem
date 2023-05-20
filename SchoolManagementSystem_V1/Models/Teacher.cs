using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Admins = new HashSet<Admin>();
            TeacherClassRoutines = new HashSet<TeacherClassRoutine>();
            TeacherDesignations = new HashSet<TeacherDesignation>();
            TeacherExamRoutines = new HashSet<TeacherExamRoutine>();
            TeacherPortals = new HashSet<TeacherPortal>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }
        [Key]
        public long TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Photo { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Nid { get; set; }
        public string? Religion { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nationality { get; set; }
        public string? Qualification { get; set; }
        public string? Salary { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<TeacherClassRoutine> TeacherClassRoutines { get; set; }
        public virtual ICollection<TeacherDesignation> TeacherDesignations { get; set; }
        public virtual ICollection<TeacherExamRoutine> TeacherExamRoutines { get; set; }
        public virtual ICollection<TeacherPortal> TeacherPortals { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
