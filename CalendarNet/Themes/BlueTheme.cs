using System.Drawing;

namespace CalendarNet.Themes
{
    public class BlueTheme : DefaultTheme
    {
        public BlueTheme()
        {
            ThemeName = "Blue Theme";
            TodayButtonFont = new Font("Consolas", 14, FontStyle.Bold);
            TodayButtonColor = Color.FromArgb(180, 200, 255);
            TodayButtonHoverColor = Color.FromArgb(150, 170, 225);
            TodayButtonBorderColor = Color.FromArgb(50, 50, 200);
            TodayButtonDisabledTextColor = Color.FromArgb(151, 151, 251);
            TodayButtonTextColor = Color.FromArgb(50, 50, 255);

            NavigationButtonsFont = new Font("Consolas", 14, FontStyle.Bold);
            NavigationButtonsColor = Color.FromArgb(180, 200, 255);
            NavigationButtonsBorderColor = Color.FromArgb(50, 50, 200);
            NavigationButtonsTextColor = Color.FromArgb(50, 50, 255);
            NavigationButtonsHoverColor = Color.FromArgb(150, 170, 225);

            BackgroundColor = Color.FromArgb(245, 245, 255);
            DayOfWeekColor = Color.FromArgb(80, 80, 255);
            DaysTextColor = Color.FromArgb(30, 130, 255);
            DaysFont = new Font("Consolas", 14, FontStyle.Bold);
            DateTextColor = Color.FromArgb(180, 180, 255);
            DateTextFont = new Font("Consolas", 14, FontStyle.Bold);
            GrayedOutDayTextColor = Color.FromArgb(51, 51, 90);

            GridLinesColor = Color.FromArgb(220, 220, 255);

            WeekDaysBackgroundColor = Color.FromArgb(60, 60, 160);
            WeekEndsBackgroundColor = Color.FromArgb(70, 70, 170);
        }
    }
}
