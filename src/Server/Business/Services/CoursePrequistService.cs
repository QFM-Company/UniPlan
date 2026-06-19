using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Interfaces.Repositories;
using Core.Entities;
using Business.Interfaces;

namespace Business.Services
{
    public class CoursePrequistService : ICoursePrequistService
    {
        private readonly ICoursePrequsetRepository _coursePrequset;

        public CoursePrequistService(ICoursePrequsetRepository coursePrequset)
        {
            _coursePrequset = coursePrequset;
        }

        private CoursePrerequisites? _RequestToCoursePrequist(CoursePrerequisiteRequest request, int prequistID = -1)
        {
            if (request == null || request.CourseID <= 0 || request.PreRequestCourseID <= 0) return null;
            return new CoursePrerequisites(prequistID , new Course(request.CourseID ,null , 0 , null) , new Course(request.PreRequestCourseID , null , 0 , null) );
        }

        private CoursePrerequisiteResponse? _CoursePrequistToResponse(CoursePrerequisites? coursePrequist)
        {
            if (coursePrequist == null) return null;
            return new CoursePrerequisiteResponse(coursePrequist.PreRequestID, coursePrequist.Course, coursePrequist.PreRequestCourse);
        }

        public async Task<bool> DeleteCoursePrequistAsync(int prequistID)
        {
            if (prequistID <= 0) { return false; }
            return await _coursePrequset.DeletePrequestAsync(prequistID);
        }
        public async Task<CoursePrerequisiteResponse?> AddCoursePrequistAsync(CoursePrerequisiteRequest request)
        {
            CoursePrerequisites? coursePrequist = _RequestToCoursePrequist(request);
            if (coursePrequist == null) { return null; }

            coursePrequist = await _coursePrequset.AddPrequestAsync(coursePrequist);

            if (coursePrequist?.PreRequestID <= 0) return null;
            return _CoursePrequistToResponse(coursePrequist);
        }

        public async Task<IEnumerable<CoursePrerequisiteResponse?>?> GetPagedCoursePrequistsAsync(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0) return null;
            return (await _coursePrequset.GetCoursePrerequisitesPagedAsync(pageNumber, pageSize))
                .Select(n => _CoursePrequistToResponse(n));
        }

        public async Task<CoursePrerequisiteResponse?> GetCoursePrequistByIDAsync(int prequistID)
        {
            if(prequistID <= 0) return null;

            var pre = await _coursePrequset.GetCoursePrerequisitesByIDAsync(prequistID);

            return _CoursePrequistToResponse(pre);
        }

    }
}
