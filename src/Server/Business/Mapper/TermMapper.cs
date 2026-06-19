
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class TermMapper
    {
        public static AcademicTerm ToAcademicTerm(this AcademicTermRequest request)
        {
            return new AcademicTerm(-1, request.TermType, request.TermYear);
        }

        public static AcademicTermResponse ToResponse(this AcademicTerm term)
        {
            return new AcademicTermResponse(term.TermID, term.TermType, term.TermYear);
        }
    }
}
