using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;

namespace GradFinalProject.Models.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id, Category entity)
        {
            var category = Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public Category Find(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
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

        public void Update(int id, Category entity)
        {
            var category = Find(id);
            if (category != null)
            {
                category.CategoryName = entity.CategoryName;
                category.Description = entity.Description;
                category.ImageUrl = entity.ImageUrl;
                _context.SaveChanges();
            }
        }

        public List<Category> View()
        {
            return _context.Categories.ToList();
        }
    }
}

