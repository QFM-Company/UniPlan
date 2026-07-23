using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class AdministratorMapper
    {
        public static AdministratorResponse? ToAdministrator(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count <= 1)
                return null;

            return new AdministratorResponse(
                int.TryParse(row["معرف المدير"]?.ToString(), out var id) ? id : 0,
                row.ToPerson(),
                row.ToAccount(),
                row["نشط"].ToString() == "نعم"
            );
        }

        public static AdministratorResponse ToAdministrator(this Person? model)
        {
            return model as AdministratorResponse ?? new AdministratorResponse(0, new PersonResponse(), new AccountResponse(), false);
        }
    }
}