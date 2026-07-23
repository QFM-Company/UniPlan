using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class CoursePrerequisiteMapper
    {
        public static CoursePrerequisiteResponse? ToCoursePrerequisite(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count <= 1)
                return null;

            var mainCourse = new CourseResponse(
                int.TryParse(row["الرئيسي_معرف المقرر"]?.ToString(), out var mainId) ? mainId : 0,
                row["اسم المقرر"]?.ToString() ?? string.Empty,
                int.TryParse(row["الرئيسي_عدد الساعات"]?.ToString(), out var mainHrs) ? mainHrs : 0,
                row["رمز المقرر"]?.ToString() ?? string.Empty
            );

            var preCourse = new CourseResponse(
                int.TryParse(row["المتطلب_معرف المقرر"]?.ToString(), out var preId) ? preId : 0,
                row["اسم المتطلب"]?.ToString() ?? string.Empty,
                int.TryParse(row["المتطلب_عدد الساعات"]?.ToString(), out var preHrs) ? preHrs : 0,
                row["رمز المتطلب"]?.ToString() ?? string.Empty
            );

            return new CoursePrerequisiteResponse(
                int.TryParse(row["معرف المتطلب"]?.ToString(), out var id) ? id : 0,
                mainCourse,
                preCourse
            );
        }

        public static CoursePrerequisiteResponse ToCoursePrerequisite(this Person? model)
        {
            return model as CoursePrerequisiteResponse ?? new CoursePrerequisiteResponse(0, null, null);
        }
    }
}