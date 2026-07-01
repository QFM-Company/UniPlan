using Infrastructure.ExternalServices.Validation.Attributes;
using Core.Enums;

namespace Business.DTOs.Requests
{
    public class AcademicTermRequest
    {
        public TermType TermType { get; set; }

        [Required<int>("«·”‰… «·√ﬂ«œÌ„Ì… „ÿ·Ê»…")]
        [Range<int>("ÌÃ» √‰  ﬂÊ‰ «·”‰… »Ì‰ 2000 Ê 2100", 2000, 2100)]
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