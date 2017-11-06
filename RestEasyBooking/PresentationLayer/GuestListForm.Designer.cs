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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuestListForm));
            this.guestDataGridView = new System.Windows.Forms.DataGridView();
            this.restEasyBookingDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.restEasyBookingDataSet = new RestEasyBooking.RestEasyBookingDataSet();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guestDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restEasyBookingDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restEasyBookingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guestDataGridView
            // 
            this.guestDataGridView.AllowUserToAddRows = false;
            this.guestDataGridView.AllowUserToDeleteRows = false;
            this.guestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guestDataGridView.Location = new System.Drawing.Point(25, 70);
            this.guestDataGridView.Name = "guestDataGridView";
            this.guestDataGridView.ReadOnly = true;
            this.guestDataGridView.Size = new System.Drawing.Size(763, 190);
            this.guestDataGridView.TabIndex = 0;
            // 
            // restEasyBookingDataSetBindingSource
            // 
            this.restEasyBookingDataSetBindingSource.DataSource = this.restEasyBookingDataSet;
            this.restEasyBookingDataSetBindingSource.Position = 0;
            // 
            // restEasyBookingDataSet
            // 
            this.restEasyBookingDataSet.DataSetName = "RestEasyBookingDataSet";
            this.restEasyBookingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(340, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "RestEasy";
            // 
            // GuestListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 303);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.guestDataGridView);
            this.Name = "GuestListForm";
            this.Text = "GuestListForm";
            ((System.ComponentModel.ISupportInitialize)(this.guestDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restEasyBookingDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restEasyBookingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView guestDataGridView;
        private System.Windows.Forms.BindingSource restEasyBookingDataSetBindingSource;
        private RestEasyBookingDataSet restEasyBookingDataSet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
    }
}