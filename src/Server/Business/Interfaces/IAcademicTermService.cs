using Business.DTOs.Requests;
using Business.DTOs.Responses;

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
