using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentAPitch.CustomMiddleWare;
using RentAPitch.Data;
using RentAPitch.Data.Models;
using RentAPitch.Mapper;
using RentAPitch.Repositories.DataSeeding;
using RentAPitch.Repositories.Implementation;
using RentAPitch.Repositories.Infrastructure;
using RentAPitch.Utility;
using Stripe;

namespace RentAPitch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<RentAPitchDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<RentAPitchDbContext>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPitchRepository, PitchRepository>();
            builder.Services.AddScoped<IDbInitializer, DbInitialize>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IOrderHeaderService, OrderHeaderService>();
            builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
            // builder.Services.AddScoped<IFileStorage, FileStorage>();
            builder.Services.AddAutoMapper(typeof(PitchProfile));


            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<RentAPitchDbContext>();
                                      
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PitchProfile(builder.Environment));
            });
            var mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "PitchProjectCookie";
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.HttpOnly = true;
            });

            builder.Services.AddRazorPages();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                options.LogoutPath = "/Identity/Account/Logout";
            });


            var app = builder.Build();




            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseStaticFiles();
            DataSeeding();
            app.UseSession();
            app.UseRouting();

            StripeConfiguration.ApiKey =
                builder.Configuration.GetSection("PaymentSettings:SecretKey").Get<string>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                     pattern: "{area:exists}/{controller=Pitch}/{action=Index}/{id?}"
                 );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.MapRazorPages();

            app.Run();
            void DataSeeding()
            {
                using (var scope = app.Services.CreateScope())
                {
                    var DbInitial = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                    DbInitial.Initialize();
                }
            }
        }
    }
}