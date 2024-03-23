using Microsoft.AspNetCore.Identity;
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
                    context.Users.AddRange(new List<AppUser>()
                    {
                        new AppUser()
                        {
                            FirstName = "Tip",
                            LastName = "rovniy",
                            
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "admin1234@gmail.com";
                
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        // FirstName = "11",  // TODO: add firstname 
                        //LastName = "23",  // TODO: add lastname
                        UserName = "Admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address
                        { 
                            Country = "UA",
                            City = "Kyiv",
                            Street = "Centr",
                        }

                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string userEmail = "user1234@gmail.com";

                var user = await userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    var newUser = new AppUser()
                    {
                        //TODO: ADD firstName
                        //TODO: add lastname
                        UserName = "User",
                        Email = userEmail,
                        EmailConfirmed = true,
                        Address = new Address
                        {
                            Country = "UA",
                            City = "Kyiv",
                            Street = "Centr",
                        }
                    };
                    await userManager.CreateAsync(newUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newUser, UserRoles.User);
                }
            }
        }
    }
}
