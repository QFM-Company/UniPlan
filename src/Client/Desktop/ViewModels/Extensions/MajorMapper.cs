using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class MajorMapper
    {
        public static MajorResponse? ToMajor(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count == 0) return null;
            return new MajorResponse(
                int.TryParse(row["معرف التخصص"]?.ToString(), out var id) ? id : 0,
                row["اسم التخصص"]?.ToString()
            );
        }

        public static MajorResponse ToMajor(this BaseModel? model)
        {
            return model as MajorResponse ?? new MajorResponse();
        }
    }
}