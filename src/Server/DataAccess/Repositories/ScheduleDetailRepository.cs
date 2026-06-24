using Core.Entities;
using Core.Interfaces.Repositories;

namespace DataAccess.Repositories
{
    public class ScheduleDetailRepository : IScheduleDetailRepository
    {
        public Task<IEnumerable<ScheduleDetail>?> GetScheduleDetailsByScheduleIDAsync(int scheduleID)
        {
            throw new NotImplementedException();
        }
    }
}
