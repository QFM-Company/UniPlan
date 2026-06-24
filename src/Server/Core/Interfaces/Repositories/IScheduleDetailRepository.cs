using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IScheduleDetailRepository
    {
        Task<IEnumerable<ScheduleDetail>?> GetScheduleDetailsByScheduleIDAsync(int scheduleID);
    }
}
