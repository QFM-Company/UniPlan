using Client.Models;
using System.Net.Http.Json;

namespace Client.Services
{
    public class ApiService<T>  where T : BaseModel
    {
        private readonly HttpClient _httpClient;
        public string SubUri { get; set; }

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            SubUri = string.Empty;
        }

        public async Task<List<T>?> GetAllAsync(int pageNumber, int pageSize)
        {
            string requestUri = $"{SubUri}?pageNumber={pageNumber}&pageSize={pageSize}";
            return await _httpClient.GetFromJsonAsync<List<T>>(requestUri);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            string requestUri = $"{SubUri}/{id}";
            return await _httpClient.GetFromJsonAsync<T>(requestUri);
        }

        public async Task<T?> CreateAsync(T hall)
        {
            string requestUri = $"{SubUri}";
            var response = await _httpClient.PostAsJsonAsync(requestUri, hall);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"فشلت العملية: {errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<bool> UpdateAsync(int id, T hall)
        {
            string requestUri = $"{SubUri}/{id}";
            var response = await _httpClient.PutAsJsonAsync(requestUri, hall);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"فشلت العملية: {errorContent}");
            }

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string requestUri = $"{SubUri}/{id}";
            var response = await _httpClient.DeleteAsync(requestUri);
            return response.IsSuccessStatusCode;
        }
    }
}
