using Client.Models;
using System.Net.Http.Json;

namespace Client.Services
{
    public class HallApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _subUri;

        public HallApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _subUri = "/api/halls";
        }

        public async Task<List<HallModel>?> GetHallsAsync(int pageNumber, int pageSize)
        {
            string requestUri = $"{_subUri}/get/{pageNumber}/{pageSize}";
            return await _httpClient.GetFromJsonAsync<List<HallModel>>(requestUri);
        }

        public async Task<HallModel?> GetHallByIdAsync(int hallId)
        {
            string requestUri = $"{_subUri}/get/{hallId}";
            return await _httpClient.GetFromJsonAsync<HallModel>(requestUri);
        }

        public async Task<HallModel?> CreateHallAsync(HallModel hall)
        {
            string requestUri = $"{_subUri}/add";
            var response = await _httpClient.PostAsJsonAsync(requestUri, hall);
            return await response.Content.ReadFromJsonAsync<HallModel>();
        }

        public async Task<bool> UpdateHallAsync(int hallId, HallModel hall)
        {
            string requestUri = $"{_subUri}/update/{hallId}";
            var response = await _httpClient.PutAsJsonAsync(requestUri, hall);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteHallAsync(int hallId)
        {
            string requestUri = $"{_subUri}/delete/{hallId}";
            var response = await _httpClient.DeleteAsync(requestUri);
            return response.IsSuccessStatusCode;
        }
    }
}
