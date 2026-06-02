using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IPeriodRepository
    {
        Task<bool> DeletePeriodAsync(int periodID);

        Task<int> AddPeriodAsync(Period period);

        Task<bool> UpdatePeriodAsync(Period period);

        Task<IEnumerable<Period>?> GetPagedPeriodsAsync(int pageNumber = 1, int pageSize = 10);

        Task<Period?> GetPeriodByIDAsync(int periodID);
    }
}
