using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Runtime.CompilerServices;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubscriptionController (ISubscriptionRepository subscriptionRepository, IHttpContextAccessor contextAccessor)
        {
            _subscriptionRepository = subscriptionRepository;
            _httpContextAccessor = contextAccessor;
        }
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Subscription> subscriptions = await _subscriptionRepository.GetAll();
            return View(subscriptions);
        }

        public async Task<IActionResult> Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createSubscriptionViewModel = new CreateSubscriptionViewModel { AppUserId = curUserId };
            return View(createSubscriptionViewModel);
        }

        [HttpPost]


        public async Task<IActionResult> Detail(int id)
        {
            Subscription subscription = await _subscriptionRepository.GetByIdAsync(id);
           // Subscription subscription = _context.Subscriptions.FirstOrDefault(s => s.Id == id);
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
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditSubscriptionViewModel subscriptionVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit");
                return View("Edit", subscriptionVM);
            }

            var subscription = new Subscription
            {
                Id = id,
                Title = subscriptionVM.Title,
                Price = subscriptionVM.Price,
                Description = subscriptionVM.Description,
            };
            _subscriptionRepository.Update(subscription);
            return RedirectToAction("Index");
        }
        
    }
}
