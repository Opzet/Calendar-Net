using System;

namespace CalendarNet.Holidays.Federal
{
    public class Christmas : FederalHolidayCalendarEvent
    {
        public override bool ShouldRenderMonth(DateTime date)
        {
            return date.Month == 12 && date.Day == 25;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            return new DateTime(year, 12, 25, 0, 0, 0);
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public Christmas()
        {
            EventName = "Christmas Day";
            Icon = Utility.LoadImageFromEmbeddedResource("CalendarNet.Icons.christmas-tree-icon.png");
        }
    }
}
