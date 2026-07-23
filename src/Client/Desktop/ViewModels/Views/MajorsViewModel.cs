using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Extensions;
using ViewModels.Interfaces;

namespace ViewModels.Views
{
    public class MajorsViewModel : IViewModel
    {
        private readonly MajorApiService _majorApi;
        private readonly IValidationService _validationService;

        public MajorsViewModel(MajorApiService majorApiService, IValidationService validationService)
        {
            _majorApi = majorApiService;
            _validationService = validationService;
        }

        private DataView _ToDataView(List<MajorResponse>? majors)
        {
            DataTable table = new DataTable();
            table.AddMajorColumns();
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            if (majors == null) 
                return table.DefaultView;

            foreach (var m in majors)
                table.Rows.Add(m.MajorID, m.MajorName);

            return table.DefaultView;
        }

        public async Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            var data = await _majorApi.GetMajorsAsync(pageNumber, pageSize);
            return _ToDataView(data);
        }

        public async Task<DataView> GetDataViewByID(int id)
        {
            var data = await _majorApi.GetMajorByIDAsync(id);

            var list = data == null ? new List<MajorResponse>() : new List<MajorResponse> { data };
            return _ToDataView(list);
        }

        public async Task<bool> CreateAsync(Person model)
        {
            var req = (MajorRequest)model;
            _validationService.Validate(req);

            var res = await _majorApi.CreateMajorAsync(req);
            return res != null;
        }

        public async Task<bool> UpdateAsync(int id, Person model)
        {
            var req = (MajorRequest)model;
            _validationService.Validate(req);

            return await _majorApi.UpdateMajorAsync(id, req);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _majorApi.DeleteMajorAsync(id);
        }
    }
}