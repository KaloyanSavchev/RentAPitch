using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Data.Models
{
    public class LandLord 
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<Pitch> Pitches { get; set; } = new List<Pitch>();


    }
}
