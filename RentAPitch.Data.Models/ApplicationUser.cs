using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Data.Models
{
    using static Constants.EntityConstants.UserConstants;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(UserNameMaxLength)]
        public string UserName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public ICollection<Reservation> Bookings { get; set; } = new List<Reservation>();  
    }
}
