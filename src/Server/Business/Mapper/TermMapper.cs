
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class TermMapper
    {
        public static AcademicTerm? RequestToAcademicTerm(this AcademicTermRequest request, int termID = -1)
        {
            if(request != null)
                return new AcademicTerm(termID, request.TermType, request.TermYear);

            return null;
        }

        public static AcademicTermResponse AcademicTermToResponse(this AcademicTerm term)
        {
            return new AcademicTermResponse(term.TermID, term.TermType, term.TermYear);
        }
    }
}
