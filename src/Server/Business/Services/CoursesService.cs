using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        #region Service Methods

        public async Task<IEnumerable<CourseResponse>> GetPageCoursesAsync(int pageNumber, int pageSize)
        {
            IEnumerable<Course> courses = await _courseRepository.GetPagedCoursesAsync(pageNumber, pageSize);

            if (courses == null)
            {
                return Enumerable.Empty<CourseResponse>();
            }

            return courses.Select(c => c.ToResponse());
        }

        public async Task<CourseResponse?> GetCourseByIdAsync(int courseID)
        {
            Course? course = await _courseRepository.GetCourseByIDAsync(courseID);
            return course != null ? course.ToResponse() : null;
        }

        public async Task<CourseResponse?> AddCourseAsync(CourseRequest courseRequest)
        {
            if (courseRequest == null) return null;

            Course course = courseRequest.ToCourse();
            course.CourseID = await _courseRepository.AddCourseAsync(course);
            if(course.CourseID <= 0) return null;
            return course.ToResponse();
        }

        public async Task<CourseResponse?> UpdateCourseAsync(int courseID, CourseRequest courseRequest)
        {
            if (courseRequest == null) return null;

            Course course = courseRequest.ToCourse(courseID);
            if(await _courseRepository.UpdateCourseAsync(course)) { return course.ToResponse(); }
            return null;
        }

        public async Task<bool> DeleteCourseAsync(int courseID)
        {
            return await _courseRepository.DeleteCourseAsync(courseID);
        }

        #endregion
    }
}