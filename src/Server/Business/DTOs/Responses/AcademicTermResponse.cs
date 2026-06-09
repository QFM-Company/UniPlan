using Core.Enums;

namespace Business.DTOs.Responses
{
    public class AcademicTermResponse
    {
        public int TermID { get; set; }
        public TermType TermType { get; set; }
        public int TermYear { get; set; }

        public AcademicTermResponse()
        {
            TermID = default;
            TermType = TermType.First;
            TermYear = default;
        }

        public AcademicTermResponse(int termID, TermType termType, int termYear)
        {
            TermID = termID;
            TermType = termType;
            TermYear = termYear;
        }
    }
}
