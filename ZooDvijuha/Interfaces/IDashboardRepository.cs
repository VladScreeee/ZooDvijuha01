using ZooDvijuha.Models;

namespace ZooDvijuha.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Subscription>> GetAllUserSubscriptions();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
