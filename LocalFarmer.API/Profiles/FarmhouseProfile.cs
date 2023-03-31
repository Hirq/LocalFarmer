using AutoMapper;
using LocalFarmer.API.ViewModels.DTOs;
using LocalFarmer.Domain.Models;

namespace LocalFarmer.API.Profiles
{
    public class FarmhouseProfile : Profile
    {
        public FarmhouseProfile()
        {
            CreateMap<FarmhouseDto, Farmhouse>();
        }
    }
}
