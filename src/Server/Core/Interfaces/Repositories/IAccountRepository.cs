using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        public Task<bool> UpdatePasswordAsync(Account account, string oldPassword);

        Task<Account?> GetAccountByIDAsync(int accountID);

        Task<Account?> GetAccountByNameAsync(string accountName);
    }
}
