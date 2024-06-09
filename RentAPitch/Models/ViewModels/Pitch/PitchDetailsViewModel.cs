using System.ComponentModel.DataAnnotations;

namespace RentAPitch.Models.ViewModels.Pitch
{
    public class PitchDetailsViewModel
    {
        public int Id { get; set; }

        public string PitchName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal PricePerDay { get; set; }
        public decimal DailyRate { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please select a Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Return Date")]
        [Required(ErrorMessage = "Please select a End Date")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
