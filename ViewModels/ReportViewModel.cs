using System;

namespace GradFinalProject.ViewModels
{
    public class ReportViewModel
    {
        public int CustomerId { get; set; }
        public int FreelancerId { get; set; }
        public string AttachmentFilePath { get; set; }
        public string Reason { get; set; }
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public string FreelancerName { get; set; }
        public string Status { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}
