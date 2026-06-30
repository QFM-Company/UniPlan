using Business.DTOs.Requests;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AccountService(IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<AccountResponse?> GetAccountByIDAsync(int accountID)
        {
            Account? account = await _accountRepository.GetAccountByIDAsync(accountID);
            return account != null ? account.ToResponse() : null;
        }

        public async Task<AccountResponse?> LoginAsync(LoginRequest request)
        {
            request.Password = _passwordHasher.HashPassword(request.Password);

            Account account = request.ToAccount();
            account.AccountID = await _accountRepository.LoginAsync(account);

            if (account.AccountID != -1)
                return await GetAccountByIDAsync(account.AccountID);

            return null;
        }

        public async Task<bool> UpdatePasswordAsync(ChangePasswordRequest request, int accountID)
        {
            Account? account = await _accountRepository.GetAccountByIDAsync(accountID);

            account?.UpdateAccount(request);
            if(account != null)
            {
                account.Password = _passwordHasher.HashPassword(account.Password);
                return await _accountRepository.UpdatePasswordAsync(account, request.OLdPassword);
            }

            return false;
        }
    }
}
