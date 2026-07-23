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

        public async Task<AcademicTermResponse?> GetAcademicTermByIDAsync(int termID)
        {
            return await _apiService.GetAsync<AcademicTermResponse>(termID);
        }

        public async Task<AcademicTermResponse?> CreateAcademicTermAsync(AcademicTermRequest term)
        {
            return await _apiService.PostAsync<AcademicTermRequest, AcademicTermResponse>(term);
        }

        public async Task<bool> DeleteAcademicTermAsync(int termID)
        {
            return await _apiService.DeleteAsync(termID);
        }
    }
}