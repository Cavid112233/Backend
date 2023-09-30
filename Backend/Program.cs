using Backend.DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }

            );

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
                "default",
                "{controller=home}/{action=index}/{id?}"

                );
            app.Run();
        }
    }
}