using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICourseSessionRepository
    {
        Task<CourseSession?> AddCourseSessionAsync(CourseSession courseSession);

        Task<CourseSession?> UpdateCourseSessionAsync(CourseSession courseSession);

        Task<CourseSession?> GetCourseSessionByIDAsync(int sessionID);

        Task<IEnumerable<CourseSession?>?>GetCourseSessionsPagedAsync(int pageNumber,int pageSize);

    }
}
