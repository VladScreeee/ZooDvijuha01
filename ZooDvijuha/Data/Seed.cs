using ZooDvijuha.Data.Enum;
using ZooDvijuha.Models;

namespace ZooDvijuha.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                if (!context.Subscriptions.Any())
                {
                    context.Subscriptions.AddRange(new List<Subscription>()
                    {
                        new Subscription()
                        {
                            Title = "Experimental",
                            Description = "Cheap for you",
                            SubscriptionLevel = SubscriptionLevel.Experimental

                        },
                        new Subscription()
                        {
                            Title = "Standart",
                            Description = "Normal for you",
                            SubscriptionLevel = SubscriptionLevel.Standart
                        },
                        new Subscription()
                        {
                            Title = "Rich",
                            Description = "High Price",
                            SubscriptionLevel = SubscriptionLevel.Rich
                        }
                    });
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            FirstName = "Tip",
                            LastName = "rovniy",
                            
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
