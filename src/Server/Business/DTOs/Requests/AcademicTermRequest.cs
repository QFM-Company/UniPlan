using Core.Enums;

namespace UniPlan.Business.DTOs.Requests
{
    public class AcademicTermRequest
    {
        public TermType TermType { get; set; }
        public int TermYear { get; set; }

        public AcademicTermRequest()
        {
            TermType = TermType.First;
            TermYear = default;
        }

        public AcademicTermRequest(TermType termType, int termYear)
        {
            TermType = termType;
            TermYear = termYear;
        }
    }
}
