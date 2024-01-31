using ZooDvijuha.Data.Enum;

namespace ZooDvijuha.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public SubscriptionLevel SubscriptionLevel{ get; set; }
       // public ICollection<Subscription> Subscriptions { get; set;}
    }
}
