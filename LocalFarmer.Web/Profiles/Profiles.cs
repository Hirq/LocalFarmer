using LocalFarmer.Web.ViewModels;

namespace LocalFarmer.API.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Farmhouse, FarmhouseViewModel>();
            CreateMap<FarmhouseViewModel, Farmhouse>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            //TODO: Czy to wymagane ForMember?
        }
    }
}
