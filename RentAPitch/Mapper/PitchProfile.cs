using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using RentAPitch.Data.Models;
using RentAPitch.Models.ViewModels.ApplicationUserViewModels;
using RentAPitch.Models.ViewModels.Pitch;
using RentAPitch.Utility;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RentAPitch.Mapper
{
    public class PitchProfile : Profile
    {
        private  IWebHostEnvironment _WebHostEnvironment;
        
        public PitchProfile(IWebHostEnvironment webHostEnvironment)
        {
            _WebHostEnvironment = webHostEnvironment;

            CreateMap<Pitch, PitchViewModel>();

            CreateMap<CreatePitchViewModel, Pitch>()
              .ForMember(destination => destination.ImageUrl,
              opt => opt.MapFrom(source => new ImageUpload(_WebHostEnvironment).SaveImageFile(source.PitchImageUrl)));

            CreateMap<Pitch, EditPitchViewModel>()
                .ForMember(destination => destination.PitchImageUrl, opt => opt.Ignore());

            CreateMap<Pitch, PitchDetailsViewModel>()
               .ForMember(destination => destination.StartDate, opt => opt.Ignore())
               .ForMember(destination => destination.ReturnDate, opt => opt.Ignore());

            CreateMap<EditPitchViewModel, Pitch>()
               .ForMember(destination => destination.ImageUrl,
               opt => opt.MapFrom(source => new ImageUpload(_WebHostEnvironment).SaveImageFile(source.PitchImageUrl)));

            CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(destination => destination.UserId, opt => opt.MapFrom(source => source.Id));
        }
    }
}
