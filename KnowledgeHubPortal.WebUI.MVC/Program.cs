using KnowledgeHubPortal.DataAccess;
using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.WebUI.MVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.WebUI.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDbContext<KHPDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<ICatagoriesRepository, CatagoriesEFRepository>();
            builder.Services.AddScoped<IArticlesRepository, ArticlesEFRepository>();


            builder.Services.AddControllersWithViews();

            builder.Services.AddOutputCache(options =>
            {
                // Add a base policy that applies to all endpoints
                options.AddBasePolicy(basePolicy => basePolicy.Expire(TimeSpan.FromSeconds(120)));

                // Add a named policy that applies to selected endpoints
                options.AddPolicy("Expire20", policyBuilder => policyBuilder.Expire(TimeSpan.FromSeconds(20)));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseOutputCache();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
