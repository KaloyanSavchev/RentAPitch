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
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PitchNameMaxLength)]
        public string PitchName { get; set; } = null!;

        [Required]
        [StringLength(LocationMaxLength)]
        public string Location { get; set; } = null!;


        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(PriceForDayMaxValue)]
        public decimal PricePerDay { get; set; }
    }
}
