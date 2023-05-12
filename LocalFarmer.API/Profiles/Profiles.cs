namespace LocalFarmer.API.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<FarmhouseDto, Farmhouse>();
            CreateMap<Farmhouse, FarmhouseDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
