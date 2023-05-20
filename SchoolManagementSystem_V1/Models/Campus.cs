using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Campus
    {
        public Campus()
        {
            Buildings = new HashSet<Building>();
            Curricula = new HashSet<Curriculum>();
            Students = new HashSet<Student>();
        }
        [Key]
        public long CampusId { get; set; }
        public long? BranchId { get; set; }
        public long? ShiftId { get; set; }
        public string? CampusName { get; set; }
        public string? Location { get; set; }

        public virtual Branch? Branch { get; set; }
        public virtual Shift? Shift { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Curriculum> Curricula { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
