using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class CourseMapper
    {
        public static CourseResponse? ToCourse(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count <= 1)
                return null;

            return new CourseResponse(
                int.TryParse(row["معرف المقرر"]?.ToString(), out var id) ? id : 0,
                row["اسم المقرر"]?.ToString(),
                int.TryParse(row["عدد الساعات"]?.ToString(), out var hrs) ? hrs : 0,
                row["رمز المقرر"]?.ToString()
            );
        }

        public static CourseResponse ToCourse(this Person? model)
        {
            return model as CourseResponse ?? new CourseResponse(0, null, 0, null);
        }
    }
}