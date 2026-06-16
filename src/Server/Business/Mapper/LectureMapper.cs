using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class LectureMapper
    {
        public static Lecture? RequestToLecture(this LectureRequest request, int lectureID = -1)
        {
            if(request != null)
                return new Lecture(lectureID, request.LectureType, request.DurationValue, new Course { CourseID = request.CourseID });

            return null;
        }

        public static void UpdateLectureFromRequest(this Lecture lecture, LectureRequest request)
        {
            lecture.DurationValue = request.DurationValue;
            lecture.LectureType = request.LectureType;
            
            if(lecture.Course != null)
                lecture.Course.CourseID = request.CourseID;
        }

        public static LectureResponse? LectureToResponse(this Lecture lecture)
        {

            if (lecture.Course != null && lecture.Course.Major != null)
            {
               CourseResponse course = new CourseResponse(lecture.Course.CourseID, lecture.Course.CourseName, lecture.Course.CreditHours, lecture.Course.Major.MajorID);
               return new LectureResponse(lecture.LectureID, lecture.LectureType, lecture.DurationValue, course);
            }

            return null;
        }
    }
}
