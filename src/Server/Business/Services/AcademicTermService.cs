using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class AcademicTermService : IAcademicTermService
    {
        private readonly IAcademicTermRepository _termRepository;
        private readonly IValidationService _validationService;

        public AcademicTermService(IAcademicTermRepository termRepository, IValidationService validationService)
        {
            _validationService = validationService;
            _termRepository = termRepository;
        }

        public async Task<bool> DeleteAcademicTermAsync(int AcademicTermID)
        {
            return await _termRepository.DeleteAcademicTermAsync(AcademicTermID);
        }

        public async Task<AcademicTermResponse?> AddAcademicTermAsync(AcademicTermRequest request)
        {
            _validationService.Validate(request);

            AcademicTerm term = request.ToAcademicTerm();

            term.TermID = await _termRepository.AddAcademicTermAsync(term);

            if (term.TermID != -1)
                return term.ToResponse();
            
            return null;
        }

        public async Task<IEnumerable<AcademicTermResponse>?> GetPagedAcademicTermsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<AcademicTerm>? terms = await _termRepository.GetPagedAcademicTermsAsync(pageNumber, pageSize);
            return terms?.Select(m => m.ToResponse()).OfType<AcademicTermResponse>();
        }

        public async Task<AcademicTermResponse?> GetAcademicTermByIDAsync(int termID)
        {
            AcademicTerm? term = await _termRepository.GetAcademicTermByIDAsync(termID);
            return term != null ? term.ToResponse() : null;
        }
    }
}
