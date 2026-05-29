using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        Task<bool> DeleteAdmin(int AdminID);
        Task<int> AddAdmin(Administrator Admin);
        Task<bool> UpdateAdmin(Administrator Admin);
        Task<IReadOnlyCollection<Administrator>?> GetPageAdmins(int pageNumber , int pageSize);
        Task<Administrator?> GetAdminByID(int AdminID);

    }
}
