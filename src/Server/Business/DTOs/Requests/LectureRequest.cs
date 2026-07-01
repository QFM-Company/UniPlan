using Core.Enums;
using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests
{
    public class LectureRequest
    {
        public LectureType LectureType { get; set; }

        [Required<int>("„œ… «·„Õ«÷—… „ÿ·Ê»…")]
        [Range<int>("ÌÃ» √‰  ﬂÊ‰ «·„œ… √ﬂ»— „‰ 0", 1, int.MaxValue)]
        public int DurationValue { get; set; }

        [Required<int>("„⁄—› «·ﬂÊ—” „ÿ·Ê»")]
        [Range<int>("ÌÃ» √‰ ÌﬂÊ‰ «·„⁄—› √ﬂ»— „‰ 0", 1, int.MaxValue)]
        public int CourseID { get; set; }

        public LectureRequest()
        {
            LectureType = LectureType.Practical;
            DurationValue = default;
            CourseID = default;
        }

        public LectureRequest(LectureType lectureType, int durationValue, int courseID)
        {
            LectureType = lectureType;
            DurationValue = durationValue;
            CourseID = courseID;
        }
    }
}