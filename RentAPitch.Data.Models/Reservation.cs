using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Data.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PitchId { get; set; }
        public Pitch Pitch { get; set; }
    }
}
