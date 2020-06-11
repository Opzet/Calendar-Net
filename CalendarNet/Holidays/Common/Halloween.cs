using System;

namespace CalendarNet.Holidays.Common
{
    public class Halloween : CommonHolidayCalendarEvent
    {
        public override bool ShouldRenderMonth(DateTime date)
        {
            return date.Month == 10 && date.Day == 31;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            return new DateTime(year, 10, 31, 0, 0, 0);
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public Halloween()
        {
            EventName = "Halloween";
            Icon = Utility.LoadImageFromEmbeddedResource("CalendarNet.Icons.pumpkin-icon.png");
        }
    }
}
