using System;
using System.Linq;
using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using GradFinalProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradFinalProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Freelancer> _freelancerRepo;
        private readonly IRepository<Report> _reportRepo;
        private readonly IRepository<Service> _serviceRepo;
        private readonly IRepository<Customer> _customerRepo;

        public AdminController(
            IRepository<Freelancer> freelancerRepo,
            IRepository<Report> reportRepo,
            IRepository<Service> serviceRepo,
            IRepository<Customer> customerRepo)
        {
            _freelancerRepo = freelancerRepo;
            _reportRepo = reportRepo;
            _serviceRepo = serviceRepo;
            _customerRepo = customerRepo;
        }

        // =================== LOGIN ===================

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminLoginViewModel model)
        {
            if (model.Username == "admin" && model.Password == "admin123")
            {
                HttpContext.Response.Cookies.Append("IsAdminLoggedIn", "true", new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                }); 
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Username or password is incorrect";
            return View(model);
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("IsAdminLoggedIn");
            return RedirectToAction("Login");
        }


        // =================== DASHBOARD ===================

        public IActionResult Dashboard()
        {

            var stats = new AdminDashboardViewModel

            {
                TotalFreelancers = _freelancerRepo.View().Count(),
                TotalServices = _serviceRepo.View().Count(),
                TotalReports = _reportRepo.View().Count(),
                TotalCustomers=_customerRepo.View().Count()
            };

            return View(stats);
        }

        // =================== VERIFICATION ===================

        public IActionResult Verification()
        {

            var unverified = _freelancerRepo
                .View()
                .Where(f => !f.IsVerified)
                .ToList();

            return View(unverified);
        }

        [HttpPost]
        public IActionResult VerifyFreelancer(int id)
        {

            var freelancer = _freelancerRepo.Find(id);
            if (freelancer == null) return NotFound();

            freelancer.IsVerified = true;
            _freelancerRepo.Update(id, freelancer);

            return RedirectToAction("Verification");
        }

        [HttpPost]
        public IActionResult RejectFreelancer(int id)
        {
            var freelancer = _freelancerRepo.Find(id);
            if (freelancer == null) return NotFound();

            freelancer.IsVerified = false;
            _freelancerRepo.Update(id, freelancer);

            return RedirectToAction("Verification");
        }


        // =================== MANAGE REPORTS ===================

        public IActionResult ManageReports()
        {

            var reportedServices = _reportRepo
                .View();

            return View(reportedServices);
        }

        [HttpPost]
        public IActionResult DeactivateService(int id)
        {


            var service = _serviceRepo.Find(id);
            if (service == null) return NotFound();

            service.IsActive = false;
            _serviceRepo.Update(id, service);

            return RedirectToAction("ManageReports");
        }
        public IActionResult LoadCustomersList()
        {
            var customers = _customerRepo.View(); 
            return PartialView("_CustomersList", customers);
        }

        public IActionResult LoadFreelancers()
        {
            var freelancers = _freelancerRepo.View();
            return PartialView("_FreelancerListPartial", freelancers);
        }

        public IActionResult LoadReports()
        {
            var reports = _reportRepo.View();
            return PartialView("_ReportListPartial", reports );
        }

        public IActionResult LoadServices()
        {
            var services = _serviceRepo.View();
            return PartialView("_ServiceListPartial", services);
        }
    }
}
