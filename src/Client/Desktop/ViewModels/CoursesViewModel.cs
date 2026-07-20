using System.Data;
using Client.Models;
using Client.Services;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class CoursesViewModel : IViewModel
    {
        private readonly ApiService<CourseModel> _courseApi;

        public CoursesViewModel(ApiService<CourseModel> courseApiService)
        {
            _courseApi = courseApiService;
            _courseApi.SubUri = "api/courses";
        }

        private DataView _ConvertToDataView(List<CourseModel>? models)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID");
            table.Columns.Add("Course Name");
            table.Columns.Add("Credit Hours");
            table.Columns.Add("Course Code");

            if (models == null)
                return table.DefaultView;

            foreach (var course in models)
            {
                table.Rows.Add(
                    course.CourseID,
                    course.CourseName,
                    course.CreditHours,
                    course.CourseCode
                );
            }

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var models = await _courseApi.GetAllAsync(pageNumber, pageSize);
            return _ConvertToDataView(models);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var model = await _courseApi.GetByIdAsync(id);
            var list = new List<CourseModel>();
            if (model != null)
                list.Add(model);
            return _ConvertToDataView(list);
        }

        public Task<bool> CreateAsync(BaseModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BaseModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}