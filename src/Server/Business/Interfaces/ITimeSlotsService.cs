using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface ITimeSlotsService
    {
        Task<IEnumerable<TimeSlotResponse>> GetPageTimeSlotsAsync(int pageNumber, int pageSize);
        Task<TimeSlotResponse?> GetTimeSlotByIdAsync(int timeSlotID);
        Task<TimeSlotResponse?> AddTimeSlotAsync(TimeSlotRequest timeSlot);
        Task<TimeSlotResponse?> UpdateTimeSlotAsync(int timeSlotID, TimeSlotRequest timeSlot);
        Task<bool> DeleteTimeSlotAsync(int timeSlotID);

    }
}
