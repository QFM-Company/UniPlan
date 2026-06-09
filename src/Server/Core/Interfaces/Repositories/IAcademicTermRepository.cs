using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IAcademicTermRepository
    {
        Task<bool> DeleteAcademicTermAsync(int termID);

        Task<int> AddAcademicTermAsync(AcademicTerm term);

        Task<IEnumerable<AcademicTerm>?> GetPagedAcademicTermsAsync(int pageNumber = 1, int pageSize = 10);

        Task<AcademicTerm?> GetAcademicTermByIDAsync(int termID);
    }
}
