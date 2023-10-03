using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CalendarNet;

namespace CalendarNetDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            calendar1.Date = DateTime.Now;

            calendar1.ApplyTheme(new CalendarNet.Themes.DefaultTheme());
            //calendar1.ApplyTheme(new CalendarNet.Themes.BlueTheme());
           // calendar1.ApplyTheme(new CalendarNet.Themes.GreenTheme());
            //calendar1.ApplyTheme(new CalendarNet.Themes.DarkTheme());

            var ev = new MyEvent
            {
                EventName = "Test",
                EventBackgroundColor = Color.FromArgb(150, 80, 255),
                EventTextColor = Color.White,
                IsAllDayEvent = false,
                EventTextFont = new Font("Arial", 12, FontStyle.Bold),
                Icon = null
            };
            calendar1.AddEvent(ev);
        }

        private void calendar1_TodayButtonClicked(object sender, CalendarNet.CalendarNavigationTodayButtonClickedEventArgs e)
        {
            MessageBox.Show("Today!");
        }

        private void calendar1_DayClicked(object sender, CalendarNet.DayClickedEventArgs e)
        {
            //MessageBox.Show("Day Clicked : " + e.DateClicked.ToShortDateString());
        }

        private void calendar1_EventClicked(object sender, CalendarNet.EventClickedEventArgs e)
        {
            MessageBox.Show("Event clicked : " + e.CalendarEvent.EventName);
        }

        private void calendar1_DayDoubleClicked(object sender, CalendarNet.DayClickedEventArgs e)
        {
            MessageBox.Show("Day Double Clicked : " + e.DateClicked.ToShortDateString());
        }

        private void calendar1_EventDoubleClicked(object sender, CalendarNet.EventClickedEventArgs e)
        {
            MessageBox.Show("Event Double Clicked : " + e.CalendarEvent.EventName);
        }
    }

    public class MyEvent : ICalendarEvent
    {
        public int EventId { get; set; }
        public bool ShouldRenderMonth(DateTime date)
        {
            if (date.Month == 6 && date.Day == 9)
                return true;

            return false;
        }

        public bool ShouldRenderDay(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Color EventBackgroundColor { get; set; }
        public Color EventTextColor { get; set; }
        public string EventName { get; set; }
        public int Priority { get; set; }
        public Bitmap Icon { get; set; }
        public bool IsAllDayEvent { get; set; }
        public DateTime EventStartDateTime(int month, int year)
        {
            return new DateTime(year, 6, 9, 10, 30, 0);
        }

        public DateTime EventEndDateTime(int month, int year)
        {
            return new DateTime(year, 6, 9, 11, 30, 0);
        }


        public Font EventTextFont { get; set; }
        public bool UseHatchBackground { get; set; }
        public Color SecondaryHatchColor { get; set; }
        
    }
}
