using System;

namespace CalendarNet.Holidays.Federal
{
    public class VeteransDay : FederalHolidayCalendarEvent
    {
        public override bool ShouldRenderMonth(DateTime date)
        {
            return date.Month == 11 && date.Day == 11;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            return new DateTime(year, 11, 11, 0, 0, 0);
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public VeteransDay()
        {
            EventName = "Veterans Day";
        }
    }
}
