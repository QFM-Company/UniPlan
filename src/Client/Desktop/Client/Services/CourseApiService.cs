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

        public async Task<CourseResponse?> GetCourseByIDAsync(int courseID)
        {
            return await _apiService.GetAsync<CourseResponse>(courseID);
        }

        public async Task<CourseResponse?> CreateCourseAsync(CourseRequest course)
        {
            return await _apiService.PostAsync<CourseRequest, CourseResponse>(course);
        }

        public async Task<bool> UpdateCourseAsync(int courseID, CourseRequest course)
        {
            return await _apiService.PutAsync(courseID, course);
        }

        public async Task<bool> DeleteCourseAsync(int courseID)
        {
            return await _apiService.DeleteAsync(courseID);
        }
    }
}