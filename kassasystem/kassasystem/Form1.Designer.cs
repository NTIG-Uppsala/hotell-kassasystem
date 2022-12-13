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
            this.btnClear = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.BtnRemove1x = new System.Windows.Forms.Button();
            this.BtnRemoveAll = new System.Windows.Forms.Button();
            this.LblBooking = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.BtnBooking = new System.Windows.Forms.Button();
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
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.Location = new System.Drawing.Point(1518, 933);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(168, 96);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(1518, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(374, 829);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(1527, 794);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(124, 37);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: 0kr";
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.BackColor = System.Drawing.Color.Lime;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPay.Location = new System.Drawing.Point(1729, 933);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(163, 96);
            this.btnPay.TabIndex = 5;
            this.btnPay.Text = "PAY";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.BtnPayClick);
            // 
            // BtnRemove1x
            // 
            this.BtnRemove1x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemove1x.Location = new System.Drawing.Point(1518, 865);
            this.BtnRemove1x.Name = "BtnRemove1x";
            this.BtnRemove1x.Size = new System.Drawing.Size(163, 35);
            this.BtnRemove1x.TabIndex = 6;
            this.BtnRemove1x.Text = "Remove 1x Product";
            this.BtnRemove1x.UseVisualStyleBackColor = true;
            this.BtnRemove1x.Click += new System.EventHandler(this.BtnRemove1xClick);
            // 
            // BtnRemoveAll
            // 
            this.BtnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveAll.Location = new System.Drawing.Point(1731, 865);
            this.BtnRemoveAll.Name = "BtnRemoveAll";
            this.BtnRemoveAll.Size = new System.Drawing.Size(161, 35);
            this.BtnRemoveAll.TabIndex = 7;
            this.BtnRemoveAll.Text = "Remove Product";
            this.BtnRemoveAll.UseVisualStyleBackColor = true;
            this.BtnRemoveAll.Click += new System.EventHandler(this.BtnRemoveClick);
            // 
            // LblBooking
            // 
            this.LblBooking.AutoSize = true;
            this.LblBooking.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBooking.Location = new System.Drawing.Point(12, 91);
            this.LblBooking.Name = "LblBooking";
            this.LblBooking.Size = new System.Drawing.Size(117, 32);
            this.LblBooking.TabIndex = 10;
            this.LblBooking.Text = "Bookings:";
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.BackColor = System.Drawing.Color.Lime;
            this.btnTest.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTest.Location = new System.Drawing.Point(0, 600);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(163, 96);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test Do Not Delete";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.BtnClick);
            // 
            // BtnBooking
            // 
            this.BtnBooking.Location = new System.Drawing.Point(12, 12);
            this.BtnBooking.Name = "BtnBooking";
            this.BtnBooking.Size = new System.Drawing.Size(175, 62);
            this.BtnBooking.TabIndex = 13;
            this.BtnBooking.Text = "Booking";
            this.BtnBooking.UseVisualStyleBackColor = true;
            this.BtnBooking.Click += new System.EventHandler(this.button1_Click);
            // 
            // hotelPaymentAndBookingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.BtnBooking);
            this.Controls.Add(this.LblBooking);
            this.Controls.Add(this.BtnRemoveAll);
            this.Controls.Add(this.BtnRemove1x);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lbl_button_val);
            this.Controls.Add(this.btnTest);
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
        public Button btnClear;
        public ListBox listBox1;
        public Label lblTotal;
        public Button btnPay;
        public Button BtnRemove1x;
        public Button BtnRemoveAll;
        public Button btnTest;
        private Label LblBooking;
        private Button BtnBooking;
    }
}