namespace RentAPitch.Models.ViewModels.Pitch
{
    public class EditPitchViewModel
    {
        public int Id { get; set; }
        public string PitchName { get; set; } 
        public string Description { get; set; } 
        public IFormFile PitchImageUrl { get; set; } 
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public decimal DailyRate { get; set; }
    }
}
