using System;

namespace GradFinalProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }
        public int ServiceId { get; set; } 
        public Service Service { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
        public decimal TotalAmount { get; set; }

    }

}
