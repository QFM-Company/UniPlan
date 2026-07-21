using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class CourseApiService
    {
        private readonly ApiService _apiService;

        public CourseApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/courses";
        }

        public async Task<List<CourseResponse>?> GetCoursesAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<CourseResponse>(pageNumber, pageSize);
        }

        public async Task<CourseResponse?> GetCourseAsync(int id)
        {
            return await _apiService.GetAsync<CourseResponse>(id);
        }

        public async Task<CourseRequest?> PostCourseAsync(CourseRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> PutCourseAsync(int id, CourseRequest model)
        {
            return await _apiService.PutAsync(id, model);
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}