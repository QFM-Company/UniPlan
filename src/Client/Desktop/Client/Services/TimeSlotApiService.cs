using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class TimeSlotApiService
    {
        private readonly ApiService _apiService;

        public TimeSlotApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/timeslots";
        }

        public async Task<List<TimeSlotResponse>?> GetTimeSlotsAsync(int pageNumber, int pageSize)
        {
            return await _apiService.GetAsync<TimeSlotResponse>(pageNumber, pageSize);
        }

        public async Task<TimeSlotResponse?> GetTimeSlotByIDAsync(int timeSlotID)
        {
            return await _apiService.GetAsync<TimeSlotResponse>(timeSlotID);
        }

        public async Task<TimeSlotResponse?> CreateTimeSlotAsync(TimeSlotRequest timeSlot)
        {
            return await _apiService.PostAsync<TimeSlotRequest, TimeSlotResponse>(timeSlot);
        }

        public async Task<bool> UpdateTimeSlotAsync(int timeSlotID, TimeSlotRequest timeSlot)
        {
            return await _apiService.PutAsync(timeSlotID, timeSlot);
        }

        public async Task<bool> DeleteTimeSlotAsync(int timeSlotID)
        {
            return await _apiService.DeleteAsync(timeSlotID);
        }
    }
}