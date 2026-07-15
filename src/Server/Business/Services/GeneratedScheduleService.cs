using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Core.Services;
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

            await _GeneratedSchedule(schedule, request.Days);

            if (await _scheduleRepository.AddGeneratedScheduleAsync(schedule))
                return await GetGeneratedScheduleByWishListIDAsync(schedule.WishList.WishListID);

            return null;
        }

        private async Task _GeneratedSchedule(GeneratedSchedule schedule, List<int> days)
        {
            var availableSessionsMap = await _courseSessionService.GetWishListSessionsByDaysAsync(schedule.WishList.WishListID, days);

            if (availableSessionsMap == null || availableSessionsMap.Count == 0)
                throw new ScheduleException("قائمة الرغبات غير موجودة تأكد من معرف");

            List<int> lectures = availableSessionsMap.Keys.ToList();
            HashSet<string> conflictMeesages = new HashSet<string>();

            schedule.GeneratedCombinations = _GetAllSchedules(availableSessionsMap, new(), new(), lectures, conflictMeesages);


            if (schedule.GeneratedCombinations.Count == 0)
                throw new ConflictException(string.Join("\n\n\n", conflictMeesages));
        }

        private List<ScheduleManager> _GetAllSchedules(Dictionary<int, Dictionary<int, List<CourseSession>>> availableSessionsMap, ScheduleManager schedule, List<ScheduleManager> schedules, List<int> lectures, HashSet<string> conflictMeesages, int lectureIndex = 0)
        {
            if(lectureIndex == lectures.Count)
            {
                schedules.Add(new ScheduleManager(schedule));
                return schedules;
            }

            int lectureID = lectures[lectureIndex];

            foreach (int offeringID in availableSessionsMap[lectureID].Keys)
            {
                List<CourseSession> sessions = availableSessionsMap[lectureID][offeringID];

                if(schedule.TryAdd(sessions))
                {
                    _GetAllSchedules(availableSessionsMap, schedule, schedules, lectures, conflictMeesages,lectureIndex + 1);
                    schedule.Remove(sessions);
                }
                else if(schedule.ConflictMeesage != null)
                {
                    conflictMeesages.Add(schedule.ConflictMeesage);
                }
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
