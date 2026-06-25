using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IGeneratedScheduleService
    {
        Task<GeneratedScheduleResponse?> AddGeneratedScheduleAsync(GeneratedScheduleRequest schedule);

        Task<GeneratedScheduleResponse?> GetGeneratedScheduleByWishListIDAsync(int listID);
    }
}
