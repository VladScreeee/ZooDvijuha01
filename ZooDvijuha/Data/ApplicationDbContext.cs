using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooDvijuha.Data.Enum;
using ZooDvijuha.Models;

namespace ZooDvijuha.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Subscription>().Property(x=>x.SubscriptionLevel).HasConversion(new EnumToStringConverter<SubscriptionLevel>());
            modelBuilder.Entity<AppUser>().Property(x => x.AddressId).IsRequired(false);
        }
    }
}
