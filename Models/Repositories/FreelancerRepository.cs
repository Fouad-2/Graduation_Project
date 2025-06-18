using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace GradFinalProject.Models.Repositories
{
    public class FreelancerRepository : IRepository<Freelancer>
    {
        private readonly AppDbContext _context;

        public FreelancerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Freelancer entity)
        {
            _context.Freelancers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id, Freelancer entity)
        {
            entity = Find(Id);
            _context.Freelancers.Remove(entity);
            _context.SaveChanges();
        }

        public Freelancer Find(int Id)
        {
            return _context.Freelancers.Include(x=>x.Customer).FirstOrDefault(x => x.Id == Id);
        }

        public List<Order> GetOrdersForFreelancer(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Service> GetServicesByFreelancer(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int Id, Freelancer entity)
        {
            var data = Find(Id);
            if (data != null)
            {
                data.Profession = entity.Profession;
                data.WorkSamplesFilePath = entity.WorkSamplesFilePath;
                data.CvFilePath = entity.CvFilePath;
                data.ProfileImagePath = entity.ProfileImagePath;
                data.Address = entity.Address;
                data.Description = entity.Description;
                _context.SaveChanges();
            }
        }

        public List<Freelancer> View()
        {
            return _context.Freelancers.ToList();
        }

        public Freelancer FindByCustomerId(int Id)
        {
            return _context.Freelancers.Include(x => x.Customer).FirstOrDefault(x => x.CustomerId == Id);
        }
    }
}
