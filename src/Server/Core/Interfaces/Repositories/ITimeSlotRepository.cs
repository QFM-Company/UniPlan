using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ITimeSlotRepository
    {
        Task<int> AddTimeSlot(TimeSlot timeSlot);
        Task<bool> UpdateTimeSlot(TimeSlot timeSlot);
        Task<bool> DeleteTimeSlot(int slotID);
        Task<TimeSlot?> GetTimeSlotByID(int slotID);
        Task<IEnumerable<TimeSlot>?> GetPagedTimeSlots(int pageNumber = 1, int pageSize = 10);
    }
}