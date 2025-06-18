using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;

namespace GradFinalProject.Models.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id, Customer entity)
        {
            entity = Find(Id);
            if (entity != null)
            {
                _context.Customers.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Customer Find(int Id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == Id);
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

        public void Update(int Id, Customer entity)
        {
            var data = Find(Id);
            if (data != null)
            {
                data.Email = entity.Email;
                data.FirstName = entity.FirstName;
                data.LastName = entity.LastName;
                data.BirthDate = entity.BirthDate;
                data.Gender = entity.Gender;
                data.PhoneNumber = entity.PhoneNumber;
                data.City = entity.City;
                data.Password = entity.Password;

                _context.SaveChanges();
            }
        }

        public List<Customer> View()
        {
            return _context.Customers.ToList();
        }
    }
}
