﻿namespace LocalFarmer.Web.Services
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

        public async Task<Farmhouse> GetFarmhouse(int id)
        {
            var result = await _http.GetFromJsonAsync<Farmhouse>($"https://localhost:7290/api/Farmhouse/Farmhouse/{id}");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
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

        public async Task<List<FarmhouseViewModel>> GetFarmhousesWithProductsAndButton()
        {
            var farmhouses = await _http.GetFromJsonAsync<List<Farmhouse>>("https://localhost:7290/api/Farmhouse/ListFarmhousesWithProducts");

            if (farmhouses == null)
            {
                throw new Exception();
            }

            var result = _mapper.Map<List<FarmhouseViewModel>>(farmhouses);

            return result;
        }
    }
}
