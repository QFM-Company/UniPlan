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
            _apiService.SubUri = "api/coursePrequists";
        }

        public async Task<List<CoursePrerequisiteResponse>?> GetCoursePrerequisitesAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<CoursePrerequisiteResponse>(pageNumber, pageSize);
        }

        public async Task<CoursePrerequisiteResponse?> GetCoursePrerequisiteByIDAsync(int prerequisiteID)
        {
            return await _apiService.GetAsync<CoursePrerequisiteResponse>(prerequisiteID);
        }

        public async Task<CoursePrerequisiteResponse?> CreateCoursePrerequisiteAsync(CoursePrerequisiteRequest prerequisite)
        {
            return await _apiService.PostAsync<CoursePrerequisiteRequest, CoursePrerequisiteResponse>(prerequisite);
        }

        public async Task<bool> DeleteCoursePrerequisiteAsync(int prerequisiteID)
        {
            return await _apiService.DeleteAsync(prerequisiteID);
        }
    }
}