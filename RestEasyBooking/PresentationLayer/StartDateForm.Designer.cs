namespace RestEasyBooking.PresentationLayer
{
    partial class StartDateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartDateForm));
            this.startdateCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.numberofroomslabel = new System.Windows.Forms.Label();
            this.confirmbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startdateCalendar
            // 
            this.startdateCalendar.Location = new System.Drawing.Point(128, 45);
            this.startdateCalendar.Margin = new System.Windows.Forms.Padding(7);
            this.startdateCalendar.MaxDate = new System.DateTime(2017, 12, 31, 0, 0, 0, 0);
            this.startdateCalendar.MinDate = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.startdateCalendar.Name = "startdateCalendar";
            this.startdateCalendar.TabIndex = 1;
            this.startdateCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.startdateCalendar_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number Of Rooms Available";
            // 
            // numberofroomslabel
            // 
            this.numberofroomslabel.AutoSize = true;
            this.numberofroomslabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberofroomslabel.Location = new System.Drawing.Point(253, 236);
            this.numberofroomslabel.Name = "numberofroomslabel";
            this.numberofroomslabel.Size = new System.Drawing.Size(0, 18);
            this.numberofroomslabel.TabIndex = 3;
            // 
            // confirmbutton
            // 
            this.confirmbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("confirmbutton.BackgroundImage")));
            this.confirmbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.confirmbutton.Location = new System.Drawing.Point(178, 286);
            this.confirmbutton.Name = "confirmbutton";
            this.confirmbutton.Size = new System.Drawing.Size(104, 55);
            this.confirmbutton.TabIndex = 4;
            this.confirmbutton.UseVisualStyleBackColor = true;
            this.confirmbutton.Click += new System.EventHandler(this.confirmbutton_Click);
            // 
            // StartDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 353);
            this.Controls.Add(this.confirmbutton);
            this.Controls.Add(this.numberofroomslabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startdateCalendar);
            this.Name = "StartDateForm";
            this.Text = "Start Date";
            this.Load += new System.EventHandler(this.StartDateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar startdateCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numberofroomslabel;
        private System.Windows.Forms.Button confirmbutton;
    }
}