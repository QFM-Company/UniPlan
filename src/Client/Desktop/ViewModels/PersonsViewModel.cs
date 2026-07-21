using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;
using System.Data;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class PersonsViewModel : IViewModel
    {
        private readonly PersonApiService _personApi;
        private readonly IValidationService _validationService;

        public PersonsViewModel(PersonApiService personApiService, IValidationService validationService)
        {
            _personApi = personApiService;
            _validationService = validationService;
        }

        public async Task<bool> CreateAsync(BaseModel model)
        {
            var req = (PersonRequest)model;
            _validationService.Validate(req);
            req = await _personApi.PostPersonAsync(req);
            return req != null;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DataView> GetDataView(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<DataView> GetDataViewByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, BaseModel model)
        {
            throw new NotImplementedException();
        }
    }
}