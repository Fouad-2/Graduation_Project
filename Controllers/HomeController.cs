using System.Linq;
using GradFinalProject.Data;
using GradFinalProject.Models.Repositories;
using GradFinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GradFinalProject.Controllers
{
    public class HomeController : Controller
    {
           
        private readonly IRepository<Category> _categoryRepo;

        public HomeController(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepo.View().Take(6).ToList();
            return View(categories); 
        }

        public IActionResult AllCategories()
        {
            var allCategories = _categoryRepo.View();
            return View(allCategories);
        }
    }

}

