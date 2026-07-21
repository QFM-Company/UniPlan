using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class TimeSlotMapper
    {
        public static TimeSlotResponse? ToTimeSlot(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count == 0) return null;
            return new TimeSlotResponse(
                int.TryParse(row["معرف القطعة الزمنية"]?.ToString(), out var id) ? id : 0,
                Enum.TryParse(row["اليوم"]?.ToString(), out DayOfWeek day) ? day : DayOfWeek.Monday,
                new PeriodResponse(0, TimeSpan.Zero, TimeSpan.Zero)
            );
        }

        public static TimeSlotResponse ToTimeSlot(this BaseModel? model)
        {
            return model as TimeSlotResponse ?? new TimeSlotResponse(0, DayOfWeek.Monday, null);
        }
    }
}