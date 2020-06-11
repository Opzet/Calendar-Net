﻿using System;

namespace CalendarNet.Holidays.Common
{
    public class ValentinesDay : CommonHolidayCalendarEvent
    {
        public override bool ShouldRenderMonth(DateTime date)
        {
            return date.Month == 2 && date.Day == 14;
        }

        public override DateTime EventStartDateTime(int month, int year)
        {
            return new DateTime(year, 2, 14, 0, 0, 0);
        }

        public override DateTime EventEndDateTime(int month, int year)
        {
            return IsAllDayEvent
                ? new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 11, 59, 59)
                : new DateTime(EventStartDateTime(month, year).Year, EventStartDateTime(month, year).Month,
                    EventStartDateTime(month, year).Day, 0, 0, 0);
        }

        public ValentinesDay()
        {
            EventName = "Valentine's Day";
            Icon = Utility.LoadImageFromEmbeddedResource("CalendarNet.Icons.heart.png");
        }
    }
}
