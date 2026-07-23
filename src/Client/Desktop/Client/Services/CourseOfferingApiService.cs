using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class CourseOfferingApiService
    {
        private readonly ApiService _apiService;

        public CourseOfferingApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/courseofferings";
        }

        public async Task<List<CourseOfferingResponse>?> GetCourseOfferingsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<CourseOfferingResponse>(pageNumber, pageSize);
        }

        public async Task<CourseOfferingResponse?> GetCourseOfferingByIDAsync(int id)
        {
            return await _apiService.GetAsync<CourseOfferingResponse>(id);
        }

        public async Task<CourseOfferingResponse?> CreateCourseOfferingAsync(CourseOfferingRequest model)
        {
            return await _apiService.PostAsync<CourseOfferingRequest, CourseOfferingResponse>(model);
        }

        public async Task<bool> UpdateCourseOfferingAsync(int id, CourseOfferingRequest model)
        {
            return await _apiService.PutAsync(id, model);
        }

        public async Task<bool> DeleteCourseOfferingAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}