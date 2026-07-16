using Core.Enums;

namespace Core.Extensions
{
    public static class EnumExtensions
    {
        public static string ToArabicString(this LectureType lectureType)
        {
            return (lectureType) switch
            {
                LectureType.Practical => "عملي",
                LectureType.Theoretical => "نظري",
                LectureType.TD => "TD",
                _ => string.Empty
            };
        }

        public static string ToArabicString(this DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Saturday => "السبت",
                DayOfWeek.Sunday => "الأحد",
                DayOfWeek.Monday => "الإثنين",
                DayOfWeek.Tuesday => "الثلاثاء",
                DayOfWeek.Wednesday => "الأربعاء",
                DayOfWeek.Thursday => "الخميس",
                DayOfWeek.Friday => "الجمعة",
                _ => string.Empty
            };
        }
    }
}
