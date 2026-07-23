using Client.Models;
using Client.Models.Responses;
using System.Data;

namespace ViewModels.Extensions
{
    public static class PeriodMapper
    {
        public static PeriodResponse? ToPeriod(this DataRowView row)
        {
            if (row.Row.Table.Columns.Count <= 1)
                return null;

            return new PeriodResponse(
                int.TryParse(row["معرف الفترة"]?.ToString(), out var id) ? id : 0,
                TimeSpan.TryParse(row["وقت البداية"]?.ToString(), out var st) ? st : TimeSpan.Zero,
                TimeSpan.TryParse(row["وقت النهاية"]?.ToString(), out var et) ? et : TimeSpan.Zero
            );
        }

        public static PeriodResponse ToPeriod(this Person? model)
        {
            return model as PeriodResponse ?? new PeriodResponse(0, TimeSpan.Zero, TimeSpan.Zero);
        }
    }
}