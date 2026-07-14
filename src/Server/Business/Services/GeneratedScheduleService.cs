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
            var map = await _courseSessionService.GetWishListSessionsByDaysAsync(schedule.WishList.WishListID, days);
            if (map == null) return false;
            schedule.GeneratedCombinations = _GetAllSchedules(map, 0, new List<int>(), new List<List<int>>());

            Console.WriteLine(string.Join(" \n " , schedule.GeneratedCombinations.Select(x => string.Join(" , ", x))));

            return true;
        }

        private List<List<int>> _GetAllSchedules(Dictionary<int, Dictionary<int, List<CourseSession>>> map , int lectureIndex , List<int> schedule , List<List<int>> res)
        {
            if(lectureIndex == map.Keys.Count)
            {
                res.Add(new List<int>(schedule));
            }

            foreach (int item in map[map.Keys.ElementAt(lectureIndex)].Keys)
            {
                schedule.Add(item);
                _GetAllSchedules(map, lectureIndex + 1, schedule, res);
                schedule.Remove(item);
            }

            return res;
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
