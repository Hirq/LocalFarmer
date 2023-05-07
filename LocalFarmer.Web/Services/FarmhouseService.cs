using LocalFarmer.Domain.Models;
using System.Net.Http.Json;

namespace LocalFarmer.Web.Services
{
    public class FarmhouseService : IFarmhouseService
    {
        private readonly HttpClient _http;
        public FarmhouseService(HttpClient http)
        {
            _http = http;
        }

        public List<Farmhouse> Farmhouses {get; set;} = new List<Farmhouse>();
        public Farmhouse Farmhouse {get; set;} = new Farmhouse();

        public async Task<Farmhouse> GetFarmhouse(int id)
        {
            var result = await _http.GetFromJsonAsync<Farmhouse>($"https://localhost:7290/api/Farmhouse/Farmhouse/{id}");
            if (result != null)
            {
                Farmhouse = result;
            }

            return Farmhouse;

        }

        public async Task GetFarmhouses()
        {
            var result = await _http.GetFromJsonAsync<List<Farmhouse>>("https://localhost:7290/api/Farmhouse/ListFarmhouses");

            if (result != null)
            {
                Farmhouses = result;
            }
        }
    }
}
