using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class TimeSlotMapper
    {
        public static TimeSlotResponse? ToTimeSlot(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count <= 1) 
                return null;

            return new TimeSlotResponse(
                int.TryParse(row["معرف القطعة الزمنية"]?.ToString(), out var id) ? id : 0,
                row["اليوم"]?.ToString() ?? "الأحد",
                row.ToPeriod()
            );

        }

        public static TimeSlotResponse ToTimeSlot(this Person? model)
        {
            return model as TimeSlotResponse ?? new TimeSlotResponse(0, "الأحد", null);
        }
    }
}