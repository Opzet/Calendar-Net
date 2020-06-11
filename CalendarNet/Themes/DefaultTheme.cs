using System.Drawing;

namespace CalendarNet.Themes
{
    public class DefaultTheme : ICalendarTheme
    {
        public string ThemeName { get; set; }
        public Color TodayButtonColor { get; set; }
        public Color TodayButtonBorderColor { get; set; }
        public Color TodayButtonTextColor { get; set; }
        public Color TodayButtonDisabledTextColor { get; set; }
        public Font TodayButtonFont { get; set; }
        public Color BackgroundColor { get; set; }
        public Color DayOfWeekColor { get; set; }
        public Color DaysTextColor { get; set; }
        public Color GridLinesColor { get; set; }
        public Color NavigationButtonsColor { get; set; }
        public Color NavigationButtonsTextColor { get; set; }
        public Color NavigationButtonsBorderColor { get; set; }
        public Font NavigationButtonsFont { get; set; }
        public Color DateTextColor { get; set; }
        public Font DateTextFont { get; set; }
        public Color WeekDaysBackgroundColor { get; set; }
        public Color WeekEndsBackgroundColor { get; set; }
        public Color GrayedOutDayTextColor { get; set; }
        public Font DaysFont { get; set; }
        public Color TodayButtonHoverColor { get; set; }
        public Color NavigationButtonsHoverColor { get; set; }
        
        public DefaultTheme()
        {
            ThemeName = "Default Theme";
            TodayButtonFont = new Font("Arial", 13, FontStyle.Bold);
            TodayButtonColor = Color.FromArgb(245, 245, 245);
            TodayButtonBorderColor = Color.FromArgb(197, 197, 197);
            TodayButtonDisabledTextColor = Color.FromArgb(184, 184, 184);
            TodayButtonTextColor = Color.FromArgb(68, 68, 68);
            TodayButtonHoverColor = Color.FromArgb(250, 250, 250);

            NavigationButtonsFont = new Font("Arial", 13, FontStyle.Bold);
            NavigationButtonsColor = Color.FromArgb(245, 245, 245);
            NavigationButtonsBorderColor = Color.FromArgb(197, 197, 197);
            NavigationButtonsTextColor = Color.FromArgb(68, 68, 68);
            NavigationButtonsHoverColor = Color.FromArgb(250, 250, 250);

            BackgroundColor = Color.White;
            DayOfWeekColor = Color.FromArgb(34, 34, 34);
            DaysTextColor = Color.FromArgb(80, 80, 155);
            DaysFont = new Font("Arial", 14, FontStyle.Bold);
            DateTextColor = Color.FromArgb(80, 80, 155);
            DateTextFont = new Font("Arial", 14, FontStyle.Bold);
            GrayedOutDayTextColor = Color.FromArgb(200, 200, 200);

            GridLinesColor = Color.FromArgb(200, 210, 255);

            WeekDaysBackgroundColor = Color.White;
            WeekEndsBackgroundColor = Color.FromArgb(240, 250, 255);
        }
    }
}
