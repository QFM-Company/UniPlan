using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.VisualBasic;

namespace Business.Services
{
    public class CourseSessionService : ICourseSessionService
    {
        private ICourseSessionRepository _courseSessionRepository;

        public CourseSessionService(ICourseSessionRepository courseSessionRepository)
        {
            _courseSessionRepository = courseSessionRepository;
        }

        public async Task<bool> DeleteCourseSessionAsync(int courseSessionID)
        {
            return await _courseSessionRepository.DeleteCourseSessionAsync(courseSessionID);
        }

        public async Task<CourseSessionResponse?> AddCourseSessionAsync(CreateCourseSessionRequest request)
        {
            CourseSession? courseSession = request!.ToCourseSession();

            courseSession.SessionID = await _courseSessionRepository.AddCourseSessionAsync(courseSession);

            if (courseSession.SessionID != -1)
            {
                courseSession = await _courseSessionRepository.GetCourseSessionByIDAsync(courseSession.SessionID);

                return courseSession?.ToResponse() ?? null;
            }
            return null;
        }

        public async Task<bool> UpdateCourseSessionAsync(UpdateCourseSessionRequest request, int courseSessionID)
        {
            CourseSession? courseSession = await _courseSessionRepository.GetCourseSessionByIDAsync(courseSessionID);

            courseSession?.UpdateCourseSession(request);

            if (courseSession != null)
                return await _courseSessionRepository.UpdateCourseSessionAsync(courseSession);

            return false;
        }

        public async Task<IEnumerable<CourseSessionResponse>?> GetPagedCourseSessionsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<CourseSession?>? courseSessions = await _courseSessionRepository.GetCourseSessionsPagedAsync(pageNumber, pageSize);
            return courseSessions?.Select(m => m?.ToResponse() ?? null).OfType<CourseSessionResponse>();
        }

        public async Task<CourseSessionResponse?> GetCourseSessionByIDAsync(int courseSessionID)
        {
            CourseSession? courseSession = await _courseSessionRepository.GetCourseSessionByIDAsync(courseSessionID);
            return courseSession != null ? courseSession.ToResponse() : null;
        }

    }
}
