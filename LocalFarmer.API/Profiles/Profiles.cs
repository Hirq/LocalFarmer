using AutoMapper;
using LocalFarmer.API.ViewModels.DTOs;
using LocalFarmer.Domain.Models;

namespace LocalFarmer.API.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<FarmhouseDto, Farmhouse>();
            CreateMap<ProductDto, Product>();
        }
    }
}
