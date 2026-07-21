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
        public static HallResponse? ToHall(this DataRowView selectedRow)
        {
            if (selectedRow.Row.Table.Columns.Count <= 1)
                return null;

            HallResponse hallModel = new HallResponse();

            hallModel.HallID = int.Parse(selectedRow["معرف القاعة"].ToString() ?? string.Empty);
            hallModel.Floor = int.Parse(selectedRow["الطابق"].ToString() ?? string.Empty);
            hallModel.HallName = selectedRow["اسم القاعة"].ToString() ?? string.Empty;
            hallModel.Building = selectedRow["المبنى"].ToString() ?? string.Empty;

            return hallModel;
        }

        public static HallResponse ToHall(this BaseModel? baseModel)
        {
            if (baseModel == null)
                return new HallResponse();

            return (HallResponse) baseModel;
        }
    }
}
