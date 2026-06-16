using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICoursePrequsetRepository
    {
        public Task<bool> DeletePrequestAsync(int preRequestID);
        public Task<int> AddPrequestAsync(CoursePrerequisites coursePerquest);
        public Task<IEnumerable<CoursePrerequisites>> GetCoursePrerequisitesPagedAsync(int pageNumber, int pageSize);
        public Task<CoursePrerequisites?> GetCoursePrerequisitesByIDAsync(int preRequestID);
    }
}
