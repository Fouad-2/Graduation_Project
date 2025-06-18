using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;

namespace GradFinalProject.Models.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id, Comment entity)
        {
            var comment = Find(Id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }

        public Comment Find(int Id)
        {
            return _context.Comments.FirstOrDefault(a => a.Id == Id);
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

        public void Update(int Id, Comment entity)
        {
            var data = Find(Id);
            if (data != null)
            {
                data.Content = entity.Content;
                data.CreatedAt = entity.CreatedAt;
                _context.SaveChanges();
            }
        }

        public List<Comment> View()
        {
            return _context.Comments.ToList();
        }
    }
}
