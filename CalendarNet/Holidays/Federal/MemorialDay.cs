using System;

namespace CalendarNet.Holidays.Federal
{
    public class MemorialDay : FederalHolidayCalendarEvent
    {
        // Last Monday in May
        public override bool ShouldRenderMonth(DateTime date)
        {
            if (date.Month != 5)
                return false;
            DateTime firstDay = new DateTime(date.Year, 6, 1);
            
            firstDay = firstDay.AddDays(-1);

            while (firstDay.DayOfWeek != DayOfWeek.Monday)
            {
                firstDay = firstDay.AddDays(-1);
            }

            if (firstDay.Year == date.Year && firstDay.Month == date.Month && firstDay.Day == date.Day)
                return true;

            return false;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            DateTime date = new DateTime(year, 5, 1);
            DateTime firstDay = new DateTime(date.Year, 6, 1);

            firstDay = firstDay.AddDays(-1);

            while (firstDay.DayOfWeek != DayOfWeek.Monday)
            {
                firstDay = firstDay.AddDays(-1);
            }

            if (firstDay.Year == date.Year && firstDay.Month == date.Month && firstDay.Day == date.Day)
                return new DateTime(year, 5, firstDay.Day, 0, 0, 0);

            return date;
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public MemorialDay()
        {
            EventName = "Memorial Day";
        }
    }
}
