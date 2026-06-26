using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        public Task<int> LoginAsync(Account account);

        public Task<bool> UpdatePasswordAsync(Account account, string oldPassword);

        Task<Account?> GetAccountByIDAsync(int accountID);
    }
}
