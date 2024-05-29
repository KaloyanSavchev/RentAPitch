using System.ComponentModel.DataAnnotations;

namespace RentAPitch.Models.ViewModels.Pitch
{
    public class PitchViewModel
    {
        public int Id { get; set; }     
        public string PitchName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }

    }
}
