using Microsoft.EntityFrameworkCore;
using ZooDvijuha.Data;
using ZooDvijuha.Interfaces;
using ZooDvijuha.Models;

namespace ZooDvijuha.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Subscription subscription)
        {
            _context.Add(subscription);
            return Save();
        }

        public bool Delete(Subscription subscription)
        {
            _context.Remove(subscription);
            return Save();
        }

        public async Task<IEnumerable<Subscription>> GetAll()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription> GetByIdAsync(int id)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(i => i.Id == id);
            
        }

     //   public async Task<Subscription> GetByIdAsyncNoTracking(int id)
      //  {
      //      return await _context.Subscriptions.FirstOrDefaultAsync(i => i.Id == id);
      //  }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Subscription subscription)
        {
            _context.Update(subscription);
            return Save();
        }

        async Task<Subscription> ISubscriptionRepository.GetByIdAsync(int id)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
