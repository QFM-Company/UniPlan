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

        public async Task<PeriodResponse?> GetPeriodByIDAsync(int periodID)
        {
            return await _apiService.GetAsync<PeriodResponse>(periodID);
        }

        public async Task<PeriodResponse?> CreatePeriodAsync(PeriodRequest period)
        {
            return await _apiService.PostAsync<PeriodRequest, PeriodResponse>(period);
        }

        public async Task<bool> DeletePeriodAsync(int periodID)
        {
            return await _apiService.DeleteAsync(periodID);
        }
    }
}