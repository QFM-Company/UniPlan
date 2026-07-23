using Client.Models;
using Client.Models.Responses;
using Client.Services;
using System.Data;
using ViewModels.Extensions;
using ViewModels.Interfaces;

namespace ViewModels.Views
{
    public class StudentsViewModel : IViewModel
    {
        private readonly StudentApiService _studentApi;

        public StudentsViewModel(StudentApiService studentApiService)
        {
            _studentApi = studentApiService;
        }

        private DataView _ToDataView(List<StudentResponse>? students)
        {
            DataTable table = new DataTable();
            table.AddStudentColumns(); 
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (students == null) 
                return table.DefaultView;

            foreach (var s in students)
            {
                var p = s.PersonInfo ?? new PersonResponse();
                var acc = s.AccountInfo ?? new AccountResponse();
                var m = s.MajorInfo ?? new MajorResponse();
                table.Rows.Add(
                    s.StudentID,
                    p.PersonID, p.FirstName, p.MiddleName, p.LastName,"",
                    acc.AccountID, acc.AccountName, acc.Email,
                    m.MajorID, m.MajorName
                );
            }

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _studentApi.GetStudentsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _studentApi.GetStudentByIDAsync(id);

            var list = data == null ? new List<StudentResponse>() : new List<StudentResponse> { data };
            return _ToDataView(list);
        }

        public Task<bool> CreateAsync(Person model)
        {
            throw new NotSupportedException("لا يمكن إنشاء طالب جديد من خلال هذه الواجهة.");
        }

        public Task<bool> UpdateAsync(int id, Person model)
        {
            throw new NotSupportedException("لا يمكن تحديث بيانات الطالب من خلال هذه الواجهة.");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _studentApi.DeleteStudentAsync(id);
        }
    }
}