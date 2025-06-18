using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;

namespace GradFinalProject.Models.Repositories
{
    public class PaymentRepository : IRepository<Payment>
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {   
            _context = context;
        }

        public void Add(Payment entity)
        {
            _context.Payments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id, Payment entity)
        {
            entity = Find(Id);
            if (entity != null)
            {
                _context.Payments.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Payment Find(int Id)
        {
            return _context.Payments.FirstOrDefault(x => x.Id == Id);
        }

        public Freelancer FindByCustomerId(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrdersForFreelancer(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Service> GetServicesByFreelancer(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int Id, Payment entity)
        {
            var data = Find(Id);
            if (data != null)
            {
                data.CVV = entity.CVV;
                data.ExpiryDate = entity.ExpiryDate;
                data.PaymentDate = entity.PaymentDate;
                data.CardHolderName = entity.CardHolderName;
                data.CardNumber = entity.CardNumber;
                _context.SaveChanges();
            }
        }

        public List<Payment> View()
        {
            return _context.Payments.ToList();
        }
    }
}
