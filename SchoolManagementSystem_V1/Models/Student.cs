using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentClassRoutines = new HashSet<StudentClassRoutine>();
            StudentExamRoutines = new HashSet<StudentExamRoutine>();
            StudentPayments = new HashSet<StudentPayment>();
            StudentPortals = new HashSet<StudentPortal>();
            StudentPromotions = new HashSet<StudentPromotion>();
            StudentResults = new HashSet<StudentResult>();
            StudentSubjects = new HashSet<StudentSubject>();
        }
        [Key]
        public long StudentId { get; set; }
        public long? CampusId { get; set; }
        public long? SectionId { get; set; }
        public long? GroupId { get; set; }
        public long? SessionId { get; set; }
        public long? ShiftId { get; set; }
        public long? ClassId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Photo { get; set; }
        public string? Gender { get; set; }
        public string? RollNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? BirthCertificate { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string? Religion { get; set; }
        public string? Nationality { get; set; }
        public string? PreviousSchool { get; set; }
        public decimal? Gpa { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? FatherNid { get; set; }
        public string? MotherNid { get; set; }
        public string? FatherOccupation { get; set; }
        public string? FatherPhoneNumber { get; set; }
        public string? FatherEmail { get; set; }
        public string? MotherOccupation { get; set; }
        public string? MotherPhoneNumber { get; set; }
        public string? MotherEmail { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }

        public virtual Campus? Campus { get; set; }
        public virtual Class? Class { get; set; }
        public virtual Group? Group { get; set; }
        public virtual Section? Section { get; set; }
        public virtual Session? Session { get; set; }
        public virtual Shift? Shift { get; set; }
        public virtual ICollection<StudentClassRoutine> StudentClassRoutines { get; set; }
        public virtual ICollection<StudentExamRoutine> StudentExamRoutines { get; set; }
        public virtual ICollection<StudentPayment> StudentPayments { get; set; }
        public virtual ICollection<StudentPortal> StudentPortals { get; set; }
        public virtual ICollection<StudentPromotion> StudentPromotions { get; set; }
        public virtual ICollection<StudentResult> StudentResults { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
