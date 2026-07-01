using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateCourseOfferingRequest
    {
        [Required<int>("ãÚÑİ ÇáÚÑÖ ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÇáãÚÑİ ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int OfferingID { get; set; }

        [Required<int>("ÑŞã ÇáŞÓã ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÑŞã ÇáŞÓã ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int SectionNumber { get; set; }

        [Required<int>("ãÚÑİ ÇáİÕá ÇáÃßÇÏíãí ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÇáãÚÑİ ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int TermID { get; set; }

        [Required<int>("ãÚÑİ ÇáãÍÇÖÑÉ ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÇáãÚÑİ ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int LectureID { get; set; }

        [Required<int>("ãÚÑİ ÇáßæÑÓ ãØáæÈ")]
        [Range<int>("íÌÈ Ãä íßæä ÇáãÚÑİ ÃßÈÑ ãä 0", 1, int.MaxValue)]
        public int CourseID { get; set; }

        public UpdateCourseOfferingRequest()
        {
            OfferingID = default;
            SectionNumber = default;
            TermID = default;
            LectureID = default;
            CourseID = default;
        }

        public UpdateCourseOfferingRequest(int offeringID, int sectionNumber, int termID, int lectureID, int courseID)
        {
            OfferingID = offeringID;
            SectionNumber = sectionNumber;
            TermID = termID;
            LectureID = lectureID;
            CourseID = courseID;
        }
    }
}