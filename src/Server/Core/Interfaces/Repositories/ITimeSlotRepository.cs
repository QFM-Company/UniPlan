using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ITimeSlotRepository
    {
        Task<bool> DeleteTimeSlot(int timeSlotID);

        Task<int> AddTimeSlot(TimeSlot timeSlot);

        Task<bool> UpdateTimeSlot(TimeSlot timeSlot);

        Task<IEnumerable<TimeSlot>?> GetPagedTimeSlots(int pageNumber = 1, int pageSize = 10);

        Task<TimeSlot?> GetTimeSlotByID(int timeSlotID);
    }
}
