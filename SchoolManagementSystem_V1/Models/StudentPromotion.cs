using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class StudentPromotion
    {
        [Key]
        public long StudentPromotionId { get; set; }
        public long? StudentId { get; set; }
        public long? ClassId { get; set; }
        public DateTime? PromotionDate { get; set; }
        public bool? PromotionStatus { get; set; }
        public string? PromotionReason { get; set; }
        public string? PromotionApprover { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Student? Student { get; set; }
    }
}
