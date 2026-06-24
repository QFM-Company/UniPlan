using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class ScheduleDetailService : IScheduleDetailService
    {
        private IScheduleDetailRepository _detailRepository;

        public ScheduleDetailService(IScheduleDetailRepository scheduleDetailRepository)
        {
            _detailRepository = scheduleDetailRepository;
        }

        public async Task<IEnumerable<ScheduleDetailResponse>?> GetScheduleDetailsByScheduleIDAsync(int scheduleID)
        {
            IEnumerable<ScheduleDetail>? details = await _detailRepository.GetScheduleDetailsByScheduleIDAsync(scheduleID);
            return details?.Select(m => m.ToResponse()).OfType<ScheduleDetailResponse>();
        }
    }
}
