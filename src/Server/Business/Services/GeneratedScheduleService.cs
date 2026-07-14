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
            var availableSessionsMap = await _courseSessionService.GetWishListSessionsByDaysAsync(schedule.WishList.WishListID, days);

            if (availableSessionsMap == null) 
                return false;

            List<int> lectures = availableSessionsMap.Keys.ToList();
            schedule.GeneratedCombinations = _GetAllSchedules(availableSessionsMap, new List<int>(), new List<List<int>>(), lectures);

            return true;
        }

        private List<List<int>> _GetAllSchedules(Dictionary<int, Dictionary<int, List<CourseSession>>> availableSessionsMap, List<int> schedule, List<List<int>> schedules, List<int> lectures, int lectureIndex = 0)
        {
            if(lectureIndex == lectures.Count)
            {
                schedules.Add(new List<int>(schedule));
                return schedules;
            }

            foreach (int offeringID in availableSessionsMap[lectures[lectureIndex]].Keys)
            {
                schedule.Add(offeringID);
                _GetAllSchedules(availableSessionsMap, schedule, schedules, lectures, lectureIndex + 1);
                schedule.Remove(offeringID);
            }

            return schedules;
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
