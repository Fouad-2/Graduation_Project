using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace GradFinalProject.Controllers
{
    public class ReportController : Controller
    {
        private readonly IRepository<Report> _reportRepo;
        private readonly IWebHostEnvironment _env;
        private readonly IRepository<Customer> _customerRepo;

        public ReportController(IRepository<Report> reportRepo, IWebHostEnvironment env, IRepository<Customer> customerRepo)
        {
            _reportRepo = reportRepo;
            _env = env;
            _customerRepo = customerRepo;
        }

        // GET: ReportService
        [HttpGet]
        public IActionResult ReportService(int id)
        {
            ViewBag.ServiceId = id;
            var report = _reportRepo.Find(id);
            return View(report);
        }

        // POST: ReportService
        [HttpPost]
        public IActionResult ReportService(int serviceId, string reason, IFormFile attachment)
        {
            if (string.IsNullOrWhiteSpace(reason))
            {
                ModelState.AddModelError("", "Reason is required.");
                ViewBag.ServiceId = serviceId;
                return View();
            }

            int customerId = 1; 

            string fileName = null;

            if (attachment != null && attachment.Length > 0)
            {
                var uploadsPath = Path.Combine(_env.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadsPath))
                    Directory.CreateDirectory(uploadsPath);

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(attachment.FileName);
                var filePath = Path.Combine(uploadsPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    attachment.CopyTo(stream);
                }
            }

            var report = new Report
            {
                CustomerId = customerId,
                ServiceId = serviceId,
                Reason = reason,
                AttachmentFilePath = fileName,
                Status = "Pending",
                CreatedAt = DateTime.Now
                
            };

            _reportRepo.Add(report);

            TempData["Message"] = "Report submitted successfully.";
            return RedirectToAction("Details", "Service", new { id = serviceId });
        }
    }
}
