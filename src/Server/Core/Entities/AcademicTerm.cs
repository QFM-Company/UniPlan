using Core.Enums;

namespace Core.Entities
{
    public class AcademicTerm
    {
        public int TermID { get; set; }
        public TermType TermType { get; set; }
        public int TermYear { get; set; }

        public AcademicTerm()
        {
            TermID = default;
            TermType = TermType.First;
            TermYear = default;
        }

        public AcademicTerm(int termID)
        {
            TermID = termID;
        }

        public AcademicTerm(int termID, TermType termType, int termYear)
        {
            TermID = termID;
            TermType = termType;
            TermYear = termYear;
        }
    }
}
