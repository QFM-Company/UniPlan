using Core.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Mapping
{
    public static class CourseOfferingMapper
    {
        public static CourseOffering ToCourseOffering(this SqlDataReader reader)
        {
            Lecture lecture = reader.ToLecture();
            AcademicTerm term = reader.ToAcademicTerm();

            if (!int.TryParse(reader["OfferingID"]?.ToString(), out int offeringID))
            {
                offeringID = 0;
            }
            if (!int.TryParse(reader["SectionNumber"]?.ToString(), out int sectionNumber))
            {
                sectionNumber = 0;
            }
            if (!int.TryParse(reader["CreatedByAdminID"]?.ToString(), out int createdByAdminID))
            {
                createdByAdminID = 0;
            }

            return new CourseOffering(offeringID, sectionNumber, createdByAdminID, term, lecture);
        }

        public static DataTable ToDataTable(this List<CourseOffering> Offerings)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("OfferingID", typeof(int));

            foreach (CourseOffering item in Offerings)
            {
                dataTable.Rows.Add(item.OfferingID);
            }

            return dataTable;
        }
    }
}
