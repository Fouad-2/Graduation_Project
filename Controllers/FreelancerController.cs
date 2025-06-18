using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using GradFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using GradFinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace GradFinalProject.Controllers
{
    public class FreelancerController : Controller
    {
        private readonly IRepository<Freelancer> _freelancerRepo;
        private readonly IRepository<Service> _serviceRepo;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Category> categoryRepo;
        private readonly IRepository<Customer> customerRepo;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext Context;

        public FreelancerController(IRepository<Freelancer> freelancerRepo,
                                    IRepository<Service> serviceRepo,
                                    IRepository<Order> orderRepo,
                                    IRepository<Category> categoryRepo,
                                    IRepository<Customer> customerRepo,
                                    IWebHostEnvironment env,
                                     AppDbContext _Context)
        {
            _freelancerRepo = freelancerRepo;
            _serviceRepo = serviceRepo;
            _orderRepo = orderRepo;
            this.categoryRepo = categoryRepo;
            this.customerRepo = customerRepo;
            _env = env;
            Context = _Context;
        }
        [HttpPost]

        private void FillCategories(int? selectedId = null)
        {
            ViewBag.CategoryId = new SelectList(Context.Categories, "Id", "Name", selectedId);
        }

        public IActionResult Dashboard(int id)
        {
            var freelancer = _freelancerRepo.Find(id);
            if (freelancer == null) return NotFound();

            var services = _serviceRepo.GetServicesByFreelancer(id);
            var orders = _orderRepo.GetOrdersForFreelancer(id);

            var viewModel = new FreelancerDashboardViewModel
            {
                Freelancer = freelancer,
                Services = services.ToList(),
                Orders = orders.ToList()
            };
            ViewBag.categories = categoryRepo.View();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult UpdateProfile(int id)
        {
            var freelancer = _freelancerRepo.Find(id);
            if (freelancer == null) return NotFound();

            return View(freelancer); 
        }

        public IActionResult UpdateProfile(int FreelancerId, string? Description, string? Address, IFormFile? ProfileImagePath)
        {
            var freelancer = _freelancerRepo.Find(FreelancerId);
            if (freelancer == null) return NotFound();

            if (!string.IsNullOrEmpty(Description))
            {
                freelancer.Description = Description;
            }

            if (!string.IsNullOrEmpty(Address))
            {
                freelancer.Address = Address;
            }

            if (ProfileImagePath != null && ProfileImagePath.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "uploads");
                var fileName = Path.GetFileName(ProfileImagePath.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ProfileImagePath.CopyTo(fileStream);
                }
                freelancer.ProfileImagePath = "/uploads/" + fileName;
            }

            _freelancerRepo.Update(FreelancerId, freelancer);
            return RedirectToAction("Dashboard", new { id = FreelancerId });
        }


        public IActionResult ToggleServiceStatus(int id)
        {
            var service = _serviceRepo.Find(id);
            if (service == null) return NotFound();

            service.IsActive = !service.IsActive;
            _serviceRepo.Update(id, service);
            return RedirectToAction("ManageService", new { id = service.FreelancerId });
        }

        [HttpPost]
        public IActionResult DeleteService(int id)
        {
            var service = _serviceRepo.Find(id);
            if (service == null) return NotFound();

            _serviceRepo.Delete(id, service);
            return Ok();
        }

        [HttpPost]
        public IActionResult RespondToOrder(int Id, bool accept)
        {
            var order = _orderRepo.Find(Id);
            if (order == null) return NotFound();

            order.Status = accept ? "Accepted" : "Rejected";
            _orderRepo.Update(Id, order);
            return Ok();
        }
        public IActionResult ManageService(int id)
        {
            var viewModel = new ManageFreelancerDataViewModel
            {
                Services = _serviceRepo.View().Where(s => s.FreelancerId == id).ToList(),
                Orders = _orderRepo.View().Where(o => o.FreelancerId == id).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderRepo.View()
                .Select(o => new {
                    status = o.Status,
                    totalAmount = o.TotalAmount,
                    orderDate = o.OrderDate.ToString("yyyy-MM-dd"),
                    service = new
                    {
                        title = o.Service != null ? o.Service.Title : ""
                    },
                    customer = new
                    {
                        firstName = o.Customer != null ? o.Customer.FirstName : "",
                        lastName = o.Customer != null ? o.Customer.LastName : ""
                    }
                });

            return Json(orders);
        }
    }
}
