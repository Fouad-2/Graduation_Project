using GradFinalProject.Models;
using System.Collections.Generic;

namespace GradFinalProject.ViewModels
{
    public class FreelancerDashboardViewModel
    {
        public Service Service { get; set; }
        public Freelancer Freelancer { get; set; }
        public List<Service> Services { get; set; }
        public List<Order> Orders { get; set; }
    }
}
