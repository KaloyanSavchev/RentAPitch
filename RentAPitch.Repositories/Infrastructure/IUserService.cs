using RentAPitch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Repositories.Infrastructure
{
    public interface IUserService
    {
        ApplicationUser GetApplicationUser(string userId);
        Task<IEnumerable<ApplicationUser>> GetApplicationUserAsync(string adminId);
        Task AddUserDetail(string userid, UserDetail userDetail);
    }
}
