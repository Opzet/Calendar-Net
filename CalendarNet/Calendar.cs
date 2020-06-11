using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalendarNet
{
    #region "Delegates"
    public delegate void PrevButtonClickedHandler(object sender, CalendarNavigationButtonsClickedEventArgs e);
    public delegate void NextButtonClickedHandler(object sender, CalendarNavigationButtonsClickedEventArgs e);
    public delegate void TodayButtonClickedHandler(object sender, CalendarNavigationTodayButtonClickedEventArgs e);
    public delegate void DayClickedHandler(object sender, DayClickedEventArgs e);
    public delegate void DayDoubleClickedHandler(object sender, DayClickedEventArgs e);
    public delegate void EventClickedHandler(object sender, EventClickedEventArgs e);
    public delegate void EventDoubleClickedHandler(object sender, EventClickedEventArgs e);
    #endregion

    public partial class Calendar : UserControl
    {
        #region "Constants"
        private const int XOffset = 0;
        private const int YOffset = 5;
        private const int NavMargin = 50;
        private const int SpacingBetweenEvents = 1;
        #endregion

        #region "Enumerations"
        public enum CalendarTypes
        {
            MonthView = 1,
            DayView = 2
        }

        public enum DayLocations
        {
            UpperLeft = 1,
            UpperRight = 2,
            LowerLeft = 3,
            LowerRight = 4,
            UpperMiddle = 5,
            LowerMiddle = 6
        }
        #endregion

        #region "Fields"
        private DateTime _date;
        private CalendarTypes _calendarType;
        private Padding _calendarMargin;
        private Color _gridLinesColor;
        private DayLocations _dayPosition;
        private Color _dayTextColor;
        private Color _grayedOutDayTextColor;
        private bool _showGrayedOutDays;
        private Font _dayTextFont;
        private Font _dayOfWeekTextFont;
        private string _dayOfWeekTextTemplate;
        private string _dateTemplate;
        private Color _dayOfWeekTextColor;
        private bool _showTodayButton;
        private Color _todayButtonColor;
        private Color _todayButtonBorderColor;
        private Color _todayButtonTextColor;
        private Color _todayButtonHoverColor;
        private Font _todayButtonFont;
        private Color _todayButtonDisabledTextColor;
        private bool _showNavigationButtons;
        private Color _navigationButtonsColor;
        private Color _navigationButtonsBorderColor;
        private Color _navigationButtonsTextColor;
        private Font _navigationButtonsFont;
        private Color _navigationButtonsHoverColor;
        private Font _dateTextFont;
        private Color _dateTextColor;
        private bool _showDate;
        private bool _handleDefaultNavigationClick;
        private int _maximumNumberOfEventsToShowInMonthView;
        private bool _showFederalHolidays;
        private bool _showCommonHolidays;
        private int _todayButtonWidth;
        private int _todayButtonHeight;
        private Color _weekDaysBackgroundColor;
        private Color _weekEndsBackgroundColor;
        private bool _todayButtonHovered;
        private bool _prevButtonHovered;
        private bool _nextButtonHovered;

        private readonly CalendarEvents _events;

        private bool _update;

        private readonly VScrollBar _vScroll;

        #endregion

        #region "Events"
        public event PrevButtonClickedHandler PreviousButtonClicked;
        public event NextButtonClickedHandler NextButtonClicked;
        public event TodayButtonClickedHandler TodayButtonClicked;
        public event DayClickedHandler DayClicked;
        public event DayDoubleClickedHandler DayDoubleClicked;
        public event EventClickedHandler EventClicked;
        public event EventDoubleClickedHandler EventDoubleClicked;
        #endregion

        #region "Properties"

        /// <summary>
        /// Gets or sets the color of the navigation buttons when the mouse is hovered over them.
        /// </summary>
        /// <value>The color of the navigation buttons when the mouse is hovered over them.</value>
        public Color NavigationButtonsHoverColor
        {
            get { return _navigationButtonsHoverColor; }
            set { _navigationButtonsHoverColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the week ends background.
        /// </summary>
        /// <value>The color of the week ends background.</value>
        public Color WeekEndsBackgroundColor
        {
            get { return _weekEndsBackgroundColor; }
            set { _weekEndsBackgroundColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the week days background.
        /// </summary>
        /// <value>The color of the week days background.</value>
        public Color WeekDaysBackgroundColor
        {
            get { return _weekDaysBackgroundColor; }
            set { _weekDaysBackgroundColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the height of the today button.
        /// </summary>
        /// <value>The height of the today button.</value>
        public int TodayButtonHeight
        {
            get { return _todayButtonHeight; }
            set { _todayButtonHeight = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the width of the today button.
        /// </summary>
        /// <value>The width of the today button.</value>
        public int TodayButtonWidth
        {
            get { return _todayButtonWidth; }
            set { _todayButtonWidth = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show federal holidays].
        /// </summary>
        /// <value><c>true</c> if [show federal holidays]; otherwise, <c>false</c>.</value>
        public bool ShowFederalHolidays
        {
            get { return _showFederalHolidays; }
            set { _showFederalHolidays = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show common holidays].
        /// </summary>
        /// <value><c>true</c> if [show common holidays]; otherwise, <c>false</c>.</value>
        public bool ShowCommonHolidays
        {
            get { return _showCommonHolidays; }
            set { _showCommonHolidays = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the maximum number of events to show in month view.
        /// </summary>
        /// <value>The maximum number of events to show in month view.</value>
        public int MaximumNumberOfEventsToShowInMonthView
        {
            get { return _maximumNumberOfEventsToShowInMonthView; }
            set { _maximumNumberOfEventsToShowInMonthView = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [handle default navigation click].
        /// </summary>
        /// <value><c>true</c> if [handle default navigation click]; otherwise, <c>false</c>.</value>
        public bool HandleDefaultNavigationClick
        {
            get { return _handleDefaultNavigationClick; }
            set { _handleDefaultNavigationClick = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the date text.
        /// </summary>
        /// <value>The color of the date text.</value>
        public Color DateTextColor
        {
            get { return _dateTextColor; }
            set { _dateTextColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show date].
        /// </summary>
        /// <value><c>true</c> if [show date]; otherwise, <c>false</c>.</value>
        public bool ShowDate
        {
            get { return _showDate; }
            set { _showDate = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the date text font.
        /// </summary>
        /// <value>The date text font.</value>
        public Font DateTextFont
        {
            get { return _dateTextFont; }
            set { _dateTextFont = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the date template.
        /// </summary>
        /// <value>The date template.</value>
        public string DateTemplate
        {
            get { return _dateTemplate; }
            set { _dateTemplate = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the navigation buttons font.
        /// </summary>
        /// <value>The navigation buttons font.</value>
        public Font NavigationButtonsFont
        {
            get { return _navigationButtonsFont; }
            set { _navigationButtonsFont = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the navigation buttons.
        /// </summary>
        /// <value>The color of the navigation buttons.</value>
        public Color NavigationButtonsColor
        {
            get { return _navigationButtonsColor; }
            set { _navigationButtonsColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the navigation buttons border.
        /// </summary>
        /// <value>The color of the navigation buttons border.</value>
        public Color NavigationButtonsBorderColor
        {
            get { return _navigationButtonsBorderColor; }
            set { _navigationButtonsBorderColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the navigation buttons text.
        /// </summary>
        /// <value>The color of the navigation buttons text.</value>
        public Color NavigationButtonsTextColor
        {
            get { return _navigationButtonsTextColor; }
            set { _navigationButtonsTextColor = value; Invalidate();}
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show navigation buttons].
        /// </summary>
        /// <value><c>true</c> if [show navigation buttons]; otherwise, <c>false</c>.</value>
        public bool ShowNavigationButtons
        {
            get { return _showNavigationButtons; }
            set { _showNavigationButtons = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the today button disabled text.
        /// </summary>
        /// <value>The color of the today button disabled text.</value>
        public Color TodayButtonDisabledTextColor
        {
            get { return _todayButtonDisabledTextColor; }
            set { _todayButtonDisabledTextColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the today button text.
        /// </summary>
        /// <value>The color of the today button text.</value>
        public Color TodayButtonTextColor
        {
            get { return _todayButtonTextColor; }
            set { _todayButtonTextColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the today button font.
        /// </summary>
        /// <value>The today button font.</value>
        public Font TodayButtonFont
        {
            get { return _todayButtonFont; }
            set { _todayButtonFont = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the today button when hovered over.
        /// </summary>
        /// <value>The color of the today button when hovered over.</value>
        public Color TodayButtonHoverColor
        {
            get { return _todayButtonHoverColor; }
            set { _todayButtonHoverColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the today button.
        /// </summary>
        /// <value>The color of the today button.</value>
        public Color TodayButtonColor
        {
            get { return _todayButtonColor; }
            set { _todayButtonColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the borer around the today button.
        /// </summary>
        /// <value>The color of the border around the today button</value>
        public Color TodayButtonBorderColor
        {
            get { return _todayButtonBorderColor; }
            set { _todayButtonBorderColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the today button].
        /// </summary>
        /// <value><c>true</c> if [show today button]; otherwise, <c>false</c>.</value>
        public bool ShowTodayButton
        {
            get { return _showTodayButton; }
            set { _showTodayButton = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the day of week text template.
        /// </summary>
        /// <value>The day of week text template.</value>
        public string DayOfWeekTextTemplate
        {
            get { return _dayOfWeekTextTemplate; }
            set { _dayOfWeekTextTemplate = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the day of week text.
        /// </summary>
        /// <value>The color of the day of week text.</value>
        public Color DayOfWeekTextColor
        {
            get { return _dayOfWeekTextColor; }
            set { _dayOfWeekTextColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the day of week text font.
        /// </summary>
        /// <value>The day text font.</value>
        public Font DayOfWeekTextFont
        {
            get { return _dayOfWeekTextFont; }
            set { _dayOfWeekTextFont = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the day text font.
        /// </summary>
        /// <value>The day text font.</value>
        public Font DayTextFont
        {
            get { return _dayTextFont; }
            set { _dayTextFont = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show grayed out days].
        /// </summary>
        /// <value><c>true</c> if you want to display grayed out days on the month calendar; otherwise, <c>false</c>.</value>
        public bool ShowGrayedOutDays
        {
            get { return _showGrayedOutDays; }
            set { _showGrayedOutDays = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the grayed out day text.
        /// </summary>
        /// <value>The color of the grayed out day text.</value>
        public Color GrayedOutDayTextColor
        {
            get { return _grayedOutDayTextColor; }
            set { _grayedOutDayTextColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the day text.
        /// </summary>
        /// <value>The color of the day text.</value>
        public Color DayTextColor
        {
            get { return _dayTextColor; }
            set { _dayTextColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the day position.
        /// </summary>
        /// <value>The day position.</value>
        public DayLocations DayPosition
        {
            get { return _dayPosition; }
            set { _dayPosition = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the grid lines.
        /// </summary>
        /// <value>The color of the grid lines.</value>
        public Color GridLinesColor
        {
            get { return _gridLinesColor; }
            set { _gridLinesColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the calendar margin.
        /// </summary>
        /// <value>The calendar margin.</value>
        public Padding CalendarMargin
        {
            get { return _calendarMargin; }
            set { _calendarMargin = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the type of the calendar.
        /// </summary>
        /// <value>The type of the calendar.</value>
        public CalendarTypes CalendarType
        {
            get { return _calendarType; }
            set { _calendarType = value; Invalidate(); }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Calendar"/> class.
        /// </summary>
        public Calendar()
        {
            InitializeComponent();

            _vScroll = new VScrollBar();
            Controls.Add(_vScroll);
            _update = true;

            _date = DateTime.Now;
            _calendarType = CalendarTypes.MonthView;
            _calendarMargin = new Padding(10);
            _gridLinesColor = Color.FromArgb(221, 221, 221);
            _weekDaysBackgroundColor = Color.Transparent;
            _weekEndsBackgroundColor = Color.Transparent;
            _dayPosition = DayLocations.UpperLeft;
            _dayTextColor = Color.FromArgb(34, 34, 34);
            _dateTextColor = Color.FromArgb(34, 34, 34);
            _grayedOutDayTextColor = Color.FromArgb(170, 170, 170);
            _showGrayedOutDays = true;
            _dayTextFont = new Font("Arial", 9, FontStyle.Regular);
            _dayOfWeekTextFont = new Font("Arial", 9, FontStyle.Regular);
            _dayOfWeekTextColor = Color.FromArgb(34, 34, 34);
            _dayOfWeekTextTemplate = "ddd";
            _dateTemplate = "MMMM yyyy";
            _showDate = true;
            _dateTextFont = new Font("Arial", 13, FontStyle.Regular);
            _showTodayButton = true;

            _todayButtonBorderColor = Color.FromArgb(197, 197, 197);
            _todayButtonColor = Color.FromArgb(245, 245, 245);
            _todayButtonFont = new Font("Arial", 13, FontStyle.Bold);
            _todayButtonTextColor = Color.FromArgb(68, 68, 68);
            _todayButtonDisabledTextColor = Color.FromArgb(184, 184, 184);
            _todayButtonWidth = 112;
            _todayButtonHeight = 29;

            _showNavigationButtons = true;
            _navigationButtonsColor = Color.FromArgb(245, 245, 245);
            _navigationButtonsBorderColor = Color.FromArgb(197, 197, 197);
            _navigationButtonsTextColor = Color.FromArgb(68, 68, 68);
            _navigationButtonsFont = new Font("Arial", 13, FontStyle.Bold);

            _handleDefaultNavigationClick = true;
            _showFederalHolidays = true;
            _showCommonHolidays = true;
            _maximumNumberOfEventsToShowInMonthView = 4;

            _events = new CalendarEvents();

            AddFederalHolidays();
            AddCommonHolidays();

            ApplyTheme(new Themes.DefaultTheme());

            _prevButtonHovered = false;
            _todayButtonHovered = false;
            _nextButtonHovered = false;
        }

        private void RemoveFederalHolidays()
        {
            _events.RemoveAll(z => z.ToString().StartsWith("CalendarNet.Holidays.Federal"));
        }

        private void AddFederalHolidays()
        {
            RemoveFederalHolidays();

            _events.Add(new Holidays.Federal.Christmas());
            _events.Add(new Holidays.Federal.Thanksgiving());
            _events.Add(new Holidays.Federal.NewYears());
            _events.Add(new Holidays.Federal.MartinLutherKing());
            _events.Add(new Holidays.Federal.PresidentsDay());
            _events.Add(new Holidays.Federal.MemorialDay());
            _events.Add(new Holidays.Federal.IndependenceDay());
            _events.Add(new Holidays.Federal.LaborDay());
            _events.Add(new Holidays.Federal.ColumbusDay());
            _events.Add(new Holidays.Federal.VeteransDay());
        }

        private void RemoveCommonHolidays()
        {
            _events.RemoveAll(z => z.ToString().StartsWith("CalendarNet.Holidays.Common"));
        }

        private void AddCommonHolidays()
        {
            RemoveCommonHolidays();

            _events.Add(new Holidays.Common.Halloween());
            _events.Add(new Holidays.Common.Easter());
            _events.Add(new Holidays.Common.MothersDay());

            _events.Add(new Holidays.Common.FathersDay());
            _events.Add(new Holidays.Common.GroundhogDay());
            
            _events.Add(new Holidays.Common.ValentinesDay());
            _events.Add(new Holidays.Common.SuperbowlSunday());
            _events.Add(new Holidays.Common.StPatricksDay());
            _events.Add(new Holidays.Common.AprilFoolsDay());
        }

        private void Calendar_Load(object sender, EventArgs e)
        {
            
        }

        private void RenderDayView(Graphics g)
        {
            int navMargin = new[] { _todayButtonHeight }.Max() + NavMargin;
            int scrollOffset = _vScroll.Value;

            _vScroll.Visible = true;
            _vScroll.Size = new Size(20, Math.Max(Height - navMargin - YOffset - _calendarMargin.Top - _calendarMargin.Bottom, navMargin + YOffset + _calendarMargin.Top + _calendarMargin.Bottom));
            _vScroll.Location = new Point(Width - _vScroll.Size.Width - 1, _calendarMargin.Top + navMargin + YOffset);

            if (_showTodayButton)
            {
                bool disabled = _date.Month == DateTime.Now.Month && _date.Year == DateTime.Now.Year;
                Brush todayBrush = new SolidBrush(disabled ? _todayButtonDisabledTextColor : TodayButtonTextColor);

                FillRoundedRect(g, new Rectangle(_calendarMargin.Left, _calendarMargin.Top, _todayButtonWidth, _todayButtonHeight), 5, new SolidBrush(_todayButtonHovered && !disabled ? _todayButtonHoverColor : _todayButtonColor));
                DrawRoundedRect(g, new Rectangle(_calendarMargin.Left, _calendarMargin.Top, _todayButtonWidth, _todayButtonHeight), 5, new Pen(_todayButtonBorderColor));

                SizeF sz = g.MeasureString("Today", _todayButtonFont);
                Point location = new Point((_todayButtonWidth - (int)sz.Width) / 2 + 1 + _calendarMargin.Left, (_todayButtonHeight - (int)sz.Height) / 2 + _calendarMargin.Top + 1);

                g.DrawString("Today", _todayButtonFont, todayBrush, location);
            }

            if (_showNavigationButtons)
            {
                FillRoundedRect(g, new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8, _calendarMargin.Top, 32, 29), 5, new SolidBrush(_prevButtonHovered ? _navigationButtonsHoverColor : _navigationButtonsColor));
                DrawRoundedRect(g, new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8, _calendarMargin.Top, 32, 29), 5, new Pen(_navigationButtonsBorderColor));

                FillRoundedRect(g, new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8 + 32, _calendarMargin.Top, 32, 29), 5, new SolidBrush(_nextButtonHovered ? _navigationButtonsHoverColor : _navigationButtonsColor));
                DrawRoundedRect(g, new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8 + 32, _calendarMargin.Top, 32, 29), 5, new Pen(_navigationButtonsBorderColor));

                SizeF szLeft = g.MeasureString("<", _navigationButtonsFont);
                SizeF szRight = g.MeasureString(">", _navigationButtonsFont);

                g.DrawString("<", _navigationButtonsFont, new SolidBrush(_navigationButtonsTextColor), new Point((32 - (int)szLeft.Width) / 2 + _calendarMargin.Left + _todayButtonWidth + 8, (29 - (int)szLeft.Height) / 2 + _calendarMargin.Top));
                g.DrawString(">", _navigationButtonsFont, new SolidBrush(_navigationButtonsTextColor), new Point((32 - (int)szRight.Width) / 2 + _calendarMargin.Left + _todayButtonWidth + 8 + 32, (29 - (int)szRight.Height) / 2 + _calendarMargin.Top));
            }

            for (int i = 0; i < 24; i++)
            {
                g.DrawRectangle(Pens.Black, new Rectangle(_calendarMargin.Left, _calendarMargin.Top + navMargin + YOffset + i*50, Width - _vScroll.Size.Width - _calendarMargin.Left - _calendarMargin.Right, 50));
            }
        }

        private void RenderMonthView(Graphics g)
        {
            int navMargin = new[] { _todayButtonHeight }.Max() + NavMargin;
            int totalHeight = Height - _calendarMargin.Top - _calendarMargin.Bottom - navMargin;
            int numberOfWeeks = GetWeeks(Date);
            int width = (Width - _calendarMargin.Left - _calendarMargin.Right) / 7;
            int height = totalHeight / numberOfWeeks - 1;
            Pen gridLinePen = new Pen(_gridLinesColor);

            _vScroll.Visible = false;

            for (int rows = 0; rows < numberOfWeeks; rows++)
            {
                for (int cols = 0; cols < 7; cols++)
                {
                    var rect = new Rectangle(cols * width + _calendarMargin.Left + XOffset, rows * height + _calendarMargin.Top + YOffset + navMargin, width, height);
                    var rect2 = new Rectangle(cols * width + _calendarMargin.Left + XOffset + 1, rows * height + _calendarMargin.Top + YOffset + navMargin + 1, width - 1, height - 1);
                    var weekDayBrush = new SolidBrush(_weekDaysBackgroundColor);
                    var weekEndBrush = new SolidBrush(_weekEndsBackgroundColor);

                    g.DrawRectangle(gridLinePen, rect);
                    g.FillRectangle(cols == 0 || cols == 6 ? weekEndBrush : weekDayBrush, rect2);
                }
            }

            DrawCalendarDays(g);

            DateTime firstSunday = new DateTime(Date.Year, Date.Month, 1);
            while (firstSunday.DayOfWeek != DayOfWeek.Sunday)
            {
                firstSunday = firstSunday.AddDays(1);
            }

            for (int i = 0; i < 7; i++)
            {
                string text = firstSunday.ToString(_dayOfWeekTextTemplate);
                SizeF sz = g.MeasureString(text, _dayOfWeekTextFont);

                Point location = new Point(i * width + _calendarMargin.Left + (width - (int)sz.Width) / 2 + XOffset, navMargin + _calendarMargin.Top - 10);

                g.DrawString(text, _dayOfWeekTextFont, new SolidBrush(_dayOfWeekTextColor), location);
                firstSunday = firstSunday.AddDays(1);
            }

            if (_showTodayButton)
            {
                bool disabled = _date.Month == DateTime.Now.Month && _date.Year == DateTime.Now.Year;
                Brush todayBrush = new SolidBrush(disabled ? _todayButtonDisabledTextColor : TodayButtonTextColor);

                FillRoundedRect(g, new Rectangle(_calendarMargin.Left, _calendarMargin.Top, _todayButtonWidth, _todayButtonHeight), 5, new SolidBrush(_todayButtonHovered && !disabled ? _todayButtonHoverColor : _todayButtonColor));
                DrawRoundedRect(g, new Rectangle(_calendarMargin.Left, _calendarMargin.Top, _todayButtonWidth, _todayButtonHeight), 5, new Pen(_todayButtonBorderColor));

                SizeF sz = g.MeasureString("Today", _todayButtonFont);
                Point location = new Point((_todayButtonWidth - (int)sz.Width) / 2 + 1 + _calendarMargin.Left, (_todayButtonHeight - (int)sz.Height) / 2 + _calendarMargin.Top + 1);

                g.DrawString("Today", _todayButtonFont, todayBrush, location);
            }

            if (_showNavigationButtons)
            {
                FillRoundedRect(g, new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8, _calendarMargin.Top, 32, 29), 5, new SolidBrush(_prevButtonHovered ? _navigationButtonsHoverColor : _navigationButtonsColor));
                DrawRoundedRect(g, new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8, _calendarMargin.Top, 32, 29), 5, new Pen(_navigationButtonsBorderColor));

                FillRoundedRect(g, new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8 + 32, _calendarMargin.Top, 32, 29), 5, new SolidBrush(_nextButtonHovered ? _navigationButtonsHoverColor : _navigationButtonsColor));
                DrawRoundedRect(g, new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8 + 32, _calendarMargin.Top, 32, 29), 5, new Pen(_navigationButtonsBorderColor));

                SizeF szLeft = g.MeasureString("<", _navigationButtonsFont);
                SizeF szRight = g.MeasureString(">", _navigationButtonsFont);

                g.DrawString("<", _navigationButtonsFont, new SolidBrush(_navigationButtonsTextColor), new Point((32 - (int)szLeft.Width) / 2 + _calendarMargin.Left + _todayButtonWidth + 8, (29 - (int)szLeft.Height) / 2 + _calendarMargin.Top));
                g.DrawString(">", _navigationButtonsFont, new SolidBrush(_navigationButtonsTextColor), new Point((32 - (int)szRight.Width) / 2 + _calendarMargin.Left + _todayButtonWidth + 8 + 32, (29 - (int)szRight.Height) / 2 + _calendarMargin.Top));
            }

            if (_showDate)
            {
                SizeF sz = g.MeasureString(Date.ToString(_dateTemplate), _dateTextFont);

                g.DrawString(Date.ToString(_dateTemplate), _dateTextFont, new SolidBrush(_dateTextColor), new Point(_calendarMargin.Left + _todayButtonWidth + 32 * 2 + 17, (29 - (int)sz.Height) / 2 + _calendarMargin.Top));
            }

            RenderMonthEvents(g);
        }

        private void Calendar_Paint(object sender, PaintEventArgs e)
        {
            if (!_update)
                return;

            if (Width < 1 || Height < 1)
                return;

            using (Bitmap bmp = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {

                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                    if (_calendarType == CalendarTypes.DayView)
                    {
                        RenderDayView(g);
                    }

                    if (_calendarType == CalendarTypes.MonthView)
                    {
                        RenderMonthView(g);
                    }

                    e.Graphics.DrawImage(bmp, new Point(0, 0));
                }
            }
        }

        private void RenderMonthEvents(Graphics g)
        {
            List<ICalendarEvent>[] events = new List<ICalendarEvent>[DateTime.DaysInMonth(Date.Year, Date.Month)];

            for (int i = 1; i <= DateTime.DaysInMonth(Date.Year, Date.Month); i++)
            {
                foreach (var ev in _events)
                {
                    if (ev.ShouldRenderMonth(new DateTime(Date.Year, Date.Month, i)))
                    {
                        if (events[i - 1] == null)
                        {
                            events[i - 1] = new List<ICalendarEvent>();
                        }
                        events[i - 1].Add(ev);
                    }
                }
            }

            int navMargin = new[] { _todayButtonHeight }.Max() + NavMargin;
            int totalHeight = Height - _calendarMargin.Top - _calendarMargin.Bottom - navMargin;
            int numberOfWeeks = GetWeeks(Date);
            int width = (Width - _calendarMargin.Left - _calendarMargin.Right) / 7;
            int height = totalHeight / numberOfWeeks - 1;

            int firstSquare = 0;
            DateTime firstDay = new DateTime(Date.Year, Date.Month, 1);

            switch (firstDay.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    firstSquare = 0;
                    break;
                case DayOfWeek.Monday:
                    firstSquare = 1;
                    break;
                case DayOfWeek.Tuesday:
                    firstSquare = 2;
                    break;
                case DayOfWeek.Wednesday:
                    firstSquare = 3;
                    break;
                case DayOfWeek.Thursday:
                    firstSquare = 4;
                    break;
                case DayOfWeek.Friday:
                    firstSquare = 5;
                    break;
                case DayOfWeek.Saturday:
                    firstSquare = 6;
                    break;
            }

            for (int rows = 0; rows < numberOfWeeks; rows++)
            {
                if (firstDay.Month != Date.Month || firstDay.Year != Date.Year)
                    continue;
                for (int cols = 0; cols < 7; cols++)
                {
                    if (firstDay.Month != Date.Month || firstDay.Year != Date.Year)
                        continue;
                    int ndx = 0;

                    if (cols < firstSquare && rows == 0)
                    {
                        continue;
                    }

                    if (events[firstDay.Day - 1] != null)
                    {
                        DateTime day = firstDay;
                        //var list = events[firstDay.Day - 1].OrderByDescending(z => z.Priority)
                        //    .ThenBy(z => z.IsAllDayEvent)
                        //    .ThenBy(z => z.EventDateTime(day.Month, day.Year))
                        //    .ThenBy(z => z.EventName)
                        //    .Take(_maximumNumberOfEventsToShowInMonthView)
                        //    .Where(z => z != null)
                        //    .Where(z => !(z.ToString().StartsWith("CalendarNet.Holidays.Federal") && !_showFederalHolidays))
                        //    .Where(z => !(z.ToString().StartsWith("CalendarNet.Holidays.Common") && !_showCommonHolidays))
                        //    .ToList();

                        foreach (ICalendarEvent evnt in events[firstDay.Day - 1].OrderByDescending(z => z.Priority)
                                .ThenBy(z => z.IsAllDayEvent)
                                .ThenBy(z => z.EventStartDateTime(day.Month, day.Year))
                                .ThenBy(z => z.EventName)
                                .Take(_maximumNumberOfEventsToShowInMonthView))
                        {
                            if (evnt == null || (evnt.ToString().StartsWith("CalendarNet.Holidays.Federal") && !_showFederalHolidays))
                                continue;

                            if (evnt.ToString().StartsWith("CalendarNet.Holidays.Common") && !_showCommonHolidays)
                                continue;

                            SizeF daySizeF = g.MeasureString(firstDay.Day.ToString(), _dayTextFont);

                            int height2 = rows*height + _calendarMargin.Top + YOffset + navMargin +
                                          (int) daySizeF.Height;

                            Rectangle r = new Rectangle(cols*width + _calendarMargin.Left + XOffset + 1,
                                (height2) + ndx * (height - (int)daySizeF.Height) / _maximumNumberOfEventsToShowInMonthView,
                                width - 1, 
                                height/_maximumNumberOfEventsToShowInMonthView - SpacingBetweenEvents * 3);

                            Bitmap bmp = null;
                            if (evnt.Icon != null)
                            {
                                bmp = Utility.ResizeBitmap(evnt.Icon, Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday ? WeekEndsBackgroundColor : WeekDaysBackgroundColor, new Size(r.Height, r.Height), false, true);
                            }

                            if (evnt.UseHatchBackground)
                                g.FillRectangle(new HatchBrush(HatchStyle.WideDownwardDiagonal, evnt.EventBackgroundColor, evnt.SecondaryHatchColor), r);
                            else g.FillRectangle(new SolidBrush(evnt.EventBackgroundColor), r);

                            try
                            {
                                Font f = FindFont(g, evnt.EventName, new Size(evnt.Icon == null ? r.Width : r.Width - bmp.Width, r.Height), evnt.EventTextFont);

                                g.DrawString(evnt.EventName, f, new SolidBrush(evnt.EventTextColor), evnt.Icon == null ? r.X : r.X + bmp.Width, r.Y);
                            }
                            catch { }

                            if (evnt.Icon != null)
                            {
                                g.DrawImage(bmp, new Point(r.X, r.Y));
                            }
                            ndx++;
                        }
                    }
                    firstDay = firstDay.AddDays(1);
                }
            }
        }

        private void HandleMouseEvents(MouseEventArgs e, bool doubleClick)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle today = new Rectangle(_calendarMargin.Left, _calendarMargin.Top, _todayButtonWidth, _todayButtonHeight);
                Rectangle leftNav = new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8, _calendarMargin.Top, 32, 39);
                Rectangle rightNav = new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8 + 32, _calendarMargin.Top, 32, 39);

                if (today.Contains(e.Location) && _showTodayButton)
                {
                    bool disabled = _date.Month == DateTime.Now.Month && _date.Year == DateTime.Now.Year;

                    if (TodayButtonClicked != null)
                    {
                        TodayButtonClicked(this, new CalendarNavigationTodayButtonClickedEventArgs
                        {
                            IsDisabled = disabled,
                            WasHandled = _handleDefaultNavigationClick,
                            CurrentDate = DateTime.Now,
                            PreviousDate = Date
                        });
                    }

                    if (_handleDefaultNavigationClick)
                        Date = DateTime.Now;
                }
                if (leftNav.Contains(e.Location) && _showNavigationButtons)
                {
                    if (_handleDefaultNavigationClick)
                        Date = Date.AddMonths(-1);

                    if (PreviousButtonClicked != null)
                    {
                        PreviousButtonClicked(this, new CalendarNavigationButtonsClickedEventArgs
                        {
                            CurrentDate = Date,
                            PreviousDate = Date.AddMonths(1),
                            WasHandled = _handleDefaultNavigationClick
                        });
                    }
                }
                if (rightNav.Contains(e.Location) && _showNavigationButtons)
                {
                    if (_handleDefaultNavigationClick)
                        Date = Date.AddMonths(1);

                    if (NextButtonClicked != null)
                    {
                        NextButtonClicked(this, new CalendarNavigationButtonsClickedEventArgs
                        {
                            CurrentDate = Date,
                            PreviousDate = Date.AddMonths(-1),
                            WasHandled = _handleDefaultNavigationClick
                        });
                    }
                }
            }

            int navMargin = new[] { _todayButtonHeight }.Max() + NavMargin;
            int totalHeight = Height - _calendarMargin.Top - _calendarMargin.Bottom - navMargin;
            int numberOfWeeks = GetWeeks(Date);
            int width = (Width - _calendarMargin.Left - _calendarMargin.Right) / 7;
            int height = totalHeight / numberOfWeeks - 1;

            int firstSquare = 0;
            DateTime firstDay = new DateTime(Date.Year, Date.Month, 1);

            switch (firstDay.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    firstSquare = 0;
                    break;
                case DayOfWeek.Monday:
                    firstSquare = 1;
                    break;
                case DayOfWeek.Tuesday:
                    firstSquare = 2;
                    break;
                case DayOfWeek.Wednesday:
                    firstSquare = 3;
                    break;
                case DayOfWeek.Thursday:
                    firstSquare = 4;
                    break;
                case DayOfWeek.Friday:
                    firstSquare = 5;
                    break;
                case DayOfWeek.Saturday:
                    firstSquare = 6;
                    break;
            }

            for (int rows = 0; rows < numberOfWeeks; rows++)
            {
                for (int cols = 0; cols < 7; cols++)
                {
                    Rectangle r = new Rectangle(cols * width + _calendarMargin.Left + XOffset, rows * height + _calendarMargin.Top + YOffset + navMargin, width, height);

                    if (r.Contains(e.Location) && cols < firstSquare && rows == 0)
                    {
                        if (DayClicked != null && !doubleClick)
                        {
                            DayClicked(this, new DayClickedEventArgs
                            {
                                CurrentDate = Date,
                                Button = e.Button,
                                DateClicked = firstDay.AddDays((firstSquare - cols)*-1)
                            });
                        }
                        if (DayDoubleClicked != null && doubleClick)
                        {
                            DayDoubleClicked(this, new DayClickedEventArgs
                            {
                                CurrentDate = Date,
                                Button = e.Button,
                                DateClicked = firstDay.AddDays((firstSquare - cols) * -1)
                            });
                        }
                    }

                    if (cols < firstSquare && rows == 0)
                    {
                        continue;
                    }

                    if (r.Contains(e.Location))
                    {
                        if (DayClicked != null && !doubleClick)
                        {
                            DayClicked(this, new DayClickedEventArgs
                            {
                                CurrentDate = Date,
                                Button = e.Button,
                                DateClicked = firstDay
                            });
                        }

                        if (DayDoubleClicked != null && doubleClick)
                        {
                            DayDoubleClicked(this, new DayClickedEventArgs
                            {
                                CurrentDate = Date,
                                Button = e.Button,
                                DateClicked = firstDay
                            });
                        }
                    }
                    firstDay = firstDay.AddDays(1);
                }
            }

            DetectEventClicks(e, doubleClick);
        }

        private void Calendar_MouseClick(object sender, MouseEventArgs e)
        {
            HandleMouseEvents(e, false);
        }

        private void Calendar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HandleMouseEvents(e, true);
        }

        private void Calendar_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle today = new Rectangle(_calendarMargin.Left, _calendarMargin.Top, _todayButtonWidth, _todayButtonHeight);
            Rectangle leftNav = new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8, _calendarMargin.Top, 32, 39);
            Rectangle rightNav = new Rectangle(_calendarMargin.Left + _todayButtonWidth + 8 + 32, _calendarMargin.Top, 32, 39);

            _todayButtonHovered = today.Contains(e.Location);
            _prevButtonHovered = leftNav.Contains(e.Location);
            _nextButtonHovered = rightNav.Contains(e.Location);
            Invalidate();
        }

        private void DetectEventClicks(MouseEventArgs e, bool doubleClicked)
        {
            if (EventClicked == null && !doubleClicked)
                return;

            if (EventDoubleClicked == null && doubleClicked)
                return;

            List<ICalendarEvent>[] events = new List<ICalendarEvent>[DateTime.DaysInMonth(Date.Year, Date.Month)];

            for (int i = 1; i <= DateTime.DaysInMonth(Date.Year, Date.Month); i++)
            {
                foreach (var ev in _events)
                {
                    if (ev.ShouldRenderMonth(new DateTime(Date.Year, Date.Month, i)))
                    {
                        if (events[i - 1] == null)
                        {
                            events[i - 1] = new List<ICalendarEvent>();
                        }
                        events[i - 1].Add(ev);
                    }
                }
            }

            int navMargin = new[] { _todayButtonHeight }.Max() + NavMargin;
            int totalHeight = Height - _calendarMargin.Top - _calendarMargin.Bottom - navMargin;
            int numberOfWeeks = GetWeeks(Date);
            int width = (Width - _calendarMargin.Left - _calendarMargin.Right) / 7;
            int height = totalHeight / numberOfWeeks - 1;

            int firstSquare = 0;
            DateTime firstDay = new DateTime(Date.Year, Date.Month, 1);

            switch (firstDay.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    firstSquare = 0;
                    break;
                case DayOfWeek.Monday:
                    firstSquare = 1;
                    break;
                case DayOfWeek.Tuesday:
                    firstSquare = 2;
                    break;
                case DayOfWeek.Wednesday:
                    firstSquare = 3;
                    break;
                case DayOfWeek.Thursday:
                    firstSquare = 4;
                    break;
                case DayOfWeek.Friday:
                    firstSquare = 5;
                    break;
                case DayOfWeek.Saturday:
                    firstSquare = 6;
                    break;
            }

            for (int rows = 0; rows < numberOfWeeks; rows++)
            {
                if (firstDay.Month != Date.Month || firstDay.Year != Date.Year)
                    continue;
                for (int cols = 0; cols < 7; cols++)
                {
                    if (firstDay.Month != Date.Month || firstDay.Year != Date.Year)
                        continue;
                    int ndx = 0;

                    if (cols < firstSquare && rows == 0)
                    {
                        continue;
                    }

                    if (events[firstDay.Day - 1] != null)
                    {
                        DateTime day = firstDay;
                        foreach (ICalendarEvent evnt in events[firstDay.Day - 1].OrderByDescending(z => z.Priority)
                            .ThenBy(z => z.IsAllDayEvent)
                            .ThenBy(z => z.EventStartDateTime(day.Month, day.Year))
                            .ThenBy(z => z.EventName)
                            .Take(_maximumNumberOfEventsToShowInMonthView))
                        {
                            if (evnt == null || (evnt.ToString().StartsWith("CalendarNet.Holidays.Federal") && !_showFederalHolidays))
                                continue;

                            if (evnt.ToString().StartsWith("CalendarNet.Holidays.Common") && !_showCommonHolidays)
                                continue;

                            Graphics g = CreateGraphics();
                            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                            SizeF daySizeF = g.MeasureString(firstDay.Day.ToString(), _dayTextFont);

                            int height2 = rows * height + _calendarMargin.Top + YOffset + navMargin +
                                          (int)daySizeF.Height;

                            Rectangle r = new Rectangle(cols * width + _calendarMargin.Left + XOffset + 1,
                                (height2) + ndx * (height - (int)daySizeF.Height) / _maximumNumberOfEventsToShowInMonthView,
                                width - 1,
                                height / _maximumNumberOfEventsToShowInMonthView - SpacingBetweenEvents * 3);

                            if (r.Contains(e.Location))
                            {
                                if (EventClicked != null && !doubleClicked)
                                {
                                    EventClicked(this, new EventClickedEventArgs
                                    {
                                        Button = e.Button,
                                        CalendarEvent = evnt,
                                        CurrentDate = Date
                                    });
                                }
                                if (EventDoubleClicked != null && doubleClicked)
                                {
                                    EventDoubleClicked(this, new EventClickedEventArgs
                                    {
                                        Button = e.Button,
                                        CalendarEvent = evnt,
                                        CurrentDate = Date
                                    });
                                }
                            }
                            ndx++;
                        }
                    }
                    firstDay = firstDay.AddDays(1);
                }
            }
        }

        private Font FindFont(Graphics g, string longString, Size room, Font preferedFont)
        {
            if (preferedFont == null)
            {
                preferedFont = new Font("Arial", 13, FontStyle.Regular);
            }
            SizeF realSize = g.MeasureString(longString, preferedFont);
            float heightScaleRatio = room.Height / realSize.Height;
            float widthScaleRatio = room.Width / realSize.Width;
            float scaleRatio = (heightScaleRatio < widthScaleRatio) ? heightScaleRatio : widthScaleRatio;
            float scaleFontSize = preferedFont.Size * scaleRatio;

            return scaleFontSize > preferedFont.Size
                ? new Font(preferedFont.FontFamily, preferedFont.Size, preferedFont.Style)
                : new Font(preferedFont.FontFamily, scaleFontSize, preferedFont.Style);
        }

        private void DrawRoundedRect(Graphics g, Rectangle bounds, int radius, Pen pen)
        {
            int diameter = radius*2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            using (GraphicsPath path = new GraphicsPath())
            {

                if (radius == 0)
                {
                    path.AddRectangle(bounds);
                    g.DrawPath(pen, path);
                    return;
                }

                path.AddArc(arc, 180, 90);

                arc.X = bounds.Right - diameter;
                path.AddArc(arc, 270, 90);

                arc.Y = bounds.Bottom - diameter;
                path.AddArc(arc, 0, 90);

                arc.X = bounds.Left;
                path.AddArc(arc, 90, 90);

                path.CloseFigure();

                g.DrawPath(pen, path);
            }
        }

        private void FillRoundedRect(Graphics g, Rectangle bounds, int radius, Brush brush)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            
            using (GraphicsPath path = new GraphicsPath())
            {

                if (radius == 0)
                {
                    path.AddRectangle(bounds);
                    g.FillPath(brush, path);
                    return;
                }

                path.AddArc(arc, 180, 90);

                arc.X = bounds.Right - diameter;
                path.AddArc(arc, 270, 90);

                arc.Y = bounds.Bottom - diameter;
                path.AddArc(arc, 0, 90);

                arc.X = bounds.Left;
                path.AddArc(arc, 90, 90);

                path.CloseFigure();

                g.FillPath(brush, path);
            }
        }

        private void DrawCalendarDays(Graphics g)
        {
            int navMargin = new[] { _todayButtonHeight }.Max() + NavMargin;
            int totalHeight = Height - _calendarMargin.Top - _calendarMargin.Bottom - navMargin;
            int numberOfWeeks = GetWeeks(Date);
            int width = (Width - _calendarMargin.Left - _calendarMargin.Right) / 7;
            int height = totalHeight / numberOfWeeks - 1;

            int firstSquare = 0;
            DateTime firstDay = new DateTime(Date.Year, Date.Month, 1);

            switch (firstDay.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    firstSquare = 0;
                    break;
                case DayOfWeek.Monday:
                    firstSquare = 1;
                    break;
                case DayOfWeek.Tuesday:
                    firstSquare = 2;
                    break;
                case DayOfWeek.Wednesday:
                    firstSquare = 3;
                    break;
                case DayOfWeek.Thursday:
                    firstSquare = 4;
                    break;
                case DayOfWeek.Friday:
                    firstSquare = 5;
                    break;
                case DayOfWeek.Saturday:
                    firstSquare = 6;
                    break;
            }

            Brush grayedOutDaysBrush = new SolidBrush(_grayedOutDayTextColor);
            Brush daysBrush = new SolidBrush(_dayTextColor);

            for (int rows = 0; rows < numberOfWeeks; rows++)
            {
                for (int cols = 0; cols < 7; cols++)
                {
                    Point location = new Point();
                    string text;

                    if (cols < firstSquare && rows == 0)
                    {
                        text = firstDay.AddDays((firstSquare - cols)*-1).Day.ToString();
                    }
                    else
                    {
                        text = firstDay.Day.ToString();
                    }

                    SizeF sizeF = g.MeasureString(text, _dayTextFont);

                    switch (_dayPosition)
                    {
                        case DayLocations.UpperLeft:
                            location = new Point(cols * width + _calendarMargin.Left + XOffset, rows * height + _calendarMargin.Top + YOffset + navMargin);
                            break;
                        case DayLocations.UpperRight:
                            location = new Point(cols * width + _calendarMargin.Left + width - (int)sizeF.Width + XOffset, rows * height + _calendarMargin.Top + YOffset + navMargin);
                            break;
                        case DayLocations.UpperMiddle:
                            location = new Point(cols * width + _calendarMargin.Left + (width - (int)sizeF.Width) / 2 + XOffset, rows * height + _calendarMargin.Top + YOffset + navMargin);
                            break;
                        case DayLocations.LowerLeft:
                            location = new Point(cols * width + _calendarMargin.Left + XOffset, rows * height + _calendarMargin.Top + height - (int)sizeF.Height + YOffset + navMargin);
                            break;
                        case DayLocations.LowerRight:
                            location = new Point(cols * width + _calendarMargin.Left + width - (int)sizeF.Width + XOffset, rows * height + _calendarMargin.Top + height - (int)sizeF.Height + YOffset + navMargin);
                            break;
                        case DayLocations.LowerMiddle:
                            location = new Point(cols * width + _calendarMargin.Left + (width - (int)sizeF.Width) / 2 + XOffset, rows * height + _calendarMargin.Top + height - (int)sizeF.Height + YOffset + navMargin);
                            break;
                    }
                    
                    if (cols < firstSquare && rows == 0)
                    {
                        if (_showGrayedOutDays)
                            g.DrawString(text, _dayTextFont, grayedOutDaysBrush, location);
                        continue;
                    }

                    if (firstDay.Month != Date.Month)
                    {
                        if (_showGrayedOutDays)
                            g.DrawString(text, _dayTextFont, grayedOutDaysBrush, location);
                    }
                    else
                    {
                        g.DrawString(text, _dayTextFont, daysBrush, location);
                    }
                    
                    firstDay = firstDay.AddDays(1);
                }
            }
        }

        private int GetWeeks(DateTime dt)
        {
            int newWeeks = 0;

            for (int i = 1; i <= DateTime.DaysInMonth(dt.Year, dt.Month); i++)
            {
                var dt2 = new DateTime(dt.Year, dt.Month, i);

                if (dt2.DayOfWeek == DayOfWeek.Sunday)
                    newWeeks++;
            }

            return new DateTime(dt.Year, dt.Month, 1).DayOfWeek == DayOfWeek.Sunday ? newWeeks : newWeeks + 1;
        }

        public void ApplyTheme(ICalendarTheme theme)
        {
            _update = false;

            BackColor = theme.BackgroundColor;
            _gridLinesColor = theme.GridLinesColor;
            _dateTextColor = theme.DateTextColor;
            _dateTextFont = theme.DateTextFont;
            
            _todayButtonFont = theme.TodayButtonFont;
            _todayButtonColor = theme.TodayButtonColor;
            _todayButtonHoverColor = theme.TodayButtonHoverColor;
            _todayButtonBorderColor = theme.TodayButtonBorderColor;
            _todayButtonDisabledTextColor = theme.TodayButtonDisabledTextColor;
            _todayButtonTextColor = theme.TodayButtonTextColor;

            _navigationButtonsFont = theme.NavigationButtonsFont;
            _navigationButtonsColor = theme.NavigationButtonsColor;
            _navigationButtonsTextColor = theme.NavigationButtonsTextColor;
            _navigationButtonsBorderColor = theme.NavigationButtonsBorderColor;
            _navigationButtonsHoverColor = theme.NavigationButtonsHoverColor;

            _dayOfWeekTextColor = theme.DayOfWeekColor;
            _dayTextColor = theme.DaysTextColor;
            _dayTextFont = theme.DaysFont;
            _weekDaysBackgroundColor = theme.WeekDaysBackgroundColor;
            _weekEndsBackgroundColor = theme.WeekEndsBackgroundColor;
            _grayedOutDayTextColor = theme.GrayedOutDayTextColor;

            _update = true;
            Invalidate();
        }

        public int AddEvent(ICalendarEvent @event, int id)
        {
            return _events.Add(@event, id);
        }

        public int AddEvent(ICalendarEvent @event)
        {
            return _events.Add(@event);
        }

        public void RemoveEvent(int id)
        {
            _events.RemoveByEventId(id);
        }

        public void RemoveEvent(ICalendarEvent @event)
        {
            RemoveEvent(@event.EventId);
        }
    }
}
