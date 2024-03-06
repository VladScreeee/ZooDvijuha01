using Microsoft.AspNetCore.Mvc;
using ZooDvijuha.Data;
using ZooDvijuha.Interfaces;
using ZooDvijuha.ViewModels;

namespace ZooDvijuha.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userSubs = await _dashboardRepository.GetAllUserSubscriptions();
            var dashboardViewModel = new DashboardViewModel()
            {
                Subscriptions = userSubs,
            };
            return View(dashboardViewModel);
        }
    }
}
