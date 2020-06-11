using System.Drawing;

namespace CalendarNet.Themes
{
    public class DarkTheme : DefaultTheme
    {
        public DarkTheme()
        {
            ThemeName = "Dark Theme";
            TodayButtonFont = new Font("Consolas", 14, FontStyle.Bold);
            TodayButtonColor = Color.FromArgb(90, 90, 90);
            TodayButtonHoverColor = Color.FromArgb(115, 115, 115);
            TodayButtonBorderColor = Color.FromArgb(200, 200, 200);
            TodayButtonDisabledTextColor = Color.FromArgb(191, 191, 191);
            TodayButtonTextColor = Color.FromArgb(255, 255, 255);

            NavigationButtonsFont = new Font("Consolas", 14, FontStyle.Bold);
            NavigationButtonsColor = Color.FromArgb(90, 90, 90);
            NavigationButtonsBorderColor = Color.FromArgb(200, 200, 200);
            NavigationButtonsTextColor = Color.FromArgb(255, 255, 255);
            NavigationButtonsHoverColor = Color.FromArgb(115, 115, 115);

            BackgroundColor = Color.FromArgb(50, 50, 50);
            DayOfWeekColor = Color.FromArgb(180, 180, 255);
            DaysTextColor = Color.FromArgb(180, 180, 255);
            DaysFont = new Font("Consolas", 14, FontStyle.Bold);
            DateTextColor = Color.FromArgb(180, 180, 255);
            DateTextFont = new Font("Consolas", 14, FontStyle.Bold);
            GrayedOutDayTextColor = Color.FromArgb(100, 100, 100);

            GridLinesColor = Color.FromArgb(220, 220, 255);

            WeekDaysBackgroundColor = Color.FromArgb(60, 60, 60);
            WeekEndsBackgroundColor = Color.FromArgb(70, 70, 70);

        }
    }
}
