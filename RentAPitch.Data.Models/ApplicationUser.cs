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

    public class ApplicationUser : IdentityUser<Guid>
    {      
        //[Required]
        //[StringLength(UserNameMaxLength)]
        //public string UserName { get; set; } = null!;
        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; } = null!;

        //[Required]
        //[StringLength(PhoneNumberMaxLenght)]
        //public int PhoneNumber { get; set; }

        //public bool IsAdmin { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
