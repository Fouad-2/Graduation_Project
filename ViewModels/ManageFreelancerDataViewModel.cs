using GradFinalProject.Models;
using System.Collections.Generic;

namespace GradFinalProject.ViewModels
{
    public class ManageFreelancerDataViewModel
    {
        public Freelancer Freelancer { get; set; }
        public List<Service> Services { get; set; }
        public List<Order> Orders { get; set; }

    }
}
