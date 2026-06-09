using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class AcademicTermService : IAcademicTermService
    {
        private IAcademicTermRepository _termRepository;
        private AcademicTerm? _term;

        public AcademicTermService(IAcademicTermRepository termRepository)
        {
            _termRepository = termRepository;
            _term = null;
        }

        private AcademicTerm _RequestToAcademicTerm(AcademicTermRequest request, int termID = -1)
        {
            return new AcademicTerm(termID, request.TermType, request.TermYear);
        }

        private AcademicTermResponse? _AcademicTermToResponse(AcademicTerm term)
        {
            return new AcademicTermResponse(term.TermID, term.TermType, term.TermYear);
        }

        public async Task<bool> DeleteAcademicTermAsync(int AcademicTermID)
        {
            return await _termRepository.DeleteAcademicTermAsync(AcademicTermID);
        }

        public async Task<AcademicTermResponse?> AddAcademicTermAsync(AcademicTermRequest request)
        {
            AcademicTermResponse? termResponse = null;

            if (request != null)
            {
                _term = _RequestToAcademicTerm(request);
                _term.TermID = await _termRepository.AddAcademicTermAsync(_term);
                termResponse = _AcademicTermToResponse(_term);
            }

            return termResponse;
        }

        public async Task<IEnumerable<AcademicTermResponse>?> GetPagedAcademicTermsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<AcademicTerm>? terms = await _termRepository.GetPagedAcademicTermsAsync(pageNumber, pageSize);
            return terms?.Select(h => _AcademicTermToResponse(h)).OfType<AcademicTermResponse>();
        }

        public async Task<AcademicTermResponse?> GetAcademicTermByIDAsync(int AcademicTermID)
        {
            _term = await _termRepository.GetAcademicTermByIDAsync(AcademicTermID);
            return _term != null ? _AcademicTermToResponse(_term) : null;
        }
    }
}
