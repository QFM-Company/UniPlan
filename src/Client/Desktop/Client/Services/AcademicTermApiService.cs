using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class AcademicTermApiService
    {
        private readonly ApiService _apiService;

        public AcademicTermApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/academicterms";
        }

        public async Task<List<AcademicTermResponse>?> GetAcademicTermsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<AcademicTermResponse>(pageNumber, pageSize);
        }

        public async Task<AcademicTermResponse?> GetAcademicTermAsync(int id)
        {
            return await _apiService.GetAsync<AcademicTermResponse>(id);
        }

        public async Task<AcademicTermRequest?> PostAcademicTermAsync(AcademicTermRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> DeleteAcademicTermAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}