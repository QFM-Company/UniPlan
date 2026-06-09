using Business.DTOs.Responses;
using Business.DTOs.Requests;

namespace Business.Interfaces
{
    public interface IAcademicTermService
    {
        Task<bool> DeleteAcademicTermAsync(int termID);

        Task<AcademicTermResponse?> AddAcademicTermAsync(AcademicTermRequest request);

        Task<IEnumerable<AcademicTermResponse>?> GetPagedAcademicTermsAsync(int pageNumber = 1, int pageSize = 10);

        Task<AcademicTermResponse?> GetAcademicTermByIDAsync(int termID);
    }
}
