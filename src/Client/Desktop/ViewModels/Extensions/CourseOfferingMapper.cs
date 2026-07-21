using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class CourseOfferingMapper
    {
        public static CourseOfferingResponse? ToCourseOffering(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count == 0) return null;
            return new CourseOfferingResponse(
                int.TryParse(row["معرف الشعبة"]?.ToString(), out var id) ? id : 0,
                int.TryParse(row["رقم القسم"]?.ToString(), out var sec) ? sec : 0,
                0,
                new AcademicTermResponse(),
                new LectureResponse()
            );
        }

        public static CourseOfferingResponse ToCourseOffering(this BaseModel? model)
        {
            return model as CourseOfferingResponse ?? new CourseOfferingResponse();
        }
    }
}