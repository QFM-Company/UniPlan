using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class StudentMapper
    {
        public static StudentResponse? ToStudent(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count == 0)
                return null;

            return new StudentResponse
            {
                StudentID = int.TryParse(row["معرف الطالب"]?.ToString(), out var id) ? id : 0,
                PersonInfo = new PersonResponse(),
                AccountInfo = new AccountResponse(),
                MajorInfo = new MajorResponse()
            };
        }

        public static StudentResponse ToStudent(this BaseModel? model)
        {
            return model as StudentResponse ?? new StudentResponse();
        }
    }
}