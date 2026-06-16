using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
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

        public async Task<bool> DeleteAcademicTermAsync(int AcademicTermID)
        {
            return await _termRepository.DeleteAcademicTermAsync(AcademicTermID);
        }

        public async Task<AcademicTermResponse?> AddAcademicTermAsync(AcademicTermRequest request)
        {
            _term = new AcademicTerm();
            _term = _term.RequestToAcademicTerm(request);

            if(_term != null)
            {
                _term.TermID = await _termRepository.AddAcademicTermAsync(_term);

                if (_term.TermID != -1)
                    return _term.AcademicTermToResponse();
            }

            return null;
        }

        public async Task<IEnumerable<AcademicTermResponse>?> GetPagedAcademicTermsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<AcademicTerm>? terms = await _termRepository.GetPagedAcademicTermsAsync(pageNumber, pageSize);
            return terms?.Select(m => m.AcademicTermToResponse()).OfType<AcademicTermResponse>();
        }

        public async Task<AcademicTermResponse?> GetAcademicTermByIDAsync(int termID)
        {
            _term = await _termRepository.GetAcademicTermByIDAsync(termID);
            return _term != null ? _term.AcademicTermToResponse() : null;
        }
    }
}
