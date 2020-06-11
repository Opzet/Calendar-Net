using System;
using System.Drawing;

namespace CalendarNet.Holidays.Common
{
    public class CommonHolidayCalendarEvent : ICalendarEvent
    {
        public Color EventBackgroundColor { get; set; }
        public string EventName { get; set; }
        public int Priority { get; set; }
        public bool IsAllDayEvent { get; set; }
        public Color EventTextColor { get; set; }
        public Font EventTextFont { get; set; }
        public bool UseHatchBackground { get; set; }
        public Color SecondaryHatchColor { get; set; }
        public int EventId { get; set; }
        public Bitmap Icon { get; set; }

        public CommonHolidayCalendarEvent()
        {
            Priority = 100000 - 1;
            EventBackgroundColor = Color.FromArgb(0xbb, 0xb0, 0xca);
            SecondaryHatchColor = Color.FromArgb(0xbb, 0xd0, 0xca);
            EventTextColor = Color.FromArgb(37, 37, 37);
            EventTextFont = new Font("Arial", 10, FontStyle.Bold);
            EventName = "";
            IsAllDayEvent = true;
            UseHatchBackground = true;
            Icon = null;
        }

        public virtual bool ShouldRenderMonth(DateTime date)
        {
            throw new NotImplementedException();
        }

        public virtual bool ShouldRenderDay(DateTime date)
        {
            throw new NotImplementedException();
        }

        public virtual DateTime EventStartDateTime(int month, int year)
        {
            throw new NotImplementedException();
        }

        public virtual DateTime EventEndDateTime(int month, int year)
        {
            throw new NotImplementedException();
        }

    }
}
