using AutoMapper;
using LocalFarmer.API.Utilities;
using LocalFarmer.API.ViewModels;
using LocalFarmer.API.ViewModels.DTOs;
using LocalFarmer.Domain.Models;
using LocalFarmer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

//TODO: Pozwracać kody opdowiednie
//POST 201
//DELETE 204

namespace LocalFarmer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmhouseContoller : ControllerBase
    {
        private readonly IFarmhouseRepository _farmhouseRepository;
        private readonly IMapper _mapper;

        public FarmhouseContoller(IFarmhouseRepository farmhouseRepository,
            IMapper mapper)
        {
            _farmhouseRepository = farmhouseRepository;
            _mapper = mapper;
        }

        [HttpGet, Route("ListFarmhouses")]
        public async Task<IActionResult> GetFarmhouses()
        {
            var farmhouses = await _farmhouseRepository.GetAllAsync();

            return Ok(farmhouses);
        }

        [HttpGet, Route("Farmhouse/{id}")]
        public async Task<IActionResult> GetFarmhouse(int id)
        {
            var farmhouse = await _farmhouseRepository.GetSingleAsync(x => x.Id == id);

            return Ok(farmhouse);
        }

        [HttpPost, Route("Farmhouse")]
        public async Task<IActionResult> AddFarmhouse(FarmhouseDto dto)
        {
            var farmhouse = _mapper.Map<Farmhouse>(dto);
            _farmhouseRepository.Add(farmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            return Ok(farmhouse);
        }

        [HttpPut, Route("Farmhouse/{id?}")]
        [SwaggerOperationFilter(typeof(ReApplyOptionalRouteParameterOperationFilter))]
        public async Task<IActionResult> PutFarmhouse(FarmhouseDto dto, int id = 0)
        {
            var farmhouse = _mapper.Map<Farmhouse>(dto);
            if (id != 0)
            {
                farmhouse.Id = id;
            }
            _farmhouseRepository.Update(farmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            return Ok(farmhouse);
        }
        //TODO: Przygotować PATCH według JsonPatchDocument oraz drugi taki aby można było wpisać tylko 1 wartość z modelu
        [HttpPatch, Route("Farmhouse/{id}")]
        public async Task<IActionResult> PatchFarmhouse(JsonPatchDocument<FarmhouseDto> dto, int id)
        {
            var farmhouse = await _farmhouseRepository.GetSingleAsync(x => x.Id == id);
            farmhouse = _mapper.Map<Farmhouse>(dto);
            _farmhouseRepository.Update(farmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            return Ok(farmhouse);
        }

        [HttpDelete, Route("Farmhouse/{id}")]
        public async Task<IActionResult> DeleteFarmhouse(int id)
        {
            Farmhouse farmhouse = await _farmhouseRepository.GetSingleAsync(x => x.Id == id);
            await _farmhouseRepository.DeleteAsync(farmhouse);
            await _farmhouseRepository.SaveChangesAsync();

            return Content($"Delete object farmhouse {id}");
        }
    }
}
