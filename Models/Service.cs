using System.Collections.Generic;
using System.Xml.Linq;
using System;

namespace GradFinalProject.Models
{
    public class Service
    {
        public int Id { get; set; }

        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int CategoryId { get; set; } 
        public Category Category { get; set; }  
        public string Title { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; } 
        public string EstimationTime { get; set; } 
        public string RequiredTools { get; set; } 
        public bool IsActive { get; set; } = true; 
        public string? AttachmentPath { get; set; }

        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Report>? Reports { get; set; } = new List<Report>();
    }
}
