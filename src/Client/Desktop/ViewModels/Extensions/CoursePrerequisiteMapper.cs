using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class CoursePrerequisiteMapper
    {
        public static CoursePrerequisiteResponse? ToCoursePrerequisite(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count == 0) return null;
            return new CoursePrerequisiteResponse(
                int.TryParse(row["معرف المتطلب"]?.ToString(), out var id) ? id : 0,
                new CourseResponse(0, null, 0, null),
                new CourseResponse(0, null, 0, null)
            );
        }

        public static CoursePrerequisiteResponse ToCoursePrerequisite(this BaseModel? model)
        {
            return model as CoursePrerequisiteResponse ?? new CoursePrerequisiteResponse(0, null, null);
        }
    }
}