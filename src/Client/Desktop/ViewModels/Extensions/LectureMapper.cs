using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class LectureMapper
    {
        public static LectureResponse? ToLecture(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count == 0) return null;
            return new LectureResponse(
                int.TryParse(row["معرف المحاضرة"]?.ToString(), out var id) ? id : 0,
                row["نوع المحاضرة"]?.ToString() ?? string.Empty,
                int.TryParse(row["المدة"]?.ToString(), out var dur) ? dur : 0,
                new CourseResponse(0, null, 0, null)
            );
        }

        public static LectureResponse ToLecture(this BaseModel? model)
        {
            return model as LectureResponse ?? new LectureResponse();
        }
    }
}