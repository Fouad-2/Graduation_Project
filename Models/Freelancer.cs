using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradFinalProject.Models
{
    public class Freelancer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }
       
        public string Profession { get; set; }
        public string Address { get; set; }
        public string CvFilePath { get; set; }
        
        public string WorkSamplesFilePath { get; set; }
        public string? ProfileImagePath { get; set; }
        public string? Description { get; set; }
        public bool IsVerified { get; set; }
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
