using System;
using System.Linq;
using GradFinalProject.Data;
using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace GradFinalProject.Controllers
{
    public class AccountController : Controller
    {

        private readonly AppDbContext Context;
        private readonly IRepository<Freelancer> freelancerRepo;

        public AccountController(AppDbContext _Context,IRepository<Freelancer>FreelancerRepo)
        {
            Context = _Context;
            freelancerRepo = FreelancerRepo;
        }


        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }
        
        // POST: Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = Context.Customers.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {

                Response.Cookies.Append("IsLoggedIn", "true", new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });

                Response.Cookies.Append("CustomerId", user.Id.ToString(), new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });

                if (user.IsFreelancer)
                {
                    var fl = freelancerRepo.FindByCustomerId(user.Id);
                    Response.Cookies.Append("FreelancerId", fl.Id.ToString(), new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTimeOffset.UtcNow.AddDays(7)
                    });
                    return RedirectToAction("Dashboard", "Freelancer", new { id = fl.Id });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View();
            }
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View(); 
        }

        // POST: Account/Register
        [HttpPost]
        public IActionResult Register(Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Check if password and confirm password match
                if (customer.Password != customer.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Password and Confirm Password do not match.");
                    return View(customer);
                }

                // If everything is valid, save the customer to the database
                Context.Customers.Add(customer);
                Context.SaveChanges();
                //HttpContext.Session.SetInt32("CustomerId", customer.Id);
                var user = Context.Customers.FirstOrDefault(u => u.Email == customer.Email && u.Password == customer.Password);
                Response.Cookies.Append("IsLoggedIn", "true", new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });

                Response.Cookies.Append("CustomerId", user.Id.ToString(), new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });

                return RedirectToAction("ChooseRole", "Account");
            }

            // If model state is not valid, return the view with validation errors
            return View(customer);
        }
        //
        // GET Acount/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("IsLoggedIn");
            Response.Cookies.Delete("FreelancerId");
            Response.Cookies.Delete("CustomerId");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChooseRole()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterFreelancer()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult RegisterFreelancer(Freelancer freelancer)
        {
           
            string customerIdString = Request.Cookies["CustomerId"];

            if (string.IsNullOrEmpty(customerIdString) || !int.TryParse(customerIdString, out int customerId))
            {
                return RedirectToAction("Register", "Account");
            }

            freelancer.CustomerId = customerId;

            Context.Freelancers.Add(freelancer);

            var customer=Context.Customers.Find(customerId);
            customer.IsFreelancer = true;
            Context.Customers.Update(customer);
            Context.SaveChanges();
            var fl= freelancerRepo.FindByCustomerId(customerId);
            Response.Cookies.Append("FreelancerId", fl.Id.ToString(), new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });
            return RedirectToAction("Dashboard", "Freelancer", new {id= fl.Id });
        }


    }
}
