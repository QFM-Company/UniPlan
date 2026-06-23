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
        Task<int> AddCourseSessionAsync(CourseSession courseSession);

        Task<bool> UpdateCourseSessionAsync(CourseSession courseSession);

        Task<bool> DeleteCourseSessionAsync(int sessionID);

        Task<CourseSession?> GetCourseSessionByIDAsync(int sessionID);

        Task<IEnumerable<CourseSession?>?>GetCourseSessionsPagedAsync(int pageNumber,int pageSize);

    }
}
