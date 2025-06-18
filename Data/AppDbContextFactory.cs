using GradFinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GradFinalProject.Models
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-NRUJF3B\\SQL2019; Database=GradProjectDB; User Id=sa; Password=123; Trusted_Connection=True; TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
