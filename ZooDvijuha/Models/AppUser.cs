using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using ZooDvijuha.Data.Enum;

namespace ZooDvijuha.Models
{
    public class AppUser : IdentityUser
    {
       // public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Address Address{ get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Subscription? Subscription { get; set; }
        [ForeignKey("Subscription")]
        public int? SubscriptionId { get; set;}
        // public ICollection<Subscription> Subscriptions { get; set;}
        //public SubscriptionLevel SubscriptionLevel { get; set; }
       // public Subscription? Subscription { get; set; }
    }
}
