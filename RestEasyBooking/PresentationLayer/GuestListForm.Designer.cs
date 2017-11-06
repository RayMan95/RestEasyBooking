namespace RestEasyBooking.PresentationLayer
{
    partial class GuestListForm
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
            this.guestListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // guestListView
            // 
            this.guestListView.Location = new System.Drawing.Point(13, 36);
            this.guestListView.Name = "guestListView";
            this.guestListView.Size = new System.Drawing.Size(221, 97);
            this.guestListView.TabIndex = 0;
            this.guestListView.UseCompatibleStateImageBehavior = false;
            // 
            // GuestListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.guestListView);
            this.Name = "GuestListForm";
            this.Text = "GuestListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView guestListView;
    }
}