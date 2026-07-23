using Client.Models.Requests;
using Client.Services;
using Core.Interfaces.ExternalServices;

namespace ViewModels.Views
{
    public class PersonsViewModel
    {
        private readonly PersonApiService _personApi;
        private readonly IValidationService _validationService;

        public PersonsViewModel(PersonApiService personApiService, IValidationService validationService)
        {
            _personApi = personApiService;
            _validationService = validationService;
        }

        public async Task<bool> CreatePersonAsync(PersonRequest person)
        {
            _validationService.Validate(person);

            var res = await _personApi.CreatePersonAsync(person);
            return res != null;
        }
    }
}