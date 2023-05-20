using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Building
    {
        public Building()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        public long BuildingId { get; set; }
        public long? CampusId { get; set; }
        public string? BuildingName { get; set; }

        public virtual Campus? Campus { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
