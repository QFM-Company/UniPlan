using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class MajorApiService
    {
        private readonly ApiService _apiService;

        public MajorApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/majors";
        }

        public async Task<List<MajorResponse>?> GetMajorsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<MajorResponse>(pageNumber, pageSize);
        }

        public async Task<MajorResponse?> GetMajorByIDAsync(int majorID)
        {
            return await _apiService.GetAsync<MajorResponse>(majorID);
        }

        public async Task<MajorResponse?> CreateMajorAsync(MajorRequest major)
        {
            return await _apiService.PostAsync<MajorRequest, MajorResponse>(major);
        }

        public async Task<bool> UpdateMajorAsync(int majorID, MajorRequest major)
        {
            return await _apiService.PutAsync(majorID, major);
        }

        public async Task<bool> DeleteMajorAsync(int majorID)
        {
            return await _apiService.DeleteAsync(majorID);
        }
    }
}