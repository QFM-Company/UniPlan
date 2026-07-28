using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests
{
    public class CourseRequest
    {
        [Required<string>("يجب ادخال اسم الكورس")]
        public string? CourseName { get; set; }

        [Required<int>("يجب ادخال عدد الساعات")]
        [Range<int>("يجب ان يكون عدد الساعات اكبر تماما من 0", 1, int.MaxValue)]
        public int CreditHours { get; set; }
        public string? CourseCode { get; set; }
        [Range<int>("يجب ان يكون عدد الساعات لفتح المادة موجبا او صفر", 0, int.MaxValue)]
        public int NeededHours { get; set; }


        public CourseRequest(string? courseName, int creditHours, string? courseCode, int neededHours)
        {
            CourseName = courseName;
            CreditHours = creditHours;
            CourseCode = courseCode;
            NeededHours = neededHours;
        }
    }
}
