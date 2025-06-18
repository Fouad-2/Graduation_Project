using System;

namespace GradFinalProject.Models
{
    public class Report
    {
        public int Id { get; set;}
        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }
        public int? ServiceId { get; set; } 
        public Service? Service { get; set; }
        public int? FreelancerId { get; set; } 
        public Freelancer? Freelancer { get; set; }
        public string Reason { get; set; } 
        public string? AttachmentFilePath { get; set; } 
        public string Status { get; set; } = "Pending"; 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
