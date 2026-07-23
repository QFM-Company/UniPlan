using Infrastructure.ExternalServices.Validation.Attributes;
using Infrastructure.ExternalServices.Validation.Enums;

namespace Client.Models.Requests
{
    public class PeriodRequest : Person
    {
        [Required<TimeSpan>("الفترة مطلوبة")]
        public TimeSpan StartTime { get; set; }

        [Required<TimeSpan>("الفترة مطلوبة")]
        [Compare(nameof(StartTime), ComparisonType.GreaterThan, "يجب ان تكون الفنرة الثانية اكبر من الفترة الاولى")]
        public TimeSpan EndTime { get; set; }

    }
}
