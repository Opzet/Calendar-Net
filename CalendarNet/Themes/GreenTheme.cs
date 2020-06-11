using System.Drawing;

namespace CalendarNet.Themes
{
    public class GreenTheme : DefaultTheme
    {
        public GreenTheme()
        {
            ThemeName = "Green Theme";
            TodayButtonFont = new Font("Consolas", 14, FontStyle.Bold);
            TodayButtonColor = Color.FromArgb(180, 255, 200);
            TodayButtonHoverColor = Color.FromArgb(150, 225, 170);
            TodayButtonBorderColor = Color.FromArgb(50, 200, 50);
            TodayButtonDisabledTextColor = Color.FromArgb(141, 241, 141);
            TodayButtonTextColor = Color.FromArgb(50, 155, 50);

            NavigationButtonsFont = new Font("Consolas", 14, FontStyle.Bold);
            NavigationButtonsColor = Color.FromArgb(180, 255, 200);
            NavigationButtonsBorderColor = Color.FromArgb(50, 200, 50);
            NavigationButtonsTextColor = Color.FromArgb(50, 155, 50);
            NavigationButtonsHoverColor = Color.FromArgb(150, 225, 170);

            BackgroundColor = Color.FromArgb(235, 255, 235);
            DayOfWeekColor = Color.FromArgb(80, 155, 80);
            DaysTextColor = Color.FromArgb(80, 100, 80);
            DaysFont = new Font("Consolas", 14, FontStyle.Bold);
            DateTextColor = Color.FromArgb(120, 195, 120);
            DateTextFont = new Font("Consolas", 14, FontStyle.Bold);
            GrayedOutDayTextColor = Color.FromArgb(150, 170, 150);

            GridLinesColor = Color.FromArgb(50, 150, 50);

            WeekDaysBackgroundColor = Color.FromArgb(120, 220, 120);
            WeekEndsBackgroundColor = Color.FromArgb(130, 230, 130);
        }
    }
}
