using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem_V1.Models
{
    public partial class StudentPayment
    {
        [Key]
        public long StudentPaymentId { get; set; }
        public long? StudentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmmount { get; set; }
        public string? PaymentType { get; set; }
        public string? PaymentReference { get; set; }
        public string? PaymentStatus { get; set; }

        public virtual Student? Student { get; set; }
    }
}
