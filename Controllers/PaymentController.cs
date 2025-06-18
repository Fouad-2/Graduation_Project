using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using System.Collections.Generic;
using System;

public class PaymentController : Controller
{
    private readonly IRepository<Order> _orderRepo;
    private readonly IRepository<Service> _serviceRepo;

    public PaymentController(IRepository<Order> orderRepo, IRepository<Service> serviceRepo)
    {
        _orderRepo = orderRepo;
        _serviceRepo = serviceRepo;
        // Load API key from environment variable
        Stripe.StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY");
    }

    [HttpPost]
    public IActionResult CreateCheckoutSession(int serviceId, int customerId,int freelancerId)
    {
        var service = _serviceRepo.Find(serviceId);
        if (service == null) return NotFound();

        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        UnitAmount = (long)(service.Price * 100), // price in cents
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = service.Title
                        }
                    },
                    Quantity = 1
                }
            },
            Mode = "payment",
            SuccessUrl = Url.Action("PaymentSuccess", "Payment", new { serviceId=serviceId, customerId=customerId ,freelancerId= freelancerId }, Request.Scheme),
            CancelUrl = Url.Action("PaymentCancel", "Payment", null, Request.Scheme),
        };

        var serviceSession = new SessionService();
        Session session = serviceSession.Create(options);

        return Redirect(session.Url);
    }

    public IActionResult PaymentCancel()
    {
        return View(); 
    }

    public IActionResult PaymentSuccess(int serviceId, int customerId,int freelancerId)
    {
   
        var order = new Order
        {
            FreelancerId = freelancerId,
            ServiceId = serviceId,
            CustomerId = customerId,
            Status = "Pending",
        
        };


        _orderRepo.Add(order);

        return RedirectToAction("Details", "Service", new { id=serviceId}); 
    }
}
