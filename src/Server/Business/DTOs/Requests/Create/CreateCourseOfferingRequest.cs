using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Create
{
    public class CreateCourseOfferingRequest
    {
        [Required<int>("ÑŞã ÇáŞÓã ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÑŞã ÇáŞÓã ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int SectionNumber { get; set; }

        [Required<int>("ãÚÑİ ÇáİÕá ÇáÃßÇÏíãí ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÇáãÚÑİ ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int TermID { get; set; }

        [Required<int>("ãÚÑİ ÇáãÍÇÖÑÉ ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÇáãÚÑİ ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int LectureID { get; set; }

        [Required<int>("ãÚÑİ ÇáÃÏãä ÇáãäÔÆ ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÇáãÚÑİ ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int CreatedByAdminID { get; set; }

        [Required<int>("ãÚÑİ ÇáßæÑÓ ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÇáãÚÑİ ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int CourseID { get; set; }

        public CreateCourseOfferingRequest()
        {
            CreatedByAdminID = default;
            SectionNumber = default;
            TermID = default;
            LectureID = default;
            CourseID = default;
        }

        public CreateCourseOfferingRequest(int sectionNumber, int termID, int lectureID, int createdByAdminID, int courseID)
        {
            SectionNumber = sectionNumber;
            TermID = termID;
            LectureID = lectureID;
            CreatedByAdminID = createdByAdminID;
            CourseID = courseID;
        }
    }
}