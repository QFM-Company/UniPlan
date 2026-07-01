using System.ComponentModel.DataAnnotations;
using Business.DTOs.Responses;
using Core.Entities;
using Core.Interfaces.ExternalServices;
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

        public CourseRequest(IValidationService validationService , string? courseName, int creditHours)
        {
            CourseName = courseName;
            CreditHours = creditHours;
        }
    }
}
