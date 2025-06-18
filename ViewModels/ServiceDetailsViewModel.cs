using GradFinalProject.Models;
using System.Collections.Generic;

namespace GradFinalProject.ViewModels
{
    public class ServiceDetailsViewModel
    {
        public Customer Customer { get; set; }
        public Service Service { get; set; }
        public Freelancer Freelancer { get; set; }
        public List<Comment> Comment { get; set; } 
    }
}
