using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;
using Core.Extensions;

namespace Business.Mapper
{
    public static class CourseSessionMapper
    {
        public static CourseSession ToCourseSession(this CreateCourseSessionRequest request)
        {
            CourseOffering courseOffering = new CourseOffering(request.CourseOfferingID);
            Hall hall = new Hall(request.HallID);

            int adminID = request.CreatedByAdminID;

            return new CourseSession(
                -1,
                courseOffering,
                hall,
                request.PeriodData.StartTime,
                request.PeriodData.EndTime,
                adminID,
                request.Day
            );
        }

        public static void UpdateCourseSession(this CourseSession courseSession, UpdateCourseSessionRequest request)
        {
            courseSession.Hall = new Hall();
            courseSession.Hall.HallID = request.HallID;
            courseSession.CourseOffering = new CourseOffering();
            courseSession.CourseOffering.OfferingID = request.CourseOfferingID;
            courseSession.StartTime = request.PeriodData.StartTime;
            courseSession.EndTime = request.PeriodData.EndTime;
            courseSession.Day = request.Day;
        }

        public static CourseSessionResponse ToResponse(this CourseSession courseSession)
        {
            return new CourseSessionResponse(
                 courseSession.SessionID,
                 courseSession.CourseOffering!.ToResponse(),
                 courseSession.Hall!.ToResponse(),
                 courseSession.StartTime,
                 courseSession.EndTime,
                 courseSession.CreatedByAdminID,
                 courseSession.Day.ToArabicString()
            );
        }

        public static SessionBriefResponse ToBriefResponse(this CourseSession courseSession)
        {
            return new SessionBriefResponse(
                 courseSession.SessionID,
                 courseSession.CourseOffering!.ToBriefResponse(),
                 courseSession.StartTime,
                 courseSession.EndTime,
                 courseSession.Day.ToArabicString()
            );
        }

    }
}
