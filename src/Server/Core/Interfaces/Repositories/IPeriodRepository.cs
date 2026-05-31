using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IPeriodRepository
    {
        Task<bool> DeletePeriod(int periodID);

        Task<int> AddPeriod(Period period);

        Task<bool> UpdatePeriod(Period period);

        Task<IEnumerable<Period>?> GetPagedPeriods(int pageNumber = 1, int pageSize = 10);

        Task<Period?> GetPeriodByID(int periodID);
    }
}
