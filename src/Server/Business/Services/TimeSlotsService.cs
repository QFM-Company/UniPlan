using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
namespace Business.Services
{
    public class TimeSlotsService : ITimeSlotsService
    {

        private ITimeSlotRepository _TimeSlotsRepository;
        private IPeriodRepository _PeriodRepository;
        private TimeSlot? _timeSlot;
        private IValidationService _ValidationService;

        public TimeSlotsService(ITimeSlotRepository timeSlotsRepository, IPeriodRepository periodRepository, IValidationService validationService)
        {
            _TimeSlotsRepository = timeSlotsRepository;
            _timeSlot = null;
            _PeriodRepository = periodRepository;
            _ValidationService = validationService;
        }



        public async Task<TimeSlotResponse?> AddTimeSlotAsync(TimeSlotRequest request)
        {
            _ValidationService.Validate(request);

            _timeSlot = request?.ToTimeSlot() ?? null;
            if (_timeSlot != null)
            {
                _timeSlot.SlotID = await _TimeSlotsRepository.AddTimeSlotAsync(_timeSlot);
                if (_timeSlot.SlotID > 0)
                {
                    _timeSlot.Period = await _PeriodRepository.GetPeriodByIDAsync(_timeSlot.Period?.PeriodID ?? -1);
                    if (_timeSlot.Period != null) return _timeSlot.ToResponse();
                }
            }
            return null;
        }

        public async Task<bool> DeleteTimeSlotAsync(int timeSlotID)
        {
            return await _TimeSlotsRepository.DeleteTimeSlotAsync(timeSlotID);
        }

        public async Task<TimeSlotResponse?> GetTimeSlotByIdAsync(int timeSlotID)
        {
            _timeSlot = await _TimeSlotsRepository.GetTimeSlotByIDAsync(timeSlotID);
            if (_timeSlot != null)
                _timeSlot.Period = await _PeriodRepository.GetPeriodByIDAsync(_timeSlot?.Period?.PeriodID ?? -1);
            return _timeSlot?.ToResponse() ?? null;
        }

        public async Task<TimeSlotResponse?> UpdateTimeSlotAsync(int timeSlotID, TimeSlotRequest request)
        {
            _ValidationService.Validate(request);

            _timeSlot = request?.ToTimeSlot(timeSlotID) ?? null;
            if (_timeSlot != null)
            {
                if (await _TimeSlotsRepository.UpdateTimeSlotAsync(_timeSlot))
                {
                    return _timeSlot.ToResponse();
                }
            }
            return null;
        }

        public async Task<IEnumerable<TimeSlotResponse>> GetPageTimeSlotsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var timeSlots = await _TimeSlotsRepository.GetPagedTimeSlotsAsync(pageNumber, pageSize);

            var responses = timeSlots?.Select(timeSlot => timeSlot.ToResponse()).Where(tm => tm != null);

            return responses?.Select(response => response!).ToList() ?? new List<TimeSlotResponse>();
        }

    }
}
