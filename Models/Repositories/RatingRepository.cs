using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;

namespace GradFinalProject.Models.Repositories
{
    public class RatingRepository : IRepository<Rating>
    {
        private readonly AppDbContext _context;

        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Rating entity)
        {
            _context.Ratings.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id, Rating entity)
        {
            entity = Find(id);
            if (entity != null)
            {
                _context.Ratings.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Rating Find(int id)
        {
            return _context.Ratings.FirstOrDefault(r => r.Id == id);
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

        public void Update(int id, Rating entity)
        {
            var data = Find(id);
            if (data != null)
            {
                data.Stars = entity.Stars;
                data.CreatedAt = entity.CreatedAt;
                _context.SaveChanges();
            }
        }

        public List<Rating> View()
        {
            return _context.Ratings.ToList();
        }
    }
}
