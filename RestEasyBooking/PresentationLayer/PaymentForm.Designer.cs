﻿namespace RestEasyBooking.PresentationLayer
{
    partial class PaymentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.submitbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.creditcardnotextBox = new System.Windows.Forms.TextBox();
            this.guestaccountnotextBox = new System.Windows.Forms.TextBox();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.surnametextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credit Card No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Guest Account No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // submitbutton
            // 
            this.submitbutton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitbutton.Location = new System.Drawing.Point(251, 313);
            this.submitbutton.Name = "submitbutton";
            this.submitbutton.Size = new System.Drawing.Size(75, 23);
            this.submitbutton.TabIndex = 3;
            this.submitbutton.Text = "Submit";
            this.submitbutton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Surname";
            // 
            // creditcardnotextBox
            // 
            this.creditcardnotextBox.Location = new System.Drawing.Point(251, 65);
            this.creditcardnotextBox.Name = "creditcardnotextBox";
            this.creditcardnotextBox.Size = new System.Drawing.Size(183, 20);
            this.creditcardnotextBox.TabIndex = 5;
            // 
            // guestaccountnotextBox
            // 
            this.guestaccountnotextBox.Location = new System.Drawing.Point(251, 119);
            this.guestaccountnotextBox.Name = "guestaccountnotextBox";
            this.guestaccountnotextBox.Size = new System.Drawing.Size(183, 20);
            this.guestaccountnotextBox.TabIndex = 6;
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(251, 173);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(183, 20);
            this.nametextBox.TabIndex = 7;
            // 
            // surnametextBox
            // 
            this.surnametextBox.Location = new System.Drawing.Point(251, 231);
            this.surnametextBox.Name = "surnametextBox";
            this.surnametextBox.Size = new System.Drawing.Size(183, 20);
            this.surnametextBox.TabIndex = 8;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 339);
            this.Controls.Add(this.surnametextBox);
            this.Controls.Add(this.nametextBox);
            this.Controls.Add(this.guestaccountnotextBox);
            this.Controls.Add(this.creditcardnotextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.submitbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PaymentForm";
            this.Text = "Payment Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox creditcardnotextBox;
        private System.Windows.Forms.TextBox guestaccountnotextBox;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.TextBox surnametextBox;
    }
}