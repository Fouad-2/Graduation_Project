using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace GradFinalProject.Models.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Service entity)
        {
            _context.Services.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id, Service entity)
        {
            entity = Find(Id);
            if (entity != null)
            {
                _context.Services.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Service Find(int Id)
        {
            return _context.Services.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(int Id, Service entity)
        {
            var data = Find(Id);
            if (data != null)
            {
                data.Title = entity.Title;
                data.Description = entity.Description;
                data.Price = entity.Price;
                data.AttachmentPath = entity.AttachmentPath;
                data.EstimationTime = entity.EstimationTime;
                data.IsActive = entity.IsActive;
                data.RequiredTools = entity.RequiredTools;
                _context.SaveChanges();
            }
        }
        public List<Service> GetServicesByFreelancer(int freelancerId)
        {
            return _context.Services
                .Where(s => s.FreelancerId == freelancerId)
                .Include(s => s.Category)
                .Include(s => s.Ratings)
                .ToList();
        }
        public List<Service> View()
        {
            return _context.Services
       .Include(s => s.Freelancer)
           .ThenInclude(f => f.Customer)
       .Include(s => s.Category)
       .Include(s => s.Ratings)
       .ToList();
        }

        public List<Order> GetOrdersForFreelancer(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Freelancer FindByCustomerId(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
