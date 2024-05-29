using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using RentAPitch.Data.Models;
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


        }
    }
}
