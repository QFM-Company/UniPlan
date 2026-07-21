using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class PeriodApiService
    {
        private readonly ApiService _apiService;

        public PeriodApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/periods";
        }

        public async Task<List<PeriodResponse>?> GetPeriodsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<PeriodResponse>(pageNumber, pageSize);
        }

        public async Task<PeriodResponse?> GetPeriodAsync(int id)
        {
            return await _apiService.GetAsync<PeriodResponse>(id);
        }

        public async Task<PeriodRequest?> PostPeriodAsync(PeriodRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> DeletePeriodAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}