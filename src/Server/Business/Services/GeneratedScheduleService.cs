using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class GeneratedScheduleService : IGeneratedScheduleService
    {
        private IGeneratedScheduleRepository _scheduleRepository;

        public GeneratedScheduleService(IGeneratedScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<GeneratedScheduleResponse?> AddGeneratedScheduleAsync(GeneratedScheduleRequest request)
        {
            GeneratedSchedule schedule = request.ToGeneratedSchedule();

            schedule.ScheduleID = await _scheduleRepository.AddGeneratedScheduleAsync(schedule);

            if (schedule.ScheduleID != -1)
                return await GetGeneratedScheduleByWishListIDAsync(schedule.WishList.WishListID);

            return null;
        }

        public async Task<bool> AddScheduleDetailsAsync(GeneratedSchedule schedule)
        {
            return await _scheduleRepository.AddScheduleDetailsAsync(schedule);
        }

        public async Task<GeneratedScheduleResponse?> GetGeneratedScheduleByWishListIDAsync(int listID)
        {
            GeneratedSchedule? schedule = await _scheduleRepository.GetGeneratedScheduleByWishListIDAsync(listID);
            return schedule != null ? schedule.ToResponse() : null;
        }
    }
}
