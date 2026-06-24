using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IGeneratedScheduleRepository
    {
        Task<int> AddGeneratedScheduleAsync(GeneratedSchedule schedule);

        Task<bool> AddScheduleDetailsAsync(GeneratedSchedule schedule);

        Task<GeneratedSchedule?> GetGeneratedScheduleByWishListIDAsync(int listID);
    }
}
