using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradFinalProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }  

        public string Description { get; set; }  

        public string ImageUrl { get; set; }  

        public ICollection<Service> Services { get; set; }
    }
}
