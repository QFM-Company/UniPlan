using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class CourseOfferingMapper
    {
        public static CourseOffering ToCourseOffering(this CreateCourseOfferingRequest request)
        {
            AcademicTerm term = new AcademicTerm(request.TermID);
            Lecture lecture = new Lecture(request.LectureID, request.CourseID);

            return new CourseOffering(-1, request.SectionNumber, request.CreatedByAdminID, term, lecture);
        }

        public static void UpdateOffering(this CourseOffering offering, UpdateCourseOfferingRequest? request)
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

        public static CourseOfferingResponse ToResponse(this CourseOffering offering)
        {
            LectureResponse lecture = new LectureResponse();
            AcademicTermResponse academicTerm = new AcademicTermResponse();

            if (offering.Lecture != null)
            {
                lecture = offering.Lecture.ToResponse() ?? new LectureResponse();
            }

            if (offering.Term != null)
            {
                academicTerm = offering.Term.ToResponse();
            }

            return new CourseOfferingResponse(offering.OfferingID, offering.SectionNumber, offering.CreatedByAdminID, academicTerm, lecture);
        }
    }
}
