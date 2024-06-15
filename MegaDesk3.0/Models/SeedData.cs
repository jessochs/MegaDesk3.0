using Microsoft.EntityFrameworkCore;
using MegaDesk3._0.Data;


namespace MegaDesk3._0.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDesk3_0Context(
                serviceProvider.GetRequiredService<DbContextOptions<MegaDesk3_0Context>>()))
            {
                if (context == null || context.Desk == null)
                {
                    throw new ArgumentNullException("Null MegaDesk3_0Context");
                }

                if (context.Desk.Any())
                {
                    return;   // DB has been seeded
                }

                context.Desk.AddRange(
                    new Desk
                    {
                        Name = "John Doe",
                        Date = DateTime.Parse("2024-03-14"),
                        Width = 24,
                        Height = 24,
                        Drawers = 2,
                        Material = "Oak",
                        Rush = 3,
                        Price = 460 //50 * 2 + 200 + 200
                    },
                                       
                    new Desk
                    {
                        Name = "Jane Dawson",
                        Date = DateTime.Parse("2024-06-07"),
                        Width = 36,
                        Height = 24,
                        Drawers = 2,
                        Material = "Laminate",
                        Rush = 5,
                        Price = 440 //200 base + 0 surface + 50 * 2 drawers + 100 material + 40 rush
                    },
                                                          
                    new Desk
                    {
                        Name = "John Smith",
                        Date = DateTime.Parse("2023-12-01"),
                        Width = 48,
                        Height = 24,
                        Drawers = 2,
                        Material = "Pine",
                        Rush = 7,
                        Price = 537 //200 base + (48*24) % 1000 = 152 surface area + 50*2 drawers + 50 material + 35 rush 
                    },
                                                                             
                    new Desk
                    {
                        Name = "Jane Johanson",
                        Date = DateTime.Parse("2024-06-14"),
                        Width = 60,
                        Height = 24,
                        Drawers = 3,
                        Material = "Rosewood",
                        Rush = 14,
                        Price = 1090 // 200 base + 60*24 % 1000 = 440 surface area + 50*3 drawers + 300 material + 0 rush
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
