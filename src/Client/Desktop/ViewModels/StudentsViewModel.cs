using Client.Models;
using Client.Models.Responses;
using Client.Services;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class StudentsViewModel : IViewModel
    {
        private readonly StudentApiService _studentApi;

        public StudentsViewModel(StudentApiService studentApiService)
        {
            _studentApi = studentApiService;
        }

        private DataView _ToDataView(List<StudentResponse>? studentResponses)
        {
            DataTable table = new DataTable();

            table.Columns.Add("معرف الطالب", typeof(int));
            table.Columns.Add("الاسم الكامل", typeof(string));
            table.Columns.Add("البريد الإلكتروني", typeof(string));
            table.Columns.Add("التخصص", typeof(string));

            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (studentResponses == null)
                return table.DefaultView;

            foreach (var student in studentResponses)
            {
                string fullName = student.PersonInfo?.FullName ?? string.Empty;
                string email = student.AccountInfo?.Email ?? string.Empty;
                string major = student.MajorInfo?.MajorName ?? string.Empty;

                table.Rows.Add(
                    student.StudentID,
                    fullName,
                    email,
                    major
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
            var data = await _studentApi.GetStudentAsync(id);
            var list = data == null ? new List<StudentResponse>() : new List<StudentResponse> { data };
            return _ToDataView(list);
        }

        public Task<bool> CreateAsync(BaseModel model)
        {
            throw new NotSupportedException("لا يمكن إنشاء طالب جديد من خلال هذه الواجهة.");
        }

        public Task<bool> UpdateAsync(int id, BaseModel model)
        {
            throw new NotSupportedException("لا يمكن تحديث بيانات الطالب من خلال هذه الواجهة.");
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotSupportedException("لا يمكن حذف طالب من خلال هذه الواجهة.");
        }
    }
}