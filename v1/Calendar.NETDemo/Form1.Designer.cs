namespace Calendar.NETDemo
{
    partial class Form1
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
            this.calendar1 = new Calendar.NET.Calendar();
            this.calendar2 = new Calendar.NET.Calendar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calendar1
            // 
            this.calendar1.AllowEditingEvents = false;
            this.calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendar1.BackColor = System.Drawing.Color.Transparent;
            this.calendar1.CalendarDate = new System.DateTime(2012, 4, 24, 13, 16, 0, 0);
            this.calendar1.CalendarView = Calendar.NET.CalendarViews.Month;
            this.calendar1.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendar1.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar1.DimDisabledEvents = true;
            this.calendar1.HighlightCurrentDay = true;
            this.calendar1.LoadPresetHolidays = true;
            this.calendar1.Location = new System.Drawing.Point(18, 18);
            this.calendar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calendar1.Name = "calendar1";
            this.calendar1.ShowArrowControls = true;
            this.calendar1.ShowDashedBorderOnDisabledEvents = true;
            this.calendar1.ShowDateInHeader = true;
            this.calendar1.ShowDisabledEvents = false;
            this.calendar1.ShowEventTooltips = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(816, 638);
            this.calendar1.TabIndex = 0;
            this.calendar1.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // calendar2
            // 
            this.calendar2.AllowEditingEvents = false;
            this.calendar2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendar2.BackColor = System.Drawing.Color.Transparent;
            this.calendar2.CalendarDate = new System.DateTime(2012, 4, 24, 13, 16, 0, 0);
            this.calendar2.CalendarView = Calendar.NET.CalendarViews.Day;
            this.calendar2.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendar2.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.calendar2.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.calendar2.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar2.DimDisabledEvents = true;
            this.calendar2.HighlightCurrentDay = true;
            this.calendar2.LoadPresetHolidays = true;
            this.calendar2.Location = new System.Drawing.Point(913, 18);
            this.calendar2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calendar2.Name = "calendar2";
            this.calendar2.ShowArrowControls = true;
            this.calendar2.ShowDashedBorderOnDisabledEvents = true;
            this.calendar2.ShowDateInHeader = true;
            this.calendar2.ShowDisabledEvents = false;
            this.calendar2.ShowEventTooltips = true;
            this.calendar2.ShowTodayButton = true;
            this.calendar2.Size = new System.Drawing.Size(378, 638);
            this.calendar2.TabIndex = 1;
            this.calendar2.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 728);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "https://www.codeproject.com/articles/378900/calendar-net";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2185, 899);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calendar2);
            this.Controls.Add(this.calendar1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NET.Calendar calendar1;
        private NET.Calendar calendar2;
        private System.Windows.Forms.Label label1;
    }
}

