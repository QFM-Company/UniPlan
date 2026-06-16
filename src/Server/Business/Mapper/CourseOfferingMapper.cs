using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class CourseOfferingMapper
    {
        public static CourseOffering? CreateRequestToCourseOffering(this CourseOffering offering, CreateCourseOfferingRequest? request)
        {
            if (request == null)
                return null;

            AcademicTerm term = new AcademicTerm(request.TermID);
            Lecture lecture = new Lecture(request.LectureID, request.CourseID);

            return new CourseOffering(-1, request.SectionNumber, request.CreatedByAdminID, term, lecture);
        }

        public static CourseOffering? UpdateRequestToCourseOffering(this CourseOffering offering, UpdateCourseOfferingRequest? request, int offeringID = -1)
        {
            if (request == null)
                return null;

            
            AcademicTerm term = new AcademicTerm(request.TermID);
            Lecture lecture = new Lecture(request.LectureID, request.CourseID);

            return new CourseOffering(offeringID, request.SectionNumber, term, lecture);
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
