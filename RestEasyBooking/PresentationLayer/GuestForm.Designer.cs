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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuestForm));
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.phonenumbertextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // namelabel
            // 
            this.namelabel.AutoSize = true;
            this.namelabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelabel.Location = new System.Drawing.Point(30, 84);
            this.namelabel.Name = "namelabel";
            this.namelabel.Size = new System.Drawing.Size(48, 18);
            this.namelabel.TabIndex = 0;
            this.namelabel.Text = "Name";
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(149, 82);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(195, 20);
            this.nametextBox.TabIndex = 1;
            // 
            // surnamelabel
            // 
            this.surnamelabel.AutoSize = true;
            this.surnamelabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnamelabel.Location = new System.Drawing.Point(30, 133);
            this.surnamelabel.Name = "surnamelabel";
            this.surnamelabel.Size = new System.Drawing.Size(71, 18);
            this.surnamelabel.TabIndex = 2;
            this.surnamelabel.Text = "Surname";
            // 
            // surnametextBox
            // 
            this.surnametextBox.Location = new System.Drawing.Point(149, 131);
            this.surnametextBox.Name = "surnametextBox";
            this.surnametextBox.Size = new System.Drawing.Size(195, 20);
            this.surnametextBox.TabIndex = 3;
            // 
            // emaillabel
            // 
            this.emaillabel.AutoSize = true;
            this.emaillabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emaillabel.Location = new System.Drawing.Point(30, 171);
            this.emaillabel.Name = "emaillabel";
            this.emaillabel.Size = new System.Drawing.Size(46, 18);
            this.emaillabel.TabIndex = 4;
            this.emaillabel.Text = "Email";
            // 
            // emailtextBox
            // 
            this.emailtextBox.Location = new System.Drawing.Point(149, 169);
            this.emailtextBox.Name = "emailtextBox";
            this.emailtextBox.Size = new System.Drawing.Size(195, 20);
            this.emailtextBox.TabIndex = 5;
            // 
            // addresslabel
            // 
            this.addresslabel.AutoSize = true;
            this.addresslabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addresslabel.Location = new System.Drawing.Point(30, 219);
            this.addresslabel.Name = "addresslabel";
            this.addresslabel.Size = new System.Drawing.Size(110, 18);
            this.addresslabel.TabIndex = 6;
            this.addresslabel.Text = "Home Address";
            // 
            // addresstextBox
            // 
            this.addresstextBox.Location = new System.Drawing.Point(149, 217);
            this.addresstextBox.Name = "addresstextBox";
            this.addresstextBox.Size = new System.Drawing.Size(195, 20);
            this.addresstextBox.TabIndex = 7;
            // 
            // accountlabel
            // 
            this.accountlabel.AutoSize = true;
            this.accountlabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountlabel.Location = new System.Drawing.Point(30, 272);
            this.accountlabel.Name = "accountlabel";
            this.accountlabel.Size = new System.Drawing.Size(89, 18);
            this.accountlabel.TabIndex = 8;
            this.accountlabel.Text = "Account No";
            // 
            // accounttextBox
            // 
            this.accounttextBox.Location = new System.Drawing.Point(149, 270);
            this.accounttextBox.Name = "accounttextBox";
            this.accounttextBox.Size = new System.Drawing.Size(195, 20);
            this.accounttextBox.TabIndex = 9;
            // 
            // addbutton
            // 
            this.addbutton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.Location = new System.Drawing.Point(33, 354);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(75, 23);
            this.addbutton.TabIndex = 10;
            this.addbutton.Text = "Add";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbutton.Location = new System.Drawing.Point(400, 354);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 11;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "RestEasy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Phone No";
            // 
            // phonenumbertextBox
            // 
            this.phonenumbertextBox.Location = new System.Drawing.Point(149, 306);
            this.phonenumbertextBox.Name = "phonenumbertextBox";
            this.phonenumbertextBox.Size = new System.Drawing.Size(195, 20);
            this.phonenumbertextBox.TabIndex = 15;
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 389);
            this.Controls.Add(this.phonenumbertextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
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
            this.Name = "GuestForm";
            this.Text = "Guest Form";
            this.Load += new System.EventHandler(this.BookingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox phonenumbertextBox;
    }
}