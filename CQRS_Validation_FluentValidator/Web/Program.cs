using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using System;
using System.Threading.Tasks;

namespace Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            await ApplyMigrations(webHost.Services);

            await webHost.RunAsync();
        }

        private static async Task ApplyMigrations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            await using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await dbContext.Database.MigrateAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
