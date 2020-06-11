using System;

namespace CalendarNet.Holidays.Common
{
    public class Easter : CommonHolidayCalendarEvent
    {
        public override bool ShouldRenderMonth(DateTime date)
        {
            int a = date.Year % 19;
            int b = date.Year / 100;
            int c = date.Year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int n = (h + l - 7 * m + 114) / 31;
            int p = (h + l - 7 * m + 114) % 31;

            if (date.Month == n && date.Day == p + 1)
                return true;

            return false;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            DateTime date = new DateTime(year, month, 1);

            int a = date.Year % 19;
            int b = date.Year / 100;
            int c = date.Year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int n = (h + l - 7 * m + 114) / 31;
            int p = (h + l - 7 * m + 114) % 31;

            return new DateTime(date.Year, n, p + 1, 0, 0, 0);
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public Easter()
        {
            EventName = "Easter Sunday";
        }
    }
}
