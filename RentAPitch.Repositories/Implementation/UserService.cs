using Microsoft.EntityFrameworkCore;
using RentAPitch.Data;
using RentAPitch.Data.Models;
using RentAPitch.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Repositories.Implementation
{
    public class UserService : IUserService
    {
        private RentAPitchDbContext _context;

        public UserService(RentAPitchDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetApplicationUser(string userId)
        {
            var applicationUser = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();
            return applicationUser;
        }

        public async Task<IEnumerable<ApplicationUser>> GetApplicationUserAsync(string adminId)
        {
            var users = await _context.ApplicationUsers.Where(x => x.Id != adminId).ToListAsync();
            return users;
        }
        public async Task AddUserDetail(string userid, UserDetail userDetail)
        {
            //var user = _context.ApplicationUsers.Where(x=> x.Id == userid).FirstOrDefault();
            await _context.UserDetails.AddAsync(userDetail);
            await _context.SaveChangesAsync();
        }
    }
}
