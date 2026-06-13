using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
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

        #region Mapping Helpers

        private Course _RequestToCourse(CourseRequest request, int courseID = 0)
        {
            Major major = new Major(request.MajorID, "");

            return new Course(
                courseID,
                request.CourseName,
                request.CreditHours,
                major
            );
        }

        private CourseResponse _CourseToResponse(Course course)
        {
            if(course.Major == null)
            {
                throw new ArgumentException("Course must have a Major associated with it.");
            }
            return new CourseResponse(
                course.CourseID,
                course.CourseName,
                course.CreditHours,
                course.Major!.MajorID
            );
        }

        #endregion

        #region Service Methods

        public async Task<IEnumerable<CourseResponse>> GetPageCoursesAsync(int pageNumber, int pageSize)
        {
            IEnumerable<Course> courses = await _courseRepository.GetPagedCoursesAsync(pageNumber, pageSize);

            if (courses == null)
            {
                return Enumerable.Empty<CourseResponse>();
            }

            return courses.Select(c => _CourseToResponse(c));
        }

        public async Task<CourseResponse?> GetCourseByIdAsync(int courseID)
        {
            Course? course = await _courseRepository.GetCourseByIDAsync(courseID);
            return course != null ? _CourseToResponse(course) : null;
        }

        public async Task<bool> AddCourseAsync(CourseRequest courseRequest)
        {
            if (courseRequest == null) return false;

            Course course = _RequestToCourse(courseRequest);
            return await _courseRepository.AddCourseAsync(course);
        }

        public async Task<bool> UpdateCourseAsync(int courseID, CourseRequest courseRequest)
        {
            if (courseRequest == null) return false;

            Course course = _RequestToCourse(courseRequest, courseID);
            return await _courseRepository.UpdateCourseAsync(course);
        }

        public async Task<bool> DeleteCourseAsync(int courseID)
        {
            return await _courseRepository.DeleteCourseAsync(courseID);
        }

        #endregion
    }
}