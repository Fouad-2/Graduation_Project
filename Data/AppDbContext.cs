
using GradFinalProject.Models;
using Microsoft.EntityFrameworkCore;
namespace GradFinalProject.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Service> Services { get; set; }    
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // علاقة Customer - Freelancer (One-to-One)
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Freelancer)
            .WithOne(f => f.Customer)
            .HasForeignKey<Freelancer>(f => f.CustomerId);

        // علاقة Order -> Customer (Many-to-One)
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            // علاقة Order -> Freelancer (Many-to-One)
            modelBuilder.Entity<Order>()
            .HasOne(o => o.Freelancer)
            .WithMany(f => f.Orders)
            .HasForeignKey(o => o.FreelancerId)
            .OnDelete(DeleteBehavior.Restrict);

            // علاقة Service -> Freelancer (Many-to-One)
            modelBuilder.Entity<Service>()
            .HasOne(s => s.Freelancer)
            .WithMany(f => f.Services)
            .HasForeignKey(s => s.FreelancerId)
            .OnDelete(DeleteBehavior.Restrict);

            // علاقة Comment -> Customer & Service
            modelBuilder.Entity<Comment>()
            .HasOne(c => c.Customer)
            .WithMany(cu => cu.Comments)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
            .HasOne(c => c.Service)
            .WithMany(s => s.Comments)
            .HasForeignKey(c => c.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

            // علاقة Report -> Customer
            modelBuilder.Entity<Report>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reports)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            // علاقة Report -> Freelancer (Optional)
            modelBuilder.Entity<Report>()
            .HasOne(r => r.Freelancer)
            .WithMany(f => f.Reports)
            .HasForeignKey(r => r.FreelancerId)
            .OnDelete(DeleteBehavior.Restrict);

        // علاقة Report -> Service (Optional)
        modelBuilder.Entity<Report>()
            .HasOne(r => r.Service)
            .WithMany(s => s.Reports)
            .HasForeignKey(r => r.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        // علاقة Payment -> Order (One-to-One)
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Order)
            .WithOne(o => o.Payment)
            .HasForeignKey<Payment>(p => p.OrderId);
        }

    }
}
