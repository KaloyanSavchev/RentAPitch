using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Data.Models
{
    public class UserDetail
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        public string DrivingLicence { get; set; } = null!;
        [Required]
        public string PhotoProfId { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; }
    }
}
