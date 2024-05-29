using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentAPitch.Data.Models;

namespace RentAPitch.Data
{
    public class RentAPitchDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public RentAPitchDbContext(DbContextOptions<RentAPitchDbContext> options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Pitch> Pitches { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

       
    }
}
