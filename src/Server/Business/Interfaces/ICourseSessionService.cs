using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface ICourseSessionService
    {
        Task<bool> DeleteCourseSessionAsync(int courseSessionID);

        Task<CourseSessionResponse?> AddCourseSessionAsync(CreateCourseSessionRequest request);

        Task<bool> UpdateCourseSessionAsync(UpdateCourseSessionRequest request, int courseSessionID);

        Task<IEnumerable<CourseSessionResponse>?> GetPagedCourseSessionsAsync(int pageNumber = 1, int pageSize = 10);

        Task<CourseSessionResponse?> GetCourseSessionByIDAsync(int courseSessionID);
    }
}
