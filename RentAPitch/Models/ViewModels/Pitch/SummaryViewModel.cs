using RentAPitch.Data.Models;

namespace RentAPitch.Models.ViewModels.Pitch
{
    public class SummaryViewModel
    {
        public int Id { get; set; }
        public string PitchName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int TotalDuration { get; set; }
        public decimal DailyRate { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
