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

        public Task<IEnumerable<Subscription>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
