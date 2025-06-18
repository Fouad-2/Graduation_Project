using System.ComponentModel.DataAnnotations;
using System;

namespace GradFinalProject.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
