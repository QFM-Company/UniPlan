using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Business.Services
{
    public class GeneratedScheduleService : IGeneratedScheduleService
    {
        private readonly IGeneratedScheduleRepository _scheduleRepository;
        private readonly IValidationService _validationService;
        private readonly ICourseSessionService _courseSessionService;

        public GeneratedScheduleService(IGeneratedScheduleRepository scheduleRepository, IValidationService validationService, ICourseSessionService courseSessionService)
        {
            _courseSessionService = courseSessionService;
            _validationService = validationService;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<GeneratedScheduleResponse?> AddGeneratedScheduleAsync(GeneratedScheduleRequest request)
        {
            _validationService.Validate(request);

            GeneratedSchedule schedule = request.ToGeneratedSchedule();

            if (await _GeneratedSchedule(schedule, request.Days) && await _scheduleRepository.AddGeneratedScheduleAsync(schedule))
                return await GetGeneratedScheduleByWishListIDAsync(schedule.WishList.WishListID);

            return null;
        }

        private async Task<bool> _GeneratedSchedule(GeneratedSchedule schedule, List<int> days)
        {
            var sessions = await _courseSessionService.GetWishListSessionsByDaysAsync(schedule.WishList.WishListID, days);

            //foreach (var item in sessions)
            //{
            //    Console.WriteLine($"lecture id: {item.Key}");
            //    Console.WriteLine("\tOfferings");
                
            //    foreach (var item1 in item.Value.Keys)
            //    {
            //        Console.WriteLine("\t" + item1);
                    
            //        Console.WriteLine("\t\tSessions:");

            //        foreach (var item2 in sessions[item.Key][item1])
            //        {
            //            Console.WriteLine("\t\t" + item2.SessionID);
            //        }
            //    }
            //}
            return true;
        }

        public async Task<GeneratedScheduleResponse?> GetGeneratedScheduleByWishListIDAsync(int listID)
        {
            if (listID <= 0)
                return null;

            GeneratedSchedule? schedule = await _scheduleRepository.GetGeneratedScheduleByWishListIDAsync(listID);
            return schedule != null ? schedule.ToResponse() : null;
        }

        public async Task<ScheduleDetailResponse?> GetScheduleDetailByWishListIDAsync(int listID, int scheduleNum)
        {
            if (listID <= 0 || scheduleNum <= 0)
                return null;

            GeneratedSchedule? schedule = await _scheduleRepository.GetScheduleDetailByWishListIDAsync(listID, scheduleNum);
            return schedule != null ? schedule.ToScheduleDetailResponse() : null;
        }
    }
}
