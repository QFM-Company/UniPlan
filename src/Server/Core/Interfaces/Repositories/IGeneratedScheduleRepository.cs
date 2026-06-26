using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IGeneratedScheduleRepository
    {
        Task<bool> AddGeneratedScheduleAsync(GeneratedSchedule schedule);

        Task<GeneratedSchedule?> GetGeneratedScheduleByWishListIDAsync(int listID);
    }
}
