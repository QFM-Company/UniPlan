using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class CourseSessionMapper
    {
        public static CourseSession ToCourseSession(this CreateCourseSessionRequest request, int courseSessionID = 0)
        {
            TimeSlot timeSlot = new TimeSlot();
            timeSlot.SlotID = request.TimeSlotID;
            CourseOffering courseOffering = new CourseOffering();
            courseOffering.OfferingID = request.CourseOfferingID;
            Hall hall = new Hall();
            hall.HallID = request.HallID;

            int adminID = request.CreatedByAdminID;

            return new CourseSession(
                courseSessionID,
                courseOffering,
                hall,
                timeSlot ,
                adminID
            );
        }

        public static void UpdateCourseSession(this CourseSession courseSession, UpdateCourseSessionRequest request)
        {
            courseSession.Hall = new Hall();
            courseSession.Hall.HallID = request.HallID;
            courseSession.CourseOffering = new CourseOffering();
            courseSession.CourseOffering.OfferingID = request.CourseOfferingID;
            courseSession.TimeSlot = new TimeSlot();
            courseSession.TimeSlot.SlotID = request.TimeSlotID;
        }

        public static CourseSessionResponse ToResponse(this CourseSession courseSession)
        {
            return new CourseSessionResponse(
                 courseSession.SessionID,
                 courseSession.CourseOffering!.ToResponse(),
                 courseSession.Hall!.ToResponse(),
                 courseSession.TimeSlot!.ToResponse(),
                 courseSession.CreatedByAdminID
            );
        }

    }
}
