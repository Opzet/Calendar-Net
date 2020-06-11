using System;

namespace CalendarNet.Holidays.Federal
{
    public class IndependenceDay : FederalHolidayCalendarEvent
    {
        public override bool ShouldRenderMonth(DateTime date)
        {
            return date.Month == 7 && date.Day == 4;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            return new DateTime(year, 7, 4, 0, 0, 0);
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public IndependenceDay()
        {
            EventName = "Independence Day";
            Icon = Utility.LoadImageFromEmbeddedResource("CalendarNet.Icons.us-flag.png");
        }
    }
}
