using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PC_BuyNET.Areas.Identity.Data;
using PC_BuyNET.Data;
using PC_BuyNET.Data.Services;

namespace PC_BuyNET
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
           
            builder.Services.AddDbContext<PC_BuyNETDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<PC_BuyNETDbContext>();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ItemService>();
            builder.Services.AddScoped<CartService>();
            builder.Services.AddScoped<SearchService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<OrderService>();

            builder.Services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<PC_BuyNETDbContext>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await DbInitializer.SeedAdminUserAsync(services);
            }

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Item}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
