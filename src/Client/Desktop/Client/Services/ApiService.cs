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

        public async Task<List<TResponse>?> GetAsync<TResponse>(int pageNumber, int pageSize)
        {
            string requestUri = $"{SubUri}?pageNumber={pageNumber}&pageSize={pageSize}";
            var response = await _httpClient.GetAsync(requestUri);

            if(!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception(errorContent);
            }

            return await response.Content.ReadFromJsonAsync<List<TResponse>?>();
        }

        public async Task<TResponse?> GetAsync<TResponse>(int id, string? actionName = null)
        {
            string requestUri = string.IsNullOrEmpty(actionName) ? $"{SubUri}/{id}" : $"{SubUri}/{id}/{actionName}";
            var response = await _httpClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception(errorContent);
            }

            return await response.Content.ReadFromJsonAsync<TResponse?>();
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(TRequest model, string? actionName = null)
        {
            string requestUri = string.IsNullOrEmpty(actionName) ? $"{SubUri}" : $"{SubUri}/{actionName}";
            var response = await _httpClient.PostAsJsonAsync(requestUri, model);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception(errorContent);
            }

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<bool> PutAsync<TRequest>(int id, TRequest model, string? actionName = null)
        {
            string requestUri = string.IsNullOrEmpty(actionName) ? $"{SubUri}/{id}" : $"{SubUri}/{id}/{actionName}";
            var response = await _httpClient.PutAsJsonAsync(requestUri, model);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception(errorContent);
            }

            return true;
        }

        public async Task<bool> DeleteAsync(int id, string? actionName = null)
        {
            string requestUri = string.IsNullOrEmpty(actionName) ? $"{SubUri}/{id}" : $"{SubUri}/{id}/{actionName}";
            var response = await _httpClient.DeleteAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception(errorContent);
            }

            return true;
        }
    }
}
