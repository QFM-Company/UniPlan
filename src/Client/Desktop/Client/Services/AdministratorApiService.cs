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
            _apiService.SubUri = "api/admins";
        }

        public async Task<List<AdministratorResponse>?> GetAdministratorsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<AdministratorResponse>(pageNumber, pageSize);
        }

        public async Task<AdministratorResponse?> GetAdministratorByIDAsync(int adminID)
        {
            return await _apiService.GetAsync<AdministratorResponse>(adminID);
        }

        public async Task<AdministratorResponse?> CreateAdministratorAsync(AdministratorRequest admin)
        {
            return await _apiService.PostAsync<AdministratorRequest, AdministratorResponse>(admin);
        }

        public async Task<bool> UpdateAdministratorAsync(int adminID, AdministratorRequest admin)
        {
            return await _apiService.PutAsync(adminID, admin);
        }

        public async Task<bool> DeleteAdministratorAsync(int adminID)
        {
            return await _apiService.DeleteAsync(adminID);
        }
    }
}