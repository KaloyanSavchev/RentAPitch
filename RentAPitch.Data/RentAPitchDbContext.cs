using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentAPitch.Data.Models;

namespace RentAPitch.Data
{
    public class RentAPitchDbContext : IdentityDbContext
    {

        public DbSet<User> Users {  get; set; }
        public DbSet<Pitch> Pitches { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public RentAPitchDbContext(DbContextOptions<RentAPitchDbContext> options)
            : base(options)
        {

        }
    }
}
