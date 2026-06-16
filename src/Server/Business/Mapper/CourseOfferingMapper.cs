using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class CourseOfferingMapper
    {
        public static CourseOffering? CreateRequestToCourseOffering(this CreateCourseOfferingRequest? request)
        {
            if (request == null)
                return null;

            AcademicTerm term = new AcademicTerm(request.TermID);
            Lecture lecture = new Lecture(request.LectureID, request.CourseID);

            return new CourseOffering(-1, request.SectionNumber, request.CreatedByAdminID, term, lecture);
        }

        public static void UpdateOfferingFromRequest(this CourseOffering offering, UpdateCourseOfferingRequest? request)
        {
            if (request == null)
                return;

            offering.SectionNumber = request.SectionNumber;
            
            if (offering.Term != null && offering.Lecture != null && offering.Lecture.Course != null)
            {
                offering.Term.TermID = request.TermID;
                offering.Lecture.LectureID = request.LectureID;
                offering.Lecture.Course.CourseID = request.CourseID;
            }
        }

        public static CourseOfferingResponse CourseOfferingToResponse(this CourseOffering offering)
        {
            LectureResponse lecture = new LectureResponse();
            AcademicTermResponse academicTerm = new AcademicTermResponse();

            if (offering.Lecture != null)
            {
                lecture = offering.Lecture.LectureToResponse() ?? new LectureResponse();
            }

            if (offering.Term != null)
            {
                academicTerm = offering.Term.AcademicTermToResponse();
            }

            return new CourseOfferingResponse(offering.OfferingID, offering.SectionNumber, offering.CreatedByAdminID, academicTerm, lecture);
        }
    }
}
