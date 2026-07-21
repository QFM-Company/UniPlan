using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class HallApiService
    {
        private readonly ApiService _apiService;

        public HallApiService(ApiService apiService)
        {
            _apiService = apiService;

            _apiService.SubUri = "api/halls";
        }

        public async Task<List<HallResponse>?> GetHallsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<HallResponse>(pageNumber, pageSize);
        }

        public async Task<HallResponse?> GetHallAsync(int id)
        {
            return await _apiService.GetAsync<HallResponse>(id);
        }

        public async Task<HallRequest?> PostHallAsync(HallRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> PutHallAsync(int id, HallRequest model)
        {
            return await _apiService.PutAsync(id, model);
        }

        public async Task<bool> DeleteHallAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }

    }
}
