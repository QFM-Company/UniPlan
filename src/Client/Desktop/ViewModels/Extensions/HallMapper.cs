using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Extensions
{
    public static class HallMapper
    {
        public static HallResponse? ToHall(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count <= 1)
                return null;

            return new HallResponse
            {
                HallID = int.TryParse(row["معرف القاعة"]?.ToString(), out var id) ? id : 0,
                HallName = row["اسم القاعة"]?.ToString() ?? string.Empty,
                Building = row["المبنى"]?.ToString() ?? string.Empty,
                Floor = int.TryParse(row["الطابق"]?.ToString(), out var floor) ? floor : 0,
                CreatedByAdminID = int.TryParse(row["معرف المدير المنشئ (القاعة)"]?.ToString(), out var admin) ? admin : 0
            };
        }

        public static HallResponse ToHall(this Person? baseModel)
        {
            if (baseModel == null)
                return new HallResponse();

            return (HallResponse) baseModel;
        }
    }
}
