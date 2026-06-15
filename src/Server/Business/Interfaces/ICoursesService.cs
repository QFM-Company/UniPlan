using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface ICoursesService
    {
        Task<IEnumerable<CourseResponse>> GetPageCoursesAsync(int pageNumber, int pageSize);
        Task<CourseResponse?> GetCourseByIdAsync(int courseID);
        Task<CourseResponse?> AddCourseAsync(CourseRequest course);
        Task<CourseResponse?> UpdateCourseAsync(int courseID, CourseRequest course);
        Task<bool> DeleteCourseAsync(int courseID);
    }
}
