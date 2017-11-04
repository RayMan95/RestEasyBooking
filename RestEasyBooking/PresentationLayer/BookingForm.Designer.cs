namespace RestEasyBooking.PresentationLayer
{
    partial class BookingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pricetextBox = new System.Windows.Forms.TextBox();
            this.guestaccounttextBox = new System.Windows.Forms.TextBox();
            this.addbookingbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.startdatebutton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Guest Account No";
            // 
            // pricetextBox
            // 
            this.pricetextBox.Location = new System.Drawing.Point(187, 159);
            this.pricetextBox.Name = "pricetextBox";
            this.pricetextBox.Size = new System.Drawing.Size(181, 20);
            this.pricetextBox.TabIndex = 4;
            // 
            // guestaccounttextBox
            // 
            this.guestaccounttextBox.Location = new System.Drawing.Point(187, 211);
            this.guestaccounttextBox.Name = "guestaccounttextBox";
            this.guestaccounttextBox.Size = new System.Drawing.Size(181, 20);
            this.guestaccounttextBox.TabIndex = 5;
            // 
            // addbookingbutton
            // 
            this.addbookingbutton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbookingbutton.Location = new System.Drawing.Point(39, 292);
            this.addbookingbutton.Name = "addbookingbutton";
            this.addbookingbutton.Size = new System.Drawing.Size(75, 23);
            this.addbookingbutton.TabIndex = 6;
            this.addbookingbutton.Text = "Add";
            this.addbookingbutton.UseVisualStyleBackColor = true;
            // 
            // cancelbutton
            // 
            this.cancelbutton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbutton.Location = new System.Drawing.Point(331, 292);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 7;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = true;
            // 
            // startdatebutton
            // 
            this.startdatebutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startdatebutton.BackgroundImage")));
            this.startdatebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startdatebutton.Location = new System.Drawing.Point(187, 35);
            this.startdatebutton.Name = "startdatebutton";
            this.startdatebutton.Size = new System.Drawing.Size(75, 35);
            this.startdatebutton.TabIndex = 8;
            this.startdatebutton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(187, 108);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 327);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.startdatebutton);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.addbookingbutton);
            this.Controls.Add(this.guestaccounttextBox);
            this.Controls.Add(this.pricetextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BookingForm";
            this.Text = "Booking Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pricetextBox;
        private System.Windows.Forms.TextBox guestaccounttextBox;
        private System.Windows.Forms.Button addbookingbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button startdatebutton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}