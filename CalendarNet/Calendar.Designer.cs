namespace CalendarNet
{
    partial class Calendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.Name = "Calendar";
            this.Load += new System.EventHandler(this.Calendar_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Calendar_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Calendar_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Calendar_MouseDoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Calendar_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
