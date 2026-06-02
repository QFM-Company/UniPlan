using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;
using Core.Interfaces.Repositories;
using Business.Interfaces;
namespace Business.Services
{
    public class TimeSlotsService : ITimeSlotsService
    {

        private ITimeSlotRepository _TimeSlotsRepository;
        private TimeSlot? _timeSlot;

        public TimeSlotsService(ITimeSlotRepository timeSlotsRepository)
        {
            _TimeSlotsRepository = timeSlotsRepository;
            _timeSlot = null;
        }

        private TimeSlot? RequestToTimeSlot(TimeSlotRequest? request, int timeSlotID = -1)
        {
            if (request != null)
            {
                return new TimeSlot(timeSlotID, request.Day, request.Period);
            }
            return null;
        }

        private TimeSlotResponse? TimeSlotToResponse(TimeSlot? timeSlot)
        {
            if (timeSlot != null)
            {
                return new TimeSlotResponse(timeSlot.SlotID, timeSlot.Day, timeSlot.Period);
            }
            return null;
        }

        public async Task<bool> AddTimeSlotAsync(TimeSlotRequest request)
        {
            _timeSlot = RequestToTimeSlot(request);
            if (_timeSlot != null)
            {
                _timeSlot.SlotID = await _TimeSlotsRepository.AddTimeSlotAsync(_timeSlot);
                return _timeSlot?.SlotID != -1;
            }

            return false;
        }

        public async Task<bool> DeleteTimeSlotAsync(int timeSlotID)
        {
            return await _TimeSlotsRepository.DeleteTimeSlotAsync(timeSlotID);
        }

        public async Task<TimeSlotResponse?> GetTimeSlotByIdAsync(int timeSlotID)
        {
            _timeSlot = await _TimeSlotsRepository.GetTimeSlotByIDAsync(timeSlotID);
            return TimeSlotToResponse(_timeSlot) ?? null;
        }

        public async Task<bool> UpdateTimeSlotAsync(int timeSlotID, TimeSlotRequest request)
        {
            _timeSlot = RequestToTimeSlot(request, timeSlotID);
            if (_timeSlot != null)
            {
                return await _TimeSlotsRepository.UpdateTimeSlotAsync(_timeSlot);
            }
            return false;
        }

        public async Task<IEnumerable<TimeSlotResponse>> GetPageTimeSlotsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var timeSlots = await _TimeSlotsRepository.GetPagedTimeSlotsAsync(pageNumber, pageSize);

            var responses = timeSlots?.Select(timeSlot => TimeSlotToResponse(timeSlot)).Where(tm => tm != null);

            return responses?.Select(response => response!).ToList() ?? new List<TimeSlotResponse>();
        }

    }
}
