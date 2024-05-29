using RentAPitch.Utility;

namespace RentAPitch.Models.ViewModels.Pitch
{
    public class ListPitchViewModel
    {
        public IEnumerable<PitchViewModel> PitchList { get; set; }

        public PageInfo PageInfo { get; set; }
        public string SearchingText { get; set; }
    }
}
