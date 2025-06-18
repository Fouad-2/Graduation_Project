using System.Collections.Generic;
using System.Linq;
using GradFinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace GradFinalProject.Models.Repositories
{
    public class ReportRepository : IRepository<Report>
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Report entity)
        {
            _context.Reports.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id, Report entity)
        {
            entity = Find(Id);
            if (entity != null)
            {
                _context.Reports.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Report Find(int Id)
        {
            return _context.Reports.Include(x=>x.Customer).Include(x=>x.Freelancer).ThenInclude(y=>y.Customer).Include(x=>x.Service).FirstOrDefault(x => x.Id == Id);
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

        public void Update(int Id, Report entity)
        {
            var data = Find(Id);
            if (data != null)
            {
                data.AttachmentFilePath = entity.AttachmentFilePath;
                data.CreatedAt = entity.CreatedAt;
                data.Reason = entity.Reason;
                data.Status = entity.Status;
                _context.SaveChanges();
            }
        }

        public List<Report> View()
        {
            return _context.Reports
                .Include(x => x.Customer)
                .Include(x => x.Service)
                .Include(y => y.Freelancer)
                    .ThenInclude(f => f.Customer) // هاي الإضافة المهمة
                .ToList();
        }
    }
}

