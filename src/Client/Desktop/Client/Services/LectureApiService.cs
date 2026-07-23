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

        public async Task<LectureResponse?> GetLectureByIDAsync(int lectureID)
        {
            return await _apiService.GetAsync<LectureResponse>(lectureID);
        }

        public async Task<LectureResponse?> CreateLectureAsync(LectureRequest lecture)
        {
            return await _apiService.PostAsync<LectureRequest, LectureResponse>(lecture);
        }

        public async Task<bool> UpdateLectureAsync(int lectureID, LectureRequest lecture)
        {
            return await _apiService.PutAsync(lectureID, lecture);
        }

        public async Task<bool> DeleteLectureAsync(int lectureID)
        {
            return await _apiService.DeleteAsync(lectureID);
        }
    }
}