using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentAPitch.Data.Models;

namespace RentAPitch.Data
{
    public class RentAPitchDbContext : IdentityDbContext<ApplicationUser>
    {
        public RentAPitchDbContext(DbContextOptions<RentAPitchDbContext> options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Pitch> Pitches { get; set; }
        //public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

    }
}
