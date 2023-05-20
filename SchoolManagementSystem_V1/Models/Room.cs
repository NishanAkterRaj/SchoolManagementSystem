using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class Room
    {
        public Room()
        {
            ClassRoutines = new HashSet<ClassRoutine>();
        }
        [Key]
        public long RoomId { get; set; }
        public long? BuildingId { get; set; }
        public int? RoomNumber { get; set; }
        public int? Capacity { get; set; }

        public virtual Building? Building { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
    }
}
