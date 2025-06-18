using System.Linq;
using System;
using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradFinalProject.ViewModels;

namespace GradFinalProject.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRepository<Rating> Rating;

        public readonly IRepository<Service> _serviceRepo;
        public RatingController(IRepository<Rating> _Rating, IRepository<Service> serviceRepo)
        {
            Rating = _Rating;
            //Rating = _Rating;
            _serviceRepo = serviceRepo;
        }

        // GET: RatingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rating collection)
        {
            try
            {
                Rating.Add(collection); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Rate(int serviceId)
        {

            var service = _serviceRepo.View().FirstOrDefault(s => s.Id == serviceId);
            if (service == null)
                return NotFound();

            var viewModel = new RateViewModel
            {
                ServiceId = service.Id,
                ServiceTitle = service.Title,
                FreelancerName = service.Freelancer.Customer?.FirstName+service.Freelancer.Customer?.LastName ?? "Unknown"
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Rate(RateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            string customerIdStr = Request.Cookies["CustomerId"];
            if (string.IsNullOrEmpty(customerIdStr) || !int.TryParse(customerIdStr, out int customerId))
                return RedirectToAction("Login", "Account");

            var existingRating = Rating.View()
                .FirstOrDefault(r => r.ServiceId == model.ServiceId && r.CustomerId == customerId);

            if (existingRating != null)
            {
                existingRating.Stars = model.Stars;
                existingRating.CreatedAt = DateTime.Now;
                Rating.Update(existingRating.Id, existingRating);
            }
            else
            {
                Rating newRating = new Rating
                {
                    ServiceId = model.ServiceId,
                    CustomerId = customerId,
                    Stars = model.Stars,
                    CreatedAt = DateTime.Now
                };

                Rating.Add(newRating);
            }

            return RedirectToAction("Details", "Service", new { id = model.ServiceId });
        }



    }
}
