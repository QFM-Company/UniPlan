using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IGeneratedScheduleService
    {
        Task<GeneratedScheduleResponse?> AddGeneratedScheduleAsync(GeneratedScheduleRequest schedule);

        Task<bool> AddScheduleDetailsAsync(GeneratedSchedule schedule);

        Task<GeneratedScheduleResponse?> GetGeneratedScheduleByWishListIDAsync(int listID);
    }
}
