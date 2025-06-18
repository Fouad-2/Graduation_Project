using System;

namespace GradFinalProject.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Stars { get; set; } 

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
