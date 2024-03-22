using Microsoft.EntityFrameworkCore;
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
            var userSubs = _context.Subscriptions.Where(r => r.AppUser.Id == curUser);
            return userSubs.ToList();
        }
        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<AppUser> GetByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }
        
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
