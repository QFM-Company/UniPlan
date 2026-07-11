using Core.Entities;
using System.Data;

namespace DataAccess.Mapping
{
    public static class DataTableMapper
    {
        public static DataTable ToDataTable(this List<CourseOffering> offerings)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("OfferingID", typeof(int));

            foreach (CourseOffering item in offerings)
            {
                dataTable.Rows.Add(item.OfferingID);
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
