using Business.DTOs.Requests.Update;
using Client.Models.Requests;
using Client.Models.Responses;

namespace Client.Services
{
    public class AccountApiService
    {
        private readonly ApiService _apiService;

        public AccountApiService(ApiService apiService)
        {
            _apiService = apiService;

            _apiService.SubUri = "api/accounts";
        }

        public async Task<AccountResponse?> LoginAsync(LoginRequest login)
        {
            return await _apiService.PostAsync<LoginRequest, AccountResponse>(login, "login");
        }

        public async Task<bool> UpdatePassword(int accountID, ChangePasswordRequest changePassword)
        {
            return await _apiService.PutAsync(accountID, changePassword, "updatePassword");
        }
    }
}
