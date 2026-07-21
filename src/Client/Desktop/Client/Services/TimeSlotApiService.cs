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

        public async Task<TimeSlotResponse?> GetTimeSlotAsync(int id)
        {
            return await _apiService.GetAsync<TimeSlotResponse>(id);
        }

        public async Task<TimeSlotRequest?> PostTimeSlotAsync(TimeSlotRequest model)
        {
            return await _apiService.PostAsync(model);
        }

        public async Task<bool> PutTimeSlotAsync(int id, TimeSlotRequest model)
        {
            return await _apiService.PutAsync(id, model);
        }

        public async Task<bool> DeleteTimeSlotAsync(int id)
        {
            return await _apiService.DeleteAsync(id);
        }
    }
}