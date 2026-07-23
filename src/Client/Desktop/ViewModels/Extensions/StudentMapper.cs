using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class StudentMapper
    {
        public static StudentResponse? ToStudent(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count <= 1)
                return null;

            return new StudentResponse(
                int.TryParse(row["معرف الطالب"]?.ToString(), out var id) ? id : 0,
                row.ToPerson(),
                row.ToAccount(),
                row.ToMajor()
            );
        }

        public static StudentResponse ToStudent(this Person? model)
        {
            return model as StudentResponse ?? new StudentResponse();
        }
    }
}