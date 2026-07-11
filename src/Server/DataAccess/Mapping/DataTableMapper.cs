using System.Data;

namespace DataAccess.Mapping
{
    public static class DataTableMapper
    {
        public static DataTable ToDataTable(this List<List<int>> offerings)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("OfferingID", typeof(int));
            dataTable.Columns.Add("ScheduleNum", typeof(int));

            for (int i = 0; i < offerings.Count; i++)
            {
                foreach (var offeringID in offerings[i])
                {
                    dataTable.Rows.Add(new object[] { offeringID, i + 1 });
                }
            }

            return dataTable;
        }

        public static DataTable ToDataTable(this List<int> days)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Day", typeof(int));

            foreach (DayOfWeek day in days)
            {
                dataTable.Rows.Add(day);
            }

            return dataTable;
        }
    }
}
