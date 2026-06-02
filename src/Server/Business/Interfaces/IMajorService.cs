using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IMajorService
    {
        Task<bool> DeleteMajorAsync(int majorID);

        Task<MajorResponse?> AddMajorAsync(MajorRequest request);

        Task<MajorResponse?> UpdateMajorAsync(MajorRequest request, int majorID);

        Task<IEnumerable<MajorResponse>?> GetPagedMajorsAsync(int pageNumber = 1, int pageSize = 10);

        Task<MajorResponse?> GetMajorByIDAsync(int majorID);
    }
}
