using System.Data;
using Client.Models;
using Client.Services;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class MajorsViewModel : IViewModel
    {
        private readonly ApiService<MajorModel> _majorApi;

        public MajorsViewModel(ApiService<MajorModel> majorApiService)
        {
            _majorApi = majorApiService;
            _majorApi.SubUri = "api/majors";
        }

        private DataView _ConvertToDataView(List<MajorModel>? models)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Major ID");
            table.Columns.Add("Major Name");

            if (models == null)
                return table.DefaultView;

            foreach (var major in models)
            {
                table.Rows.Add(
                    major.MajorID,
                    major.MajorName ?? string.Empty
                );
            }

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            List<MajorModel>? models = await _majorApi.GetAllAsync(pageNumber, pageSize);
            return _ConvertToDataView(models);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            MajorModel? model = await _majorApi.GetByIdAsync(id);

            List<MajorModel> majorModels = new List<MajorModel>();

            if (model != null)
                majorModels.Add(model);

            return _ConvertToDataView(majorModels);
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