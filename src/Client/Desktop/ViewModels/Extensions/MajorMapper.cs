using Client.Models;
using System.Data;

namespace ViewModels.Extensions
{
    public static class MajorMapper
    {
        public static MajorModel? ToMajor(this DataRowView selectedRow)
        {
            if (selectedRow.Row.Table.Columns.Count == 1)
                return null;

            MajorModel majorModel = new MajorModel();

            majorModel.MajorID = Convert.ToInt32(selectedRow["Major ID"]);
            majorModel.MajorName = selectedRow["Major Name"].ToString() ?? string.Empty;

            return majorModel;
        }
    }
}
