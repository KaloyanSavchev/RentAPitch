using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentAPitch.Data
{
    public class RentAPitchDbContext : IdentityDbContext
    {
        public RentAPitchDbContext(DbContextOptions<RentAPitchDbContext> options)
            : base(options)
        {

        }
    }
}
