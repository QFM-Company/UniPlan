using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    internal interface IAdminRepository
    {
        bool DeleteAdmin(int AdminID);
        bool AddAdmin(Administrator Admin);
        bool UpdateAdmin(Administrator Admin);
        IReadOnlyCollection<Administrator> GetAllAdmins();
        Administrator GetAdminByID(int AdminID);

    }
}
