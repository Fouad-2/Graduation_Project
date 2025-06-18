using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradFinalProject.Controllers
{
    public class CustomerController : Controller

    {
        public IRepository<Customer> Customer {  get; }
        public CustomerController(IRepository<Customer> _Customer) {  
            Customer = _Customer;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(Customer.View());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View(Customer.Find(id));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer collection)
        {
            try
            {
                Customer.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Customer.Find(id));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer collection)
        {
            try
            {
                Customer.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Customer.Find(id));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer collection)
        {
            try
            {
                Customer.Delete(id, collection);    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
