using System;

namespace CalendarNet.Holidays.Common
{
    public class StPatricksDay : CommonHolidayCalendarEvent
    {
        public override bool ShouldRenderMonth(DateTime date)
        {
            return date.Month == 3 && date.Day == 17;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            return new DateTime(year, 3, 17, 0, 0, 0);
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public StPatricksDay()
        {
            EventName = "St. Patrick's Day";
            Icon = Utility.LoadImageFromEmbeddedResource("CalendarNet.Icons.shamrock-icon.png");
        }
    }
}
