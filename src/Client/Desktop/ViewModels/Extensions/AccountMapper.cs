using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class AccountMapper
    {
        public static AccountResponse? ToAccount(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count <= 1)
                return null;

            return new AccountResponse(
                int.TryParse(row["معرف الحساب"]?.ToString(), out var id) ? id : -1,
                row["اسم الحساب"]?.ToString() ?? string.Empty,
                row["البريد الإلكتروني"]?.ToString() ?? string.Empty
            );
        }

        public static AccountResponse ToAccount(this Person? model)
        {
            return model as AccountResponse ?? new AccountResponse();
        }
    }
}