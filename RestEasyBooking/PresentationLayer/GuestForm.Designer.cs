namespace RestEasyBooking.PresentationLayer
{
    partial class GuestForm
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
            this.namelabel = new System.Windows.Forms.Label();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.surnamelabel = new System.Windows.Forms.Label();
            this.surnametextBox = new System.Windows.Forms.TextBox();
            this.emaillabel = new System.Windows.Forms.Label();
            this.emailtextBox = new System.Windows.Forms.TextBox();
            this.addresslabel = new System.Windows.Forms.Label();
            this.addresstextBox = new System.Windows.Forms.TextBox();
            this.accountlabel = new System.Windows.Forms.Label();
            this.accounttextBox = new System.Windows.Forms.TextBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namelabel
            // 
            this.namelabel.AutoSize = true;
            this.namelabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelabel.Location = new System.Drawing.Point(30, 31);
            this.namelabel.Name = "namelabel";
            this.namelabel.Size = new System.Drawing.Size(48, 18);
            this.namelabel.TabIndex = 0;
            this.namelabel.Text = "Name";
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(158, 29);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(195, 20);
            this.nametextBox.TabIndex = 1;
            // 
            // surnamelabel
            // 
            this.surnamelabel.AutoSize = true;
            this.surnamelabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnamelabel.Location = new System.Drawing.Point(30, 75);
            this.surnamelabel.Name = "surnamelabel";
            this.surnamelabel.Size = new System.Drawing.Size(71, 18);
            this.surnamelabel.TabIndex = 2;
            this.surnamelabel.Text = "Surname";
            // 
            // surnametextBox
            // 
            this.surnametextBox.Location = new System.Drawing.Point(158, 75);
            this.surnametextBox.Name = "surnametextBox";
            this.surnametextBox.Size = new System.Drawing.Size(195, 20);
            this.surnametextBox.TabIndex = 3;
            // 
            // emaillabel
            // 
            this.emaillabel.AutoSize = true;
            this.emaillabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emaillabel.Location = new System.Drawing.Point(30, 124);
            this.emaillabel.Name = "emaillabel";
            this.emaillabel.Size = new System.Drawing.Size(46, 18);
            this.emaillabel.TabIndex = 4;
            this.emaillabel.Text = "Email";
            // 
            // emailtextBox
            // 
            this.emailtextBox.Location = new System.Drawing.Point(158, 122);
            this.emailtextBox.Name = "emailtextBox";
            this.emailtextBox.Size = new System.Drawing.Size(195, 20);
            this.emailtextBox.TabIndex = 5;
            // 
            // addresslabel
            // 
            this.addresslabel.AutoSize = true;
            this.addresslabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addresslabel.Location = new System.Drawing.Point(30, 170);
            this.addresslabel.Name = "addresslabel";
            this.addresslabel.Size = new System.Drawing.Size(110, 18);
            this.addresslabel.TabIndex = 6;
            this.addresslabel.Text = "Home Address";
            // 
            // addresstextBox
            // 
            this.addresstextBox.Location = new System.Drawing.Point(158, 168);
            this.addresstextBox.Name = "addresstextBox";
            this.addresstextBox.Size = new System.Drawing.Size(195, 20);
            this.addresstextBox.TabIndex = 7;
            // 
            // accountlabel
            // 
            this.accountlabel.AutoSize = true;
            this.accountlabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountlabel.Location = new System.Drawing.Point(30, 210);
            this.accountlabel.Name = "accountlabel";
            this.accountlabel.Size = new System.Drawing.Size(89, 18);
            this.accountlabel.TabIndex = 8;
            this.accountlabel.Text = "Account No";
            // 
            // accounttextBox
            // 
            this.accounttextBox.Location = new System.Drawing.Point(158, 208);
            this.accounttextBox.Name = "accounttextBox";
            this.accounttextBox.Size = new System.Drawing.Size(195, 20);
            this.accounttextBox.TabIndex = 9;
            // 
            // addbutton
            // 
            this.addbutton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.Location = new System.Drawing.Point(33, 297);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(75, 23);
            this.addbutton.TabIndex = 10;
            this.addbutton.Text = "Add";
            this.addbutton.UseVisualStyleBackColor = true;
            // 
            // cancelbutton
            // 
            this.cancelbutton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbutton.Location = new System.Drawing.Point(403, 297);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 11;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = true;
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 332);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.accounttextBox);
            this.Controls.Add(this.accountlabel);
            this.Controls.Add(this.addresstextBox);
            this.Controls.Add(this.addresslabel);
            this.Controls.Add(this.emailtextBox);
            this.Controls.Add(this.emaillabel);
            this.Controls.Add(this.surnametextBox);
            this.Controls.Add(this.surnamelabel);
            this.Controls.Add(this.nametextBox);
            this.Controls.Add(this.namelabel);
            this.Name = "BookingForm";
            this.Text = "Guest Form";
            this.Load += new System.EventHandler(this.BookingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label namelabel;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.Label surnamelabel;
        private System.Windows.Forms.TextBox surnametextBox;
        private System.Windows.Forms.Label emaillabel;
        private System.Windows.Forms.TextBox emailtextBox;
        private System.Windows.Forms.Label addresslabel;
        private System.Windows.Forms.TextBox addresstextBox;
        private System.Windows.Forms.Label accountlabel;
        private System.Windows.Forms.TextBox accounttextBox;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button cancelbutton;
    }
}