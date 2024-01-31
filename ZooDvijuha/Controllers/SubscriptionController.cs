using Microsoft.AspNetCore.Mvc;
using System.Net;
using ZooDvijuha.Data;
using ZooDvijuha.Interfaces;
using ZooDvijuha.Models;
using ZooDvijuha.ViewModels;

namespace ZooDvijuha.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionController (ApplicationDbContext context, ISubscriptionRepository subscriptionRepository)
        {
            _context = context;
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Subscription> subscriptions = await _subscriptionRepository.GetAll();
            return View(subscriptions);
        }


        public async Task<IActionResult> Detail(int id)
        {
            //Subscription subscription = await _subscriptionRepository.GetByIdAsync(id);
            Subscription subscription = _context.Subscriptions.FirstOrDefault(s => s.Id == id);
            return View(subscription);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if(subscription == null) return View("Error");
            var subscriptionVM = new EditSubscriptionViewModel
            {
                Title = subscription.Title,
                Price = subscription.Price,
                Description = subscription.Description,
                SubscriptionLevel = subscription.SubscriptionLevel
            };
            return View(subscriptionVM);
        }
    }
}
