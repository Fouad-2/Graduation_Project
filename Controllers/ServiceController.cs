using System.IO;
using System.Threading.Tasks;
using System;
using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradFinalProject.Data;
using GradFinalProject.ViewModels;
using System.Linq;

namespace GradFinalProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IRepository<Service> Service;
        private readonly IRepository<Freelancer> _freelancerRepo;
        private readonly IRepository<Comment> _commentRepo; 
        private readonly AppDbContext Context;
        public ServiceController(IRepository<Service> _Service, AppDbContext _Context, IRepository<Comment> commentRepo, IRepository<Freelancer> freelancerRepo)
        {
            Service = _Service;
            Context = _Context;
            _commentRepo = commentRepo;
            _freelancerRepo=freelancerRepo;
        }

        // GET: ServiceController
        public ActionResult Index()
        {
            return View(Service.View());
        }

        // GET: ServiceController/Details/5
        public IActionResult Details(int id)
        {
            var service = Service
                .View()
                .FirstOrDefault(s => s.Id == id && s.IsActive);

            if (service == null)
                return NotFound();

            var freelancer = _freelancerRepo.Find(service.FreelancerId);
            var comment = _commentRepo.View().Where(r => r.ServiceId == id).ToList();

            var vm = new ServiceDetailsViewModel
            {
                Service = service,
                Freelancer = freelancer,
                Comment = comment,
                Customer=new Customer()
            };

            return View(vm);
        }


        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create

        [HttpPost]

        private void FillCategories(int? selectedId = null)
        {
            ViewBag.CategoryId = new SelectList(Context.Categories, "Id", "Name", selectedId);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Service collection, IFormFile serviceImage)
        {
            if (!ModelState.IsValid)
            {
                FillCategories(collection.CategoryId);
                return View(collection); 
            }

            try
            {

                if (serviceImage != null && serviceImage.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(serviceImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await serviceImage.CopyToAsync(stream);
                    }

                    collection.AttachmentPath = "/images/" + fileName;
                }

                var freelancerIdStr = Request.Cookies["FreelancerId"];
                if (string.IsNullOrEmpty(freelancerIdStr) || !int.TryParse(freelancerIdStr, out int freelancerId))
                {
                    return RedirectToAction("Login", "Account");
                }

                collection.FreelancerId = freelancerId;

                if (collection.CategoryId == 0)
                {
                    ModelState.AddModelError("CategoryId", ".");
                    FillCategories(collection.CategoryId);
                    return View(collection);
                }

                Service.Add(collection);
                return RedirectToAction("Dashboard", "Freelancer", new { id = freelancerId });
            }
            catch
            {
                ModelState.AddModelError("", "Erorr.");
                FillCategories(collection.CategoryId);
                return View(collection);
            }
        }



        // POST: ServiceController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Service collection)
        {
            try
            {
                Service.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Service.Find(id));
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Service collection)
        {
            try
            {
                Service.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
