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

        [ForeignKey(nameof(ApplicationUser))]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Reservation))]
        public int PitchId { get; set; }
        public Pitch Pitch { get; set; } = null!;
    }
}
