using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace GradFinalProject.Models.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id, Order entity)
        {
            entity = Find(Id);
            if (entity != null)
            {
                _context.Orders.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Order Find(int Id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(int Id, Order entity)
        {
            var data = Find(Id);
            if (data != null)
            {
                data.OrderDate = entity.OrderDate;
                data.Status = entity.Status;
                data.TotalAmount = entity.TotalAmount;
                _context.SaveChanges();
            }
        }
        public List<Order> GetOrdersForFreelancer(int freelancerId)
        {
            return _context.Orders
                .Include(o => o.Service)
                .Include(o => o.Customer)
                .Where(o => o.Service.FreelancerId == freelancerId)
                .ToList();
        }
        public List<Order> View()
        {
            return _context.Orders
    .Include(o => o.Customer)
    .Include(o => o.Service)
    .Include(o => o.Freelancer)
    .Include(o => o.Payment)
    .ToList();
        }

        public List<Service> GetServicesByFreelancer(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Freelancer FindByCustomerId(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
