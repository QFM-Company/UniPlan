using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class CourseOfferingMapper
    {
        public static CourseOfferingResponse? ToCourseOffering(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count <= 1)
                return null;

            return new CourseOfferingResponse(
                int.TryParse(row["معرف الشعبة"]?.ToString(), out var id) ? id : 0,
                int.TryParse(row["رقم الشعبة"]?.ToString(), out var sec) ? sec : 0,
                int.TryParse(row["معرف المدير المنشئ (العرض)"]?.ToString(), out var admin) ? admin : 0,
                row.ToAcademicTerm(),
                row.ToLecture()
            );
        }

        public static CourseOfferingResponse ToCourseOffering(this Person? model)
        {
            return model as CourseOfferingResponse ?? new CourseOfferingResponse();
        }
    }
}