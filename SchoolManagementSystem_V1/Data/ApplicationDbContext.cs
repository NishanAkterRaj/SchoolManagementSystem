using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem_V1.Models; 

namespace SchoolManagementSystem_V1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

       

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassRoutine> ClassRoutines { get; set; }
        public virtual DbSet<Curriculum> Curricula { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<GradingSystem> GradingSystems { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentClassRoutine> StudentClassRoutines { get; set; }
        public virtual DbSet<StudentExamRoutine> StudentExamRoutines { get; set; }
        public virtual DbSet<StudentPayment> StudentPayments { get; set; }
        public virtual DbSet<StudentPortal> StudentPortals { get; set; }
        public virtual DbSet<StudentPromotion> StudentPromotions { get; set; }
        public virtual DbSet<StudentResult> StudentResults { get; set; }
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }
        public virtual DbSet<Stuff> Stuffs { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SuperAdmin> SuperAdmins { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherClassRoutine> TeacherClassRoutines { get; set; }
        public virtual DbSet<TeacherDesignation> TeacherDesignations { get; set; }
        public virtual DbSet<TeacherExamRoutine> TeacherExamRoutines { get; set; }
        public virtual DbSet<TeacherPortal> TeacherPortals { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

    }
}
