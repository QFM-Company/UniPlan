using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class CourseSessionApiService
    {
        private readonly ApiService _apiService;

        public CourseSessionApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/coursesessions";
        }

        public async Task<List<CourseSessionResponse>?> GetCourseSessionsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<CourseSessionResponse>(pageNumber, pageSize);
        }

        public async Task<CourseSessionResponse?> GetCourseSessionAsync(int id)
        {
            return await _apiService.GetAsync<CourseSessionResponse>(id);
        }

        public async Task<CourseSessionRequest?> PostCourseSessionAsync(CourseSessionRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> PutCourseSessionAsync(int id, CourseSessionRequest model)
        {
            return await _apiService.PutAsync(id, model);
        }

        public async Task<bool> DeleteCourseSessionAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}