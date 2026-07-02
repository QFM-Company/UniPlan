using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class GeneratedScheduleService : IGeneratedScheduleService
    {
        private readonly IGeneratedScheduleRepository _scheduleRepository;
        private readonly IValidationService _validationService;

        public GeneratedScheduleService(IGeneratedScheduleRepository scheduleRepository, IValidationService validationService)
        {
            _validationService = validationService;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<GeneratedScheduleResponse?> AddGeneratedScheduleAsync(GeneratedScheduleRequest request)
        {
            _validationService.Validate(request);

            GeneratedSchedule schedule = request.ToGeneratedSchedule();

            if (_GeneratedSchedule(schedule, request.Days) && await _scheduleRepository.AddGeneratedScheduleAsync(schedule))
                return await GetGeneratedScheduleByWishListIDAsync(schedule.WishList.WishListID);

            return null;
        }

        private bool _GeneratedSchedule(GeneratedSchedule schedule, List<DayOfWeek> days)
        {
            return true;
        }

        public async Task<GeneratedScheduleResponse?> GetGeneratedScheduleByWishListIDAsync(int listID)
        {
            GeneratedSchedule? schedule = await _scheduleRepository.GetGeneratedScheduleByWishListIDAsync(listID);
            return schedule != null ? schedule.ToResponse() : null;
        }
    }
}
