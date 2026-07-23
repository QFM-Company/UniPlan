using Business.DTOs.Requests.Update;
using Client.Models.Requests;
using Client.Models.Responses;
using Client.Services;
using Core.Interfaces.ExternalServices;

namespace ViewModels.Views
{
    public class AccountViewModel
    {
        public readonly AccountApiService _accountApi;
        private readonly IValidationService _validationService;

        public AccountViewModel(AccountApiService personApiService, IValidationService validationService)
        {
            _accountApi = personApiService;
            _validationService = validationService;
        }

        public async Task<AccountResponse?> LoginAsync(LoginRequest login)
        {
            _validationService.Validate(login);
            return await _accountApi.LoginAsync(login);
        }

        public async Task<bool> UpdatePasswordAsync(int id, ChangePasswordRequest changePassword)
        {
            _validationService.Validate(changePassword);
            return await _accountApi.UpdatePassword(id, changePassword);
        }
    }
}
