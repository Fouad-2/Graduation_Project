using GradFinalProject.Models;
using System.Collections.Generic;

namespace GradFinalProject.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public Category Category { get; set; }
        public List<ServiceCardViewModel> Services { get; set; }
    }
}
