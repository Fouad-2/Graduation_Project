using GradFinalProject.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradFinalProject.Data;
using System.Linq;
using GradFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GradFinalProject.Controllers
{
    public class CategoryController : Controller
    {
       
    private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult All()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = _context.Categories
                .Include(c => c.Services)
                    .ThenInclude(s => s.Freelancer)
                        .ThenInclude(f => f.Customer)
                .Include(c => c.Services)
                    .ThenInclude(s => s.Ratings)
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new CategoryDetailsViewModel
            {
                Category = category,
                Services = category.Services.Select(s => new ServiceCardViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageUrl = s.AttachmentPath,
                    Price = s.Price,
                    Rating = s.Ratings.Any() ? s.Ratings.Average(r => r.Stars) : 0,
                    ProviderName = s.Freelancer?.Customer != null ?
                                   $"{s.Freelancer.Customer.FirstName} {s.Freelancer.Customer.LastName}" : "Unknown",
                    ProviderImage = s.Freelancer?.ProfileImagePath
                }).ToList()
            };

            return View(viewModel);
        }




        //[Route("seed/categories")]
        //public IActionResult SeedCategories()
        //   {
        //       if (_context.Categories.Any())
        //       {
        //           return Content("Categories already exist.");
        //       }

        //          var categories = new List<Category>
        //       {
        //           new Category { CategoryName = "Graphic Design", Description = "Design logos, flyers, etc.", ImageUrl = "images/design.jpg" },
        //           new Category { CategoryName = "Programming", Description = "Build websites, apps, and software.", ImageUrl = "images/programming.jpg" },
        //           new Category { CategoryName = "Content Writing", Description = "Write articles, blogs, and more.", ImageUrl = "images/writing.jpg" },
        //           new Category { CategoryName = "Digital Marketing", Description = "Promote your business online.", ImageUrl = "images/marketing.jpg" },
        //           new Category { CategoryName = "Video Editing", Description = "Edit and produce professional videos.", ImageUrl = "images/video-editing.jpg" },
        //           new Category { CategoryName = "Translation", Description = "Translate documents and content.", ImageUrl = "images/translation.jpg" },
        //           new Category { CategoryName = "Music Production", Description = "Produce and mix music tracks.", ImageUrl = "images/music.jpg" },
        //           new Category { CategoryName = "Photography", Description = "Capture and edit photos.", ImageUrl = "images/photography.jpg" },
        //           new Category { CategoryName = "Business Consulting", Description = "Provide expert business advice.", ImageUrl = "images/consulting.jpg" },
        //           new Category { CategoryName = "3D Modeling", Description = "Create 3D models and animations.", ImageUrl = "images/3d-modeling.jpg" },
        //           new Category { CategoryName = "Voice Over", Description = "Record professional voice overs.", ImageUrl = "images/voice-over.jpg" },
        //           new Category { CategoryName = "Data Entry", Description = "Enter and manage data accurately.", ImageUrl = "images/data-entry.jpg" }
        //       };


        //        _context.Categories.AddRange(categories);
        //        _context.SaveChanges();

        //       return Content("Categories seeded successfully!");
        //    }
    }
}
