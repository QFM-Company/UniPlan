using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class PersonMapper
    {
        public static PersonResponse? ToPerson(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count == 0) return null;
            return new PersonResponse(
                int.TryParse(row["معرف الشخص"]?.ToString(), out var id) ? id : 0,
                row["الاسم الأول"]?.ToString() ?? string.Empty,
                row["الاسم الأوسط"]?.ToString() ?? string.Empty,
                row["الاسم الأخير"]?.ToString() ?? string.Empty
            );
        }

        public static PersonResponse ToPerson(this BaseModel? model)
        {
            return model as PersonResponse ?? new PersonResponse();
        }
    }
}