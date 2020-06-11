using System;
using System.Drawing;

namespace CalendarNet.Holidays.Federal
{
    public class FederalHolidayCalendarEvent : ICalendarEvent
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

        public FederalHolidayCalendarEvent()
        {
            Priority = 100000;
            EventBackgroundColor = Color.FromArgb(0xff, 0xc0, 0xcb);
            SecondaryHatchColor = Color.FromArgb(0xff, 0xe0, 0xeb);
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
