using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class AdministratorApiService
    {
        private readonly ApiService _apiService;

        public AdministratorApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/administrators";
        }

        public async Task<List<AdministratorResponse>?> GetAdministratorsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<AdministratorResponse>(pageNumber, pageSize);
        }

        public async Task<AdministratorResponse?> GetAdministratorAsync(int id)
        {
            return await _apiService.GetAsync<AdministratorResponse>(id);
        }

        public async Task<AdministratorRequest?> PostAdministratorAsync(AdministratorRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> PutAdministratorAsync(int id, AdministratorRequest model)
        {
            return await _apiService.PutAsync(id, model);
        }

        public async Task<bool> DeleteAdministratorAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}