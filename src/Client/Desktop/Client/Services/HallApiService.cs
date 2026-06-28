using Client.Models;
using System.Net.Http.Json;


namespace Client.Services
{
    public class HallApiService
    {
        private readonly HttpClient _httpClient;

        public HallApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HallModel>> GetHallsAsync()
        {
            try
            {
                var dtos = await _httpClient.GetFromJsonAsync<List<HallModel>>("api/halls/get/1/10");

                if (dtos == null)
                    return new List<HallModel>();

                return dtos.ToList();
            }
            catch
            {
                return new List<HallModel>();
            }
        }
    }
}
