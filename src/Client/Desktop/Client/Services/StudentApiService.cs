using Client.Models.Responses;

namespace Client.Services
{
    public class StudentApiService
    {
        private readonly ApiService _apiService;

        public StudentApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/students";
        }

        public async Task<List<StudentResponse>?> GetStudentsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<StudentResponse>(pageNumber, pageSize);
        }

        public async Task<StudentResponse?> GetStudentAsync(int id)
        {
            return await _apiService.GetAsync<StudentResponse>(id);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}