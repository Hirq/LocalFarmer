namespace LocalFarmer.API.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Farmhouse, FarmhouseViewModel>();
            CreateMap<FarmhouseViewModel, Farmhouse>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
