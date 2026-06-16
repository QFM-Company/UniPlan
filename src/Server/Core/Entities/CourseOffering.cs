
namespace Core.Entities
{
    public class CourseOffering
    {
        public int OfferingID { get; set; }
        public int SectionNumber { get; set; }
        public int CreatedByAdminID { get; set; }
        public AcademicTerm? Term { get; set; }
        public Lecture? Lecture { get; set; }

        public CourseOffering()
        {
            OfferingID = default;
            SectionNumber = default;
            CreatedByAdminID = default;
            Term = new AcademicTerm();
            Lecture = new Lecture();
        }

        public CourseOffering(int offeringID)
        {
            OfferingID = offeringID;
        }

        public CourseOffering(int offeringID, int sectionNumber, int createdByAdminID, AcademicTerm term, Lecture lecture)
        {
            OfferingID = offeringID;
            SectionNumber = sectionNumber;
            CreatedByAdminID = createdByAdminID;
            Term = term;
            Lecture = lecture;
        }

        public CourseOffering(int offeringID, int sectionNumber, AcademicTerm term, Lecture lecture)
        {
            OfferingID = offeringID;
            SectionNumber = sectionNumber;
            Term = term;
            Lecture = lecture;
        }
    }
}
