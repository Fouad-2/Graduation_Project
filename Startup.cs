using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradFinalProject.Data;
using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GradFinalProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("SQL_CONN");

            services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(connectionString));
            services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("SqlCon")));
            services.AddSession();
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddScoped<IRepository<Customer>, CustomerRepository>();
            services.AddScoped<IRepository<Freelancer>, FreelancerRepository>();
            services.AddScoped<IRepository<Service> , ServiceRepository>();
            services.AddScoped<IRepository<Report>, ReportRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<Payment>, PaymentRepository>();   
            services.AddScoped<IRepository<Comment>, CommentRepository>();
            services.AddScoped<IRepository<Admin>, AdminRepository>();   
            services.AddScoped<IRepository<Category>, CategoryRepository>();    
            services.AddScoped<IRepository<Rating>, RatingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseSession();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
