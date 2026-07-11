using Core.Entities;
using DataAccess.Extensions;
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

            reader.ReadInt("OfferingID", out int offeringID, 0);
            reader.ReadInt("SectionNumber", out int sectionNumber, 0);
            reader.ReadInt("CreatedByAdminID", out int createdByAdminID, 0);

            return new CourseOffering(offeringID, sectionNumber, createdByAdminID, term, lecture);
        }

        public static CourseOffering ToCourseOfferingBasicInfo(this SqlDataReader reader)
        {
            reader.ReadInt("OfferingID", out int offeringID, 0);
            reader.ReadInt("SectionNumber", out int sectionNumber, 0);

            CourseOffering offering = new CourseOffering();

            (offering.OfferingID, offering.SectionNumber) = (offeringID, sectionNumber);

            return offering;
        }
    }
}
