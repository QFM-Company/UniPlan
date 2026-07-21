using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class AcademicTermRequest : BaseModel
    {
        [AllowedValues("يجب أن تكون قيمة الفصل الأكاديمي 1 (الأول) أو 2 (الثاني) أو 3 (الثالث) فقط", new object[] { 1, 2, 3 })]
        public int TermType { get; set; }

        [Required<int>("السنة الأكاديمية مطلوبة")]
        [Range<int>("يجب أن تكون السنة بين 2026 و 2100", 2026, 2100)]
        public int TermYear { get; set; }

        public AcademicTermRequest()
        {
            TermType = default;
            TermYear = default;
        }

        public AcademicTermRequest(int termType, int termYear)
        {
            TermType = termType;
            TermYear = termYear;
        }
    }
}