using System;
using System.Drawing;

namespace CalendarNet
{
    public interface ICalendarEvent
    {
        int EventId { get; set; }
        bool ShouldRenderMonth(DateTime date);
        bool ShouldRenderDay(DateTime date);
        Color EventBackgroundColor { get; set; }
        Color EventTextColor { get; set; }
        string EventName { get; set; }
        int Priority { get; set; }
        bool IsAllDayEvent { get; set; }
        DateTime EventStartDateTime(int month, int year);
        DateTime EventEndDateTime(int month, int year);
        Font EventTextFont { get; set; }
        bool UseHatchBackground { get; set; }
        Color SecondaryHatchColor { get; set; }
        Bitmap Icon { get; set; }
    }
}
