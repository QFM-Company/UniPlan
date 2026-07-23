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

        public async Task<CourseSessionResponse?> GetCourseSessionByIDAsync(int sessionID)
        {
            return await _apiService.GetAsync<CourseSessionResponse>(sessionID);
        }

        public async Task<CourseSessionResponse?> CreateCourseSessionAsync(CourseSessionRequest session)
        {
            return await _apiService.PostAsync<CourseSessionRequest, CourseSessionResponse>(session);
        }

        public async Task<bool> UpdateCourseSessionAsync(int sessionID, CourseSessionRequest session)
        {
            return await _apiService.PutAsync(sessionID, session);
        }

        public async Task<bool> DeleteCourseSessionAsync(int sessionID)
        {
            return await _apiService.DeleteAsync(sessionID);
        }
    }
}