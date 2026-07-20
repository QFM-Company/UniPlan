using Client.Models;
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
        public static HallModel? ToHall(this DataRowView selectedRow)
        {
            if (selectedRow.Row.Table.Columns.Count == 1)
                return null;

            HallModel hallModel = new HallModel();

            hallModel.HallID = Convert.ToInt32(selectedRow["Hall ID"]);
            hallModel.Floor = Convert.ToInt32(selectedRow["Floor"]);
            hallModel.HallName = selectedRow["Hall Name"].ToString() ?? string.Empty;
            hallModel.Building = selectedRow["Building"].ToString() ?? string.Empty;

            return hallModel;
        }
    }
}
