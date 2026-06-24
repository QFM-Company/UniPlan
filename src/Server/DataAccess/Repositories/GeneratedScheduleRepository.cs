using Core.Entities;
using Core.Interfaces.Repositories;

namespace DataAccess.Repositories
{
    public class GeneratedScheduleRepository : IGeneratedScheduleRepository
    {
        public Task<int> AddGeneratedScheduleAsync(GeneratedSchedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddScheduleDetailsAsync(GeneratedSchedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<GeneratedSchedule?> GetGeneratedScheduleByWishListIDAsync(int listID)
        {
            throw new NotImplementedException();
        }
    }
}
