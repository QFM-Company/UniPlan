using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ITimeSlotRepository
    {
        Task<bool> DeleteTimeSlotAsync(int timeSlotID);

        Task<int> AddTimeSlotAsync(TimeSlot timeSlot);

        Task<bool> UpdateTimeSlotAsync(TimeSlot timeSlot);

        Task<IEnumerable<TimeSlot>?> GetPagedTimeSlotsAsync(int pageNumber = 1, int pageSize = 10);

        Task<TimeSlot?> GetTimeSlotByIDAsync(int timeSlotID);
    }
}
