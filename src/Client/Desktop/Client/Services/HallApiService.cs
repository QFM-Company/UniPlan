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

        public async Task<HallResponse?> GetHallByIDAsync(int hallID)
        {
            return await _apiService.GetAsync<HallResponse>(hallID);
        }

        public async Task<HallResponse?> CreateHallAsync(HallRequest hall)
        {
            return await _apiService.PostAsync<HallRequest, HallResponse>(hall);
        }

        public async Task<bool> UpdateHallAsync(int hallID, HallRequest hall)
        {
            return await _apiService.PutAsync(hallID, hall);
        }

        public async Task<bool> DeleteHallAsync(int hallID)
        {
            return await _apiService.DeleteAsync(hallID);
        }

    }
}
