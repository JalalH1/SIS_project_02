using Microsoft.EntityFrameworkCore;
using Project_Info_Jalal_Harb.Models;

namespace Project_Info_Jalal_Harb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddDbContext<DBContext>(options => {
                options.UseSqlServer(
                builder.Configuration["ConnectionStrings:UserContextConnection"]);
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}