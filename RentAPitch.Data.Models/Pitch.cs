using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Data.Models
{
    using static Constants.EntityConstants.PitchConstants;
    public class Pitch
    {
        public Pitch()
        {
            CreatedAt = DateTime.UtcNow;
            IsAvailable = true;
            IsDelete = false;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PitchNameMaxLength)]
        public string PitchName { get; set; } = null!;       

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(PriceForDayMaxValue)]
        public decimal PricePerDay { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } 

        [Required]
        public DateTime UpdatedAt { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
