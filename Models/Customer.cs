using System;
using System.Collections.Generic;

namespace GradFinalProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsFreelancer { get; set; }
        public Freelancer? Freelancer { get; set; }


        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
