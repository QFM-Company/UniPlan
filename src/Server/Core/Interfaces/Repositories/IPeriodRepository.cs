using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IPeriodRepository
    {
        Task<int> AddPeriod(Period period);
        Task<bool> UpdatePeriod(Period period);
        Task<bool> DeletePeriod(int periodID);
        Task<Period?> GetPeriodByID(int periodID);
        Task<IEnumerable<Period>?> GetPagedPeriods(int pageNumber = 1, int pageSize = 10);
    }
}