namespace CalendarNetDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.calendar1 = new CalendarNet.Calendar();
            this.calendar2 = new CalendarNet.Calendar();
            this.SuspendLayout();
            // 
            // calendar1
            // 
            this.calendar1.BackColor = System.Drawing.Color.White;
            this.calendar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendar1.CalendarMargin = new System.Windows.Forms.Padding(10);
            this.calendar1.CalendarType = CalendarNet.Calendar.CalendarTypes.MonthView;
            this.calendar1.Date = new System.DateTime(2016, 6, 24, 15, 25, 14, 405);
            this.calendar1.DateTemplate = "MMMM yyyy";
            this.calendar1.DateTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(155)))));
            this.calendar1.DateTextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.calendar1.DayOfWeekTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.calendar1.DayOfWeekTextFont = new System.Drawing.Font("Arial", 9F);
            this.calendar1.DayOfWeekTextTemplate = "ddd";
            this.calendar1.DayPosition = CalendarNet.Calendar.DayLocations.UpperLeft;
            this.calendar1.DayTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(155)))));
            this.calendar1.DayTextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.calendar1.GrayedOutDayTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.calendar1.GridLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.calendar1.HandleDefaultNavigationClick = true;
            this.calendar1.Location = new System.Drawing.Point(2, 5);
            this.calendar1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.calendar1.MaximumNumberOfEventsToShowInMonthView = 4;
            this.calendar1.Name = "calendar1";
            this.calendar1.NavigationButtonsBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.calendar1.NavigationButtonsColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.calendar1.NavigationButtonsFont = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.calendar1.NavigationButtonsHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.calendar1.NavigationButtonsTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.calendar1.ShowCommonHolidays = true;
            this.calendar1.ShowDate = true;
            this.calendar1.ShowFederalHolidays = false;
            this.calendar1.ShowGrayedOutDays = true;
            this.calendar1.ShowNavigationButtons = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(646, 591);
            this.calendar1.TabIndex = 0;
            this.calendar1.TodayButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.calendar1.TodayButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.calendar1.TodayButtonDisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.calendar1.TodayButtonFont = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.calendar1.TodayButtonHeight = 29;
            this.calendar1.TodayButtonHoverColor = System.Drawing.Color.Empty;
            this.calendar1.TodayButtonTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.calendar1.TodayButtonWidth = 152;
            this.calendar1.WeekDaysBackgroundColor = System.Drawing.Color.White;
            this.calendar1.WeekEndsBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.calendar1.TodayButtonClicked += new CalendarNet.TodayButtonClickedHandler(this.calendar1_TodayButtonClicked);
            this.calendar1.DayClicked += new CalendarNet.DayClickedHandler(this.calendar1_DayClicked);
            this.calendar1.DayDoubleClicked += new CalendarNet.DayDoubleClickedHandler(this.calendar1_DayDoubleClicked);
            this.calendar1.EventClicked += new CalendarNet.EventClickedHandler(this.calendar1_EventClicked);
            this.calendar1.EventDoubleClicked += new CalendarNet.EventDoubleClickedHandler(this.calendar1_EventDoubleClicked);
            // 
            // calendar2
            // 
            this.calendar2.BackColor = System.Drawing.Color.White;
            this.calendar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendar2.CalendarMargin = new System.Windows.Forms.Padding(10);
            this.calendar2.CalendarType = CalendarNet.Calendar.CalendarTypes.DayView;
            this.calendar2.Date = new System.DateTime(2016, 6, 24, 15, 25, 14, 405);
            this.calendar2.DateTemplate = "MMMM yyyy";
            this.calendar2.DateTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(155)))));
            this.calendar2.DateTextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.calendar2.DayOfWeekTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.calendar2.DayOfWeekTextFont = new System.Drawing.Font("Arial", 9F);
            this.calendar2.DayOfWeekTextTemplate = "ddd";
            this.calendar2.DayPosition = CalendarNet.Calendar.DayLocations.UpperLeft;
            this.calendar2.DayTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(155)))));
            this.calendar2.DayTextFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.calendar2.GrayedOutDayTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.calendar2.GridLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.calendar2.HandleDefaultNavigationClick = true;
            this.calendar2.Location = new System.Drawing.Point(759, 5);
            this.calendar2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.calendar2.MaximumNumberOfEventsToShowInMonthView = 4;
            this.calendar2.Name = "calendar2";
            this.calendar2.NavigationButtonsBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.calendar2.NavigationButtonsColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.calendar2.NavigationButtonsFont = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.calendar2.NavigationButtonsHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.calendar2.NavigationButtonsTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.calendar2.ShowCommonHolidays = true;
            this.calendar2.ShowDate = true;
            this.calendar2.ShowFederalHolidays = false;
            this.calendar2.ShowGrayedOutDays = true;
            this.calendar2.ShowNavigationButtons = true;
            this.calendar2.ShowTodayButton = true;
            this.calendar2.Size = new System.Drawing.Size(646, 591);
            this.calendar2.TabIndex = 1;
            this.calendar2.TodayButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.calendar2.TodayButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.calendar2.TodayButtonDisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.calendar2.TodayButtonFont = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.calendar2.TodayButtonHeight = 29;
            this.calendar2.TodayButtonHoverColor = System.Drawing.Color.Empty;
            this.calendar2.TodayButtonTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.calendar2.TodayButtonWidth = 152;
            this.calendar2.WeekDaysBackgroundColor = System.Drawing.Color.White;
            this.calendar2.WeekEndsBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1576, 1088);
            this.Controls.Add(this.calendar2);
            this.Controls.Add(this.calendar1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CalendarNet.Calendar calendar1;
        private CalendarNet.Calendar calendar2;
    }
}