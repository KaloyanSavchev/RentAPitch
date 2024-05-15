using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Data.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Pitch Pitch { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
