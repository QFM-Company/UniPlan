using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICourseRepository _courseRepository;

        private IValidationService _ValidationService;

        public CoursesService(ICourseRepository courseRepository , IValidationService validationService)
        {
            _courseRepository = courseRepository;
            _ValidationService = validationService;
        }

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

        public async Task<CourseResponse?> AddCourseAsync(CourseRequest request)
        {
            _ValidationService.Validate(request);

            if (request == null) return null;

            Course course = request.ToCourse();
            course.CourseID = await _courseRepository.AddCourseAsync(course);
            if(course.CourseID <= 0) return null;
            return course.ToResponse();
        }

        public async Task<CourseResponse?> UpdateCourseAsync(int courseID, CourseRequest request)
        {
            _ValidationService.Validate(request);
            if (request == null) return null;

            Course course = request.ToCourse(courseID);
            if(await _courseRepository.UpdateCourseAsync(course)) { return course.ToResponse(); }
            return null;
        }

        public async Task<bool> DeleteCourseAsync(int courseID)
        {
            return await _courseRepository.DeleteCourseAsync(courseID);
        }

    }
}