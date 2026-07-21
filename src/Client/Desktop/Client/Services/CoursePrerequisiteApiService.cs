using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class CoursePrerequisiteApiService
    {
        private readonly ApiService _apiService;

        public CoursePrerequisiteApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/courseprerequisites";
        }

        public async Task<List<CoursePrerequisiteResponse>?> GetCoursePrerequisitesAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<CoursePrerequisiteResponse>(pageNumber, pageSize);
        }

        public async Task<CoursePrerequisiteResponse?> GetCoursePrerequisiteAsync(int id)
        {
            return await _apiService.GetAsync<CoursePrerequisiteResponse>(id);
        }

        public async Task<CoursePrerequisiteRequest?> PostCoursePrerequisiteAsync(CoursePrerequisiteRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> DeleteCoursePrerequisiteAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}