using Microsoft.EntityFrameworkCore;
using Sample_MVCWebApp.Models;

namespace Sample_MVCWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //CONFIGURE SERVICES
            //------------------------------------------------------

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=Sample_MVCWebApp.db"));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //------------------------------------------------------
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //DATABASE
            //------------------------------------------------------
            using (IServiceScope serviceScope = app.Services.CreateScope())
            using (AppDbContext appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>())
            {
                appDbContext.Database.EnsureDeleted();
                appDbContext.Database.EnsureCreated();
            }

            //RUN
            //------------------------------------------------------

            app.Run();
        }
    }
}