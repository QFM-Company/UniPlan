
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;
using Core.Enums;
using Core.Extensions;

namespace Business.Mapper
{
    public static class TermMapper
    {
        public static AcademicTerm ToAcademicTerm(this AcademicTermRequest request)
        {
            return new AcademicTerm(-1, (TermType) request.TermType, request.TermYear);
        }

        public static AcademicTermResponse ToResponse(this AcademicTerm term)
        {
            return new AcademicTermResponse(term.TermID, term.TermType.ToArabicString(), term.TermYear);
        }
    }
}
