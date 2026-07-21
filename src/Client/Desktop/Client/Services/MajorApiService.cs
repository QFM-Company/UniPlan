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

        public async Task<MajorResponse?> GetMajorAsync(int id)
        {
            return await _apiService.GetAsync<MajorResponse>(id);
        }

        public async Task<MajorRequest?> PostMajorAsync(MajorRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> PutMajorAsync(int id, MajorRequest model)
        {
            return await _apiService.PutAsync(id, model);
        }

        public async Task<bool> DeleteMajorAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}