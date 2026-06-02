using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IMajorRepository
    {
        Task<int> AddMajorAsync(Major major);

        Task<bool> UpdateMajorAsync(Major major);

        Task<bool> DeleteMajorAsync(int majorID);

        Task<Major?> GetMajorByIDAsync(int majorID);

        Task<IEnumerable<Major>?> GetPagedMajorsAsync(int pageNumber = 1, int pageSize = 10);
    }
}