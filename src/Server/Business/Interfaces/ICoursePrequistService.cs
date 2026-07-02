using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface ICoursePrequistService
    {
        Task<bool> DeleteCoursePrequistAsync(int prequistID);

        Task<CoursePrerequisiteResponse?> AddCoursePrequistAsync(CoursePrerequisiteRequest request);

        Task<IEnumerable<CoursePrerequisiteResponse?>?> GetPagedCoursePrequistsAsync(int pageNumber = 1, int pageSize = 10);

        Task<CoursePrerequisiteResponse?> GetCoursePrequistByIDAsync(int prequistID);
    }
}
