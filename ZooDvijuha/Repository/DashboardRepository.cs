using ZooDvijuha.Data;
using ZooDvijuha.Interfaces;
using ZooDvijuha.Models;

namespace ZooDvijuha.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Subscription>> GetAllUserSubscriptions()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userSubs = _context.Subscriptions.Where(r => r.AppUser.Id == curUser.ToString());
            return userSubs.ToList();
            
        }
    }
}
