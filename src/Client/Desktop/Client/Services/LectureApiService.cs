using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class LectureApiService
    {
        private readonly ApiService _apiService;

        public LectureApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/lectures";
        }

        public async Task<List<LectureResponse>?> GetLecturesAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<LectureResponse>(pageNumber, pageSize);
        }

        public async Task<LectureResponse?> GetLectureAsync(int id)
        {
            return await _apiService.GetAsync<LectureResponse>(id);
        }

        public async Task<LectureRequest?> PostLectureAsync(LectureRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> PutLectureAsync(int id, LectureRequest model)
        {
            return await _apiService.PutAsync(id, model);
        }

        public async Task<bool> DeleteLectureAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}