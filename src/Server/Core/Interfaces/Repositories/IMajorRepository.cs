using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IMajorRepository
    {
        Task<int> AddMajor(Major major);
        Task<bool> UpdateMajor(Major major);
        Task<bool> DeleteMajor(int majorID);
        Task<Major?> GetMajorByID(int majorID);
        Task<IEnumerable<Major>?> GetPagedMajors(int pageNumber = 1, int pageSize = 10);
    }
}