using System;

namespace CalendarNet.Holidays.Common
{
    public class AprilFoolsDay : CommonHolidayCalendarEvent
    {
        public override bool ShouldRenderMonth(DateTime date)
        {
            return date.Month == 4 && date.Day == 1;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            return new DateTime(year, 4, 1, 0, 0, 0);
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public AprilFoolsDay()
        {
            EventName = "April Fool's Day";
        }
    }
}
