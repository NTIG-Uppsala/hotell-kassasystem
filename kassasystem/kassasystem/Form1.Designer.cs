using System.Data.SQLite;
using System.Data;
using Microsoft.Data.Sqlite;

namespace kassasystem
{
    partial class hotelPaymentAndBookingSystem
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent()
        {
            this.lbl_button_val = new System.Windows.Forms.Label();
            this.BtnBooking = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.userControlBooking1 = new kassasystem.UserControlBooking();
            this.userControlPayment1 = new kassasystem.UserControlPayment();
            this.SuspendLayout();
            // 
            // lbl_button_val
            // 
            this.lbl_button_val.AutoSize = true;
            this.lbl_button_val.Font = new System.Drawing.Font("Segoe UI", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_button_val.Location = new System.Drawing.Point(88, 123);
            this.lbl_button_val.Name = "lbl_button_val";
            this.lbl_button_val.Size = new System.Drawing.Size(0, 114);
            this.lbl_button_val.TabIndex = 2;
            // 
            // BtnBooking
            // 
            this.BtnBooking.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BtnBooking.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBooking.Location = new System.Drawing.Point(12, 12);
            this.BtnBooking.Name = "BtnBooking";
            this.BtnBooking.Size = new System.Drawing.Size(175, 62);
            this.BtnBooking.TabIndex = 13;
            this.BtnBooking.Text = "Booking";
            this.BtnBooking.UseVisualStyleBackColor = false;
            this.BtnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPayment.Location = new System.Drawing.Point(12, 123);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(175, 62);
            this.btnPayment.TabIndex = 15;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // userControlBooking1
            // 
            this.userControlBooking1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlBooking1.BackColor = System.Drawing.Color.DarkGray;
            this.userControlBooking1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userControlBooking1.Location = new System.Drawing.Point(238, -1);
            this.userControlBooking1.Name = "userControlBooking1";
            this.userControlBooking1.Size = new System.Drawing.Size(1668, 1041);
            this.userControlBooking1.TabIndex = 17;
            // 
            // userControlPayment1
            // 
            this.userControlPayment1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlPayment1.BackColor = System.Drawing.Color.DarkGray;
            this.userControlPayment1.Location = new System.Drawing.Point(238, -1);
            this.userControlPayment1.Name = "userControlPayment1";
            this.userControlPayment1.Size = new System.Drawing.Size(1668, 1041);
            this.userControlPayment1.TabIndex = 18;
            // 
            // hotelPaymentAndBookingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.BtnBooking);
            this.Controls.Add(this.lbl_button_val);
            this.Controls.Add(this.userControlPayment1);
            this.Controls.Add(this.userControlBooking1);
            this.IsMdiContainer = true;
            this.Name = "hotelPaymentAndBookingSystem";
            this.Text = "Hotel Payment And Booking System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label lbl_button_val;
        private Button BtnBooking;
        private Button btnPayment;
        private UserControlBooking userControlBooking1;
        private UserControlPayment userControlPayment1;
    }
}