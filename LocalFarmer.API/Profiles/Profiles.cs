using AutoMapper;
using LocalFarmer.API.ViewModels.DTOs;
using LocalFarmer.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace LocalFarmer.API.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<FarmhouseDto, Farmhouse>();
            CreateMap<Farmhouse, FarmhouseDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
