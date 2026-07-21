using Client.Models;
using System.Net.Http.Json;

namespace Client.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public string SubUri { get; set; }

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            SubUri = string.Empty;
        }

        public async Task<List<T>?> GetAsync<T>(int pageNumber, int pageSize)
        {
            string requestUri = $"{SubUri}?pageNumber={pageNumber}&pageSize={pageSize}";
            var response = await _httpClient.GetAsync(requestUri);

            if(!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"فشلت العملية\n{errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<List<T>?>();
        }

        public async Task<T?> GetAsync<T>(int id, string? actionName = null)
        {
            string requestUri = string.IsNullOrEmpty(actionName) ? $"{SubUri}/{id}" : $"{SubUri}/{actionName}/{id}";
            var response = await _httpClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"فشلت العملية\n{errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<T?>();
        }

        public async Task<T?> PostAsync<T>(T model, string? actionName = null)
        {
            string requestUri = string.IsNullOrEmpty(actionName) ? $"{SubUri}" : $"{SubUri}/{actionName}";
            var response = await _httpClient.PostAsJsonAsync(requestUri, model);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"فشلت العملية\n{errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<bool> PutAsync<T>(int id, T model ,string? actionName = null)
        {
            string requestUri = string.IsNullOrEmpty(actionName) ? $"{SubUri}/{id}" : $"{SubUri}/{actionName}/{id}";
            var response = await _httpClient.PutAsJsonAsync(requestUri, model);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"فشلت العملية\n{errorContent}");
            }

            return true;
        }

        public async Task<bool> DeleteAsync(int id, string? actionName = null)
        {
            string requestUri = string.IsNullOrEmpty(actionName) ? $"{SubUri}/{id}" : $"{SubUri}/{actionName}/{id}";
            var response = await _httpClient.DeleteAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"فشلت العملية\n{errorContent}");
            }

            return true;
        }
    }
}
