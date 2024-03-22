using Microsoft.AspNetCore.Mvc;
using ZooDvijuha.Data;
using ZooDvijuha.Interfaces;
using ZooDvijuha.Models;
using ZooDvijuha.ViewModels;

namespace ZooDvijuha.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(IDashboardRepository dashboardRepository, IHttpContextAccessor httpContextAccessor)
        {
            _dashboardRepository = dashboardRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        private void MapUserEdit(AppUser user, EditUserDashboardViewModel editVM)
        {
            user.Id = editVM.Id;
            user.FirstName = editVM.FirstName;
            user.LastName = editVM.LastName;
            user.Region = editVM.Region;
            user.City = editVM.City;
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

        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardRepository.GetUserById(curUserId);
            if (user == null) return View("Error");
            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = curUserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Region = user.Region,
                City = user.City
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editVM);
            }
            var user = await _dashboardRepository.GetByIdNoTracking(editVM.Id);

            // if (user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            // {
            //    var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

            //    MapUserEdit(user, editVM, photoResult);

            //    _dashboardRepository.Update(user);
            //    return RedirectToAction("Index");
            // }

            return RedirectToAction("Index");
        }
    }
}
