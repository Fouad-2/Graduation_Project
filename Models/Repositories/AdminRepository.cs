using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;

namespace GradFinalProject.Models.Repositories
{
    public class AdminRepository : IRepository<Admin>
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Admin entity)
        {
            _context.Admins.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id, Admin entity)
        {
            var admin = Find(Id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
            }
        }

        public Admin Find(int Id)
        {
            return _context.Admins.FirstOrDefault(a => a.Id == Id);
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

        public void Update(int Id, Admin entity)
        {
            var admin = Find(Id);
            if (admin != null)
            {
                admin.Username = entity.Username;
                admin.Password = entity.Password;
                _context.SaveChanges();
            }
        }

        public List<Admin> View()
        {
            return _context.Admins.ToList();
        }
    }
}
