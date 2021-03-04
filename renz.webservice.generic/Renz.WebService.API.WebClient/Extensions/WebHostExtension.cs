using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RivTech.WebService.Generic.Data.Context;
using System;
using System.Threading.Tasks;

namespace RivTech.WebService.Generic.WebClient.Extensions
{
    public static class WebHostExtension
    {
        public static async Task <IHost> MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                var environment = services.GetRequiredService<IWebHostEnvironment>();
                logger.LogInformation($"Starting Database Seed for {nameof(AppDbContext)}.");

                using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    try
                    {
                        //if (environment.IsDevelopment())
                        //{
                        //   await context.Database.EnsureDeletedAsync();
                        //}

                        //await context.Database.MigrateAsync();
                        //await context.Database.EnsureCreatedAsync();
                        //logger.LogInformation($"Seeding Data in {nameof(AppDbContext)}.");
                        //await DatabaseSeed.Initialize(context);
                        //logger.LogInformation($"Done Seeding Data in {nameof(AppDbContext)}.");
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex.Message, "An error occurred seeding the Database.");
                        throw;
                    }
                }
            }

            return host;
        }
    }
}
