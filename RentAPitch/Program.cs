using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentAPitch.CustomMiddleWare;
using RentAPitch.Data;
using RentAPitch.Data.Models;
using RentAPitch.Mapper;
using RentAPitch.Repositories.Implementation;
using RentAPitch.Repositories.Infrastructure;

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

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<RentAPitchDbContext>();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PitchProfile(builder.Environment));
            });
            var mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "RentAPitchProjectCookie";
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.HttpOnly = true;
            });

            builder.Services.AddScoped<IPitchRepository, PitchRepository >();

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPitchRepository, PitchRepository>();
            builder.Services.AddAutoMapper(typeof(PitchRepository));
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Pitch}/{action=Index}/{id?}");
            
            app.MapRazorPages();

            app.Run();
        }
    }
}