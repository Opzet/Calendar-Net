using System;

namespace CalendarNet.Holidays.Federal
{
    public class NewYears : FederalHolidayCalendarEvent
    {
        public override bool ShouldRenderMonth(DateTime date)
        {
            return date.Month == 1 && date.Day == 1;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            return new DateTime(year, 1, 1, 0, 0, 0);
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public NewYears()
        {
            EventName = "New Year's Day";
        }
    }
}
