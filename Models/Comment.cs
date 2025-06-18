using System;

namespace GradFinalProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
