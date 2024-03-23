using Microsoft.AspNetCore.Mvc;
using ZooDvijuha.Interfaces;
using ZooDvijuha.ViewModels;

namespace ZooDvijuha.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };
                result.Add(userViewModel);
            }
            return View(result);
        }

        [HttpPost] // TODO: remove it
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return View(userDetailViewModel);
        }

        //TODO: Add edit user

        //TODO: Add delete user 
    }
}
