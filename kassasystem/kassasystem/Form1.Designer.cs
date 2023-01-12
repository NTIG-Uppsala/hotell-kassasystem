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
            this.userControlBooking1 = new kassasystem.UserControlBooking();
            this.userControlPayment1 = new kassasystem.UserControlPayment();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.paymentPage = new System.Windows.Forms.TabPage();
            this.bookingManagementPage = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.paymentPage.SuspendLayout();
            this.bookingManagementPage.SuspendLayout();
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
            // userControlBooking1
            // 
            this.userControlBooking1.BackColor = System.Drawing.Color.DarkGray;
            this.userControlBooking1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userControlBooking1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlBooking1.Location = new System.Drawing.Point(3, 3);
            this.userControlBooking1.Name = "userControlBooking1";
            this.userControlBooking1.Size = new System.Drawing.Size(1890, 1007);
            this.userControlBooking1.TabIndex = 17;
            // 
            // userControlPayment1
            // 
            this.userControlPayment1.BackColor = System.Drawing.Color.DarkGray;
            this.userControlPayment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlPayment1.Location = new System.Drawing.Point(3, 3);
            this.userControlPayment1.Name = "userControlPayment1";
            this.userControlPayment1.Size = new System.Drawing.Size(1890, 1007);
            this.userControlPayment1.TabIndex = 18;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.paymentPage);
            this.tabControl1.Controls.Add(this.bookingManagementPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1904, 1041);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // paymentPage
            // 
            this.paymentPage.Controls.Add(this.userControlPayment1);
            this.paymentPage.Location = new System.Drawing.Point(4, 24);
            this.paymentPage.Name = "paymentPage";
            this.paymentPage.Padding = new System.Windows.Forms.Padding(3);
            this.paymentPage.Size = new System.Drawing.Size(1896, 1013);
            this.paymentPage.TabIndex = 0;
            this.paymentPage.Text = "Payment";
            this.paymentPage.UseVisualStyleBackColor = true;
            // 
            // bookingManagementPage
            // 
            this.bookingManagementPage.Controls.Add(this.userControlBooking1);
            this.bookingManagementPage.Location = new System.Drawing.Point(4, 24);
            this.bookingManagementPage.Name = "bookingManagementPage";
            this.bookingManagementPage.Padding = new System.Windows.Forms.Padding(3);
            this.bookingManagementPage.Size = new System.Drawing.Size(1896, 1013);
            this.bookingManagementPage.TabIndex = 1;
            this.bookingManagementPage.Text = "Booking Management";
            this.bookingManagementPage.UseVisualStyleBackColor = true;
            // 
            // hotelPaymentAndBookingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbl_button_val);
            this.IsMdiContainer = true;
            this.Name = "hotelPaymentAndBookingSystem";
            this.Text = "Hotel Payment And Booking System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1Load);
            this.tabControl1.ResumeLayout(false);
            this.paymentPage.ResumeLayout(false);
            this.bookingManagementPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label lbl_button_val;
        public UserControlBooking userControlBooking1;
        public UserControlPayment userControlPayment1;
        public TabControl tabControl1;
        public TabPage paymentPage;
        public TabPage bookingManagementPage;
    }
}