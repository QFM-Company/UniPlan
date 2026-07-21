using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class AcademicTermMapper
    {
        public static AcademicTermResponse? ToAcademicTerm(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count == 0) return null;
            return new AcademicTermResponse(
                int.TryParse(row["معرف الفصل"]?.ToString(), out var id) ? id : 0,
                row["نوع الفصل"]?.ToString() ?? string.Empty,
                int.TryParse(row["السنة"]?.ToString(), out var year) ? year : 0
            );
        }

        public static AcademicTermResponse ToAcademicTerm(this BaseModel? model)
        {
            return model as AcademicTermResponse ?? new AcademicTermResponse();
        }
    }
}