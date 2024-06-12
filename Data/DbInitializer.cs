using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HotelListingAPI.Models;

namespace HotelListingAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app, bool isDevelopment)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            if (isDevelopment)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                context.Database.EnsureDeleted();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                context.Database.EnsureCreated();

                // Seed data
                if (!context.Hotels.Any())
                {
                    context.Hotels.AddRange(
                        new Hotel { Name = "Hotel One", Address = "123 Main St", City = "CityOne", Country = "CountryOne" },
                        new Hotel { Name = "Hotel Two", Address = "456 Main St", City = "CityTwo", Country = "CountryTwo" }
                    );
                    context.SaveChanges();
                }
            }
            else
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                context.Database.Migrate();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }
    }
}
