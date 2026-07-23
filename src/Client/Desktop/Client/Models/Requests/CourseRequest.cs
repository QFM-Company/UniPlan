using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class CourseRequest : Person
    {
        [Required<string>("يجب ادخال اسم الكورس")]
        public string? CourseName { get; set; }

        [Required<int>("يجب ادخال عدد الساعات")]
        [Range<int>("يجب ان يكون عدد الساعات اكبر تماما من 0", 1, int.MaxValue)]
        public int CreditHours { get; set; }

        public string? CourseCode { get; set; }

    }
}
