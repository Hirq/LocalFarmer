using AutoMapper;
using LocalFarmer.Web.ViewModels;
using System;
using System.Net.Http.Json;
using static MudBlazor.CategoryTypes;
using static MudBlazor.Colors;

namespace LocalFarmer.Web.Services
{
    public class FarmhouseService : IFarmhouseService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;

        public FarmhouseService(HttpClient http,
            IMapper mapper)
        {
            _http = http;
            _mapper = mapper;
        }

        public List<Farmhouse> Farmhouses { get; set; } = new List<Farmhouse>();
        public Farmhouse Farmhouse { get; set; } = new Farmhouse();

        public async Task<Farmhouse> GetFarmhouse(int id)
        {
            var result = await _http.GetFromJsonAsync<Farmhouse>($"https://localhost:7290/api/Farmhouse/Farmhouse/{id}");
            if (result != null)
            {
                Farmhouse = result;
            }

            return Farmhouse;

        }

        public async Task<List<Farmhouse>> GetFarmhouses()
        {
            var result = await _http.GetFromJsonAsync<List<Farmhouse>>("https://localhost:7290/api/Farmhouse/ListFarmhouses");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        public async Task<List<Farmhouse>> GetFarmhousesWithProducts()
        {
            var result = await _http.GetFromJsonAsync<List<Farmhouse>>("https://localhost:7290/api/Farmhouse/ListFarmhousesWithProducts");

            if (result == null)
            {
                throw new Exception();
            }

            result = new List<Farmhouse>();

            return result;
        }

        public async Task<List<FarmhouseViewModel>> GetFarmhousesWithProducts2()
        {
            List<Farmhouse> farmhouses = await _http.GetFromJsonAsync<List<Farmhouse>>("https://localhost:7290/api/Farmhouse/ListFarmhousesWithProducts");

            if (farmhouses == null)
            {
                throw new Exception();
            }
            //List<FarmhouseViewModel> result = _mapper.Map<List<FarmhouseViewModel>>(farmhouses);


            List<FarmhouseViewModel> result = _mapper.Map<List<Farmhouse>, List<FarmhouseViewModel>>(farmhouses);

            //TODO: Brakowało Profiles w .Web

            //var result = new List<FarmhouseViewModel>();

            return result;
        }
    }
}
