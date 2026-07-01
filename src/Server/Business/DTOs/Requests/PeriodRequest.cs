using Infrastructure.ExternalServices.Validation.Attributes;
using Infrastructure.ExternalServices.Validation.Enums;

namespace Business.DTOs.Requests
{
    public class PeriodRequest
    {
        [Required<TimeSpan>("الفترة مطلوبة")]
        public TimeSpan StartTime { get; set; }

        [Required<TimeSpan>("الفترة مطلوبة")]
        [Compare(nameof(StartTime) , ComparisonType.GreaterThan , "يجب ان تكون الفنرة الثانية اكبر من الفترة الاولى")]
        public TimeSpan EndTime { get; set; }

        public PeriodRequest(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
