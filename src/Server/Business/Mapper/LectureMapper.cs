using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class LectureMapper
    {
        public static Lecture ToLecture(this LectureRequest request)
        {
            return new Lecture(-1, request.LectureType, request.DurationValue, new Course { CourseID = request.CourseID });
        }

        public static void UpdateLecture(this Lecture lecture, LectureRequest? request)
        {
            if (request == null)
                return;

            lecture.DurationValue = request.DurationValue;
            lecture.LectureType = request.LectureType;
            
            if(lecture.Course != null)
                lecture.Course.CourseID = request.CourseID;
        }

        public static LectureResponse? ToResponse(this Lecture lecture)
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
