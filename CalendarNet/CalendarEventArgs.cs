using System;
using System.Windows.Forms;

namespace CalendarNet
{
    public class CalendarNavigationButtonsClickedEventArgs : EventArgs
    {
        public DateTime PreviousDate { get; set; }
        public DateTime CurrentDate { get; set; }
        public bool WasHandled { get; set; }
    }

    public class CalendarNavigationTodayButtonClickedEventArgs : EventArgs
    {
        public bool IsDisabled { get; set; }
        public bool WasHandled { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime PreviousDate { get; set; }
    }

    public class DayClickedEventArgs : EventArgs
    {
        public DateTime CurrentDate { get; set; }
        public DateTime DateClicked { get; set; }
        public MouseButtons Button { get; set; }
    }

    public class EventClickedEventArgs : EventArgs
    {
        public DateTime CurrentDate { get; set; }
        public ICalendarEvent CalendarEvent { get; set; }
        public MouseButtons Button { get; set; }
    }
}
