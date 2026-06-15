
using Core.Entities;


namespace Core.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetPagedCoursesAsync(int pageNumber, int pageSize);
        Task<Course?> GetCourseByIDAsync(int courseID);
        Task<int> AddCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int courseID);
    }
}
