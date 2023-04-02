using AutoMapper;
using LocalFarmer.API.ViewModels.DTOs;
using LocalFarmer.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace LocalFarmer.API.Profiles
{
    public class FarmhouseProfile : Profile
    {
        public FarmhouseProfile()
        {
            CreateMap<FarmhouseDto, Farmhouse>();
            CreateMap<JsonPatchDocument<FarmhouseDto>, JsonPatchDocument<Farmhouse>>();
        }
    }
}
