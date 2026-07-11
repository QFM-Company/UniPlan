using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ICourseSessionService
    {
        Task<bool> DeleteCourseSessionAsync(int courseSessionID);

        Task<CourseSessionResponse?> AddCourseSessionAsync(CreateCourseSessionRequest request);

        Task<bool> UpdateCourseSessionAsync(UpdateCourseSessionRequest request, int courseSessionID);

        Task<IEnumerable<CourseSessionResponse>?> GetPagedCourseSessionsAsync(int pageNumber = 1, int pageSize = 10);

        Task<Dictionary<int, Dictionary<int, List<CourseSession>>>?> GetWishListSessionsByDaysAsync(int listID, List<DayOfWeek> days);

        Task<CourseSessionResponse?> GetCourseSessionByIDAsync(int courseSessionID);
    }
}
