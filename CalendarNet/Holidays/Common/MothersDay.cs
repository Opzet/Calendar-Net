using System;

namespace CalendarNet.Holidays.Common
{
    public class MothersDay : CommonHolidayCalendarEvent
    {
        // Third Monday in Feburary
        public override bool ShouldRenderMonth(DateTime date)
        {
            if (date.Month != 5)
                return false;
            DateTime firstDay = new DateTime(date.Year, date.Month, 1);
            int count = 0;

            while (firstDay.Month == date.Month && firstDay.Year == date.Year)
            {
                if (firstDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                    if (count == 2 && firstDay.Month == date.Month && firstDay.Year == date.Year && firstDay.Day == date.Day)
                        return true;
                }
                firstDay = firstDay.AddDays(1);
            }
            return false;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            DateTime date = new DateTime(year, 5, 1);

            DateTime firstDay = new DateTime(date.Year, date.Month, 1);
            int count = 0;

            while (firstDay.Month == date.Month && firstDay.Year == date.Year)
            {
                if (firstDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                    if (count == 2 && firstDay.Month == date.Month && firstDay.Year == date.Year && firstDay.Day == date.Day)
                        return new DateTime(year, 5, firstDay.Day, 0, 0, 0);
                }
                firstDay = firstDay.AddDays(1);
            }

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

        public MothersDay()
        {
            EventName = "Mother's Day";
        }
    }
}
