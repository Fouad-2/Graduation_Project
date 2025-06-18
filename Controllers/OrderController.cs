using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradFinalProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepository<Order> Order;
        public OrderController(IRepository<Order> _Order)
        {
            Order = _Order;
        }


        // GET: OrderController
        public ActionResult Index()
        {
            return View(Order.View());
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View(Order.Find(id));
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order collection)
        {
            try
            {
                Order.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Order.Find(id));
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order collection)
        {
            try
            {
                Order.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Order.Find(id));
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order collection)
        {
            try
            {
                Order.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult AcceptOrder(int orderId)
        {
            var order = Order.Find(orderId);
            if (order != null)
            {
                order.Status = "Accepted";
                Order.Update( orderId,order);
            }

            return RedirectToAction("ManageService", "Freelancer", new { id = order.FreelancerId });
        }
    }
}
    
