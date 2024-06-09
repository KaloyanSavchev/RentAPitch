using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey(nameof(PitchId))]
        public int PitchId { get; set; }
        public Pitch Pitch { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int TotalDuration { get; set; }
        public ApplicationUser User { get; set; }
    }
}
