using ZooDvijuha.Models;

namespace ZooDvijuha.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task <IEnumerable<Subscription>> GetAll();
        Task<Subscription> GetByIdAsync(int id);
      //  Task<Subscription> GetByIdAsyncNoTracking(int id);


        //Task<IEnumerable<Subscription>> GetSumByUsers();

        bool Add(Subscription subscription);
        bool Update(Subscription subscription);
        bool Delete(Subscription subscription);
        bool Save();
    }
}
