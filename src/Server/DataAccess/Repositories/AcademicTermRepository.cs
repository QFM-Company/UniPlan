using Core.Entities;
using Core.Interfaces.Repositories;

namespace DataAccess.Repositories
{
    public class AcademicTermRepository : IAcademicTermRepository
    {
        public Task<int> AddAcademicTermAsync(AcademicTerm term)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAcademicTermAsync(int termID)
        {
            throw new NotImplementedException();
        }

        public Task<AcademicTerm?> GetAcademicTermByIDAsync(int termID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AcademicTerm>?> GetPagedAcademicTermsAsync(int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }
    }
}
