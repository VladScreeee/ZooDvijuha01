using ZooDvijuha.Models;

namespace ZooDvijuha.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Subscription>> GetAllUserSubscriptions();
    }
}
