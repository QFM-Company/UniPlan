using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class CoursePrequistService : ICoursePrequistService
    {
        private readonly ICoursePrequsetRepository _coursePrequset;
        private IValidationService _ValidationService;
        public CoursePrequistService(ICoursePrequsetRepository coursePrequset, IValidationService validationService)
        {
            _coursePrequset = coursePrequset;
            _ValidationService = validationService;
        }


        public async Task<bool> DeleteCoursePrequistAsync(int prequistID)
        {
            if (prequistID <= 0) { return false; }
            return await _coursePrequset.DeletePrequestAsync(prequistID);
        }
        public async Task<CoursePrerequisiteResponse?> AddCoursePrequistAsync(CoursePrerequisiteRequest request)
        {
            _ValidationService.Validate(request);

            CoursePrerequisites? coursePrequist = request.ToCoursePrequist();
            if (coursePrequist == null) { return null; }

            coursePrequist.PreRequestID = await _coursePrequset.AddPrequestAsync(coursePrequist);
            if (coursePrequist.PreRequestID <= 0) return null;

            coursePrequist = await _coursePrequset.GetCoursePrerequisitesByIDAsync(coursePrequist.PreRequestID);

            return coursePrequist?.ToResponse() ?? null;
        }

        public async Task<IEnumerable<CoursePrerequisiteResponse?>?> GetPagedCoursePrequistsAsync(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0) return null;
            return (await _coursePrequset.GetCoursePrerequisitesPagedAsync(pageNumber, pageSize))
                .Select(n => n.ToResponse());
        }

        public async Task<CoursePrerequisiteResponse?> GetCoursePrequistByIDAsync(int prequistID)
        {
            if (prequistID <= 0) return null;

            var pre = await _coursePrequset.GetCoursePrerequisitesByIDAsync(prequistID);

            return pre?.ToResponse() ?? null;
        }

    }
}
