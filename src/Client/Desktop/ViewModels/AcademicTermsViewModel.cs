using System.Data;
using Client.Models;
using Client.Services;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class AcademicTermsViewModel : IViewModel
    {
        private readonly ApiService<AcademicTermModel> _academicTermApi;

        public AcademicTermsViewModel(ApiService<AcademicTermModel> academicTermApiService)
        {
            _academicTermApi = academicTermApiService;
            _academicTermApi.SubUri = "api/academicterms";
        }

        private DataView _ConvertToDataView(List<AcademicTermModel>? models)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Term ID");
            table.Columns.Add("Term Type");
            table.Columns.Add("Term Year");

            if (models == null)
                return table.DefaultView;

            foreach (var term in models)
            {
                table.Rows.Add(
                    term.TermID,
                    term.TermType,
                    term.TermYear
                );
            }

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var models = await _academicTermApi.GetAllAsync(pageNumber, pageSize);
            return _ConvertToDataView(models);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var model = await _academicTermApi.GetByIdAsync(id);
            var list = new List<AcademicTermModel>();
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