using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;
using Core.Enums;
using Core.Extensions;

namespace Business.Mapper
{
    public static class TimeSlotMapper
    {
        public static TimeSlot ToTimeSlot(this TimeSlotRequest request, int timeSlotID = -1)
        {
            return new TimeSlot(timeSlotID, (DayOfWeek)request.Day, new Period(request.PeriodID, TimeSpan.Zero, TimeSpan.Zero));
        }

        public static void UpdatePeriod(this TimeSlot timeSlot, TimeSlotRequest request)
        {
            timeSlot.Day = (DayOfWeek)request.Day;
            timeSlot!.Period!.PeriodID = request.PeriodID;
        }

        public static TimeSlotResponse ToResponse(this TimeSlot timeSlot)
        {
            return new TimeSlotResponse(timeSlot.SlotID, timeSlot.Day.ToArabicString(), timeSlot.Period?.ToResponse());
        }

    }
}
