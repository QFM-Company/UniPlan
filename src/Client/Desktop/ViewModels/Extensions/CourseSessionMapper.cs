using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class CourseSessionMapper
    {
        public static CourseSessionResponse? ToCourseSession(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count == 0) return null;
            return new CourseSessionResponse(
                int.TryParse(row["معرف الجلسة"]?.ToString(), out var id) ? id : 0,
                new CourseOfferingResponse(),
                new HallResponse(),
                TimeSpan.TryParse(row["وقت البداية"]?.ToString(), out var st) ? st : TimeSpan.Zero,
                TimeSpan.TryParse(row["وقت النهاية"]?.ToString(), out var et) ? et : TimeSpan.Zero,
                null,
                row["اليوم"]?.ToString() ?? string.Empty
            );
        }

        public static CourseSessionResponse ToCourseSession(this BaseModel? model)
        {
            return model as CourseSessionResponse ?? new CourseSessionResponse(0, new CourseOfferingResponse(), new HallResponse(), TimeSpan.Zero, TimeSpan.Zero, null, "");
        }
    }
}