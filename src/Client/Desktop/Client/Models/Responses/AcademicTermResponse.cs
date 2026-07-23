namespace Client.Models.Responses
{
    public class AcademicTermResponse : Person
    {
        public int TermID { get; set; }

        public string TermType { get; set; }

        public int TermYear { get; set; }

        public AcademicTermResponse()
        {
            TermID = default;
            TermType = string.Empty;
            TermYear = default;
        }

        public AcademicTermResponse(int termID, string termType, int termYear)
        {
            TermID = termID;
            TermType = termType;
            TermYear = termYear;
        }
    }
}
