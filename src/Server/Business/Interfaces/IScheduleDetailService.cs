using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IScheduleDetailService
    {
        Task<IEnumerable<ScheduleDetailResponse>?> GetScheduleDetailsByScheduleIDAsync(int scheduleID);
    }
}
