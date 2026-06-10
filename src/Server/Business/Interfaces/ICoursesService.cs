using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface ICoursesService
    {
        Task<IEnumerable<CourseResponse>> GetPageCoursesAsync(int pageNumber, int pageSize);
        Task<CourseResponse?> GetCourseByIdAsync(int courseID);
        Task<bool> AddCourseAsync(CourseRequest course);
        Task<bool> UpdateCourseAsync(int courseID, CourseRequest course);
        Task<bool> DeleteCourseAsync(int courseID);
    }
}
