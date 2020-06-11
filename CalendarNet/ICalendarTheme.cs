using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CalendarNet
{
    public interface ICalendarTheme
    {
        string ThemeName { get; set; }
        Color TodayButtonColor { get; set; }
        Color TodayButtonBorderColor { get; set; }
        Color TodayButtonTextColor { get; set; }
        Color TodayButtonDisabledTextColor { get; set; }
        Color TodayButtonHoverColor { get; set; }
        Font TodayButtonFont { get; set; }
        Color BackgroundColor { get; set; }
        Color DayOfWeekColor { get; set; }
        Color DaysTextColor { get; set; }
        Color GridLinesColor { get; set; }
        Color NavigationButtonsColor { get; set; }
        Color NavigationButtonsTextColor { get; set; }
        Color NavigationButtonsBorderColor { get; set; }
        Color NavigationButtonsHoverColor { get; set; }
        Font NavigationButtonsFont { get; set; }
        Color DateTextColor { get; set; }
        Font DateTextFont { get; set; }
        Color WeekDaysBackgroundColor { get; set; }
        Color WeekEndsBackgroundColor { get; set; }
        Color GrayedOutDayTextColor { get; set; }
        Font DaysFont { get; set; }
    }
}
