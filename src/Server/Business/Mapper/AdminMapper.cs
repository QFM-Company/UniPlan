using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class AdminMapper
    {

        public static Administrator ToAdministrator(this CreateAdministratorRequest request, int adminID = -1)
        {
            Person person = new Person(request.PersonID);
            Account? account = request.Account?.ToAccount() ?? null;
            return new Administrator(adminID, person, account, true);
        }

        public static void UpdateAdmin(this Administrator admin, UpdateAdministratorRequest? request)
        {
            if (request == null || admin.Person == null)
                return;

            admin.Account?.UpdateAccount(request.Account);
            
            admin.Person.PersonID = request.PersonID;
        }

        public static AdministratorResponse ToResponse(this Administrator admin)
        {
            PersonRequest person = new PersonRequest(admin.Person!.FirstName , admin.Person.MiddleName, admin.Person.LastName);
            AccountResponse account = new AccountResponse(admin.Account!.AccountID, admin.Account.AccountName, admin.Account.Email);
            return new AdministratorResponse(admin.AdminID, person, account, admin.IsActive);
        }

    }
}
