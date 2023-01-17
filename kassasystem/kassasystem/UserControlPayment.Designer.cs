namespace kassasystem
{
    partial class UserControlPayment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_button_val = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.LblBooking = new System.Windows.Forms.Label();
            this.bookingsList = new System.Windows.Forms.ListBox();
            this.btnSendToPaymentList = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.Location = new System.Drawing.Point(1596, 934);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(146, 96);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(300, 829);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(1596, 876);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(300, 43);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: 0.00 SEK";
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.BackColor = System.Drawing.Color.Lime;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPay.Location = new System.Drawing.Point(1750, 934);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(146, 96);
            this.btnPay.TabIndex = 5;
            this.btnPay.Text = "PAY";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.BtnPayClick);
            // 
            // LblBooking
            // 
            this.LblBooking.AutoSize = true;
            this.LblBooking.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBooking.Location = new System.Drawing.Point(8, 0);
            this.LblBooking.Name = "LblBooking";
            this.LblBooking.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.LblBooking.Size = new System.Drawing.Size(117, 38);
            this.LblBooking.TabIndex = 10;
            this.LblBooking.Text = "Bookings:";
            // 
            // bookingsList
            // 
            this.bookingsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bookingsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookingsList.FormattingEnabled = true;
            this.bookingsList.ItemHeight = 15;
            this.bookingsList.Location = new System.Drawing.Point(0, 0);
            this.bookingsList.Margin = new System.Windows.Forms.Padding(0);
            this.bookingsList.Name = "bookingsList";
            this.bookingsList.Size = new System.Drawing.Size(504, 992);
            this.bookingsList.TabIndex = 11;
            this.bookingsList.SelectedIndexChanged += new System.EventHandler(this.bookingsList_SelectedIndexChanged);
            // 
            // btnSendToPaymentList
            // 
            this.btnSendToPaymentList.BackColor = System.Drawing.Color.LightGray;
            this.btnSendToPaymentList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToPaymentList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSendToPaymentList.Location = new System.Drawing.Point(518, 89);
            this.btnSendToPaymentList.Name = "btnSendToPaymentList";
            this.btnSendToPaymentList.Size = new System.Drawing.Size(175, 45);
            this.btnSendToPaymentList.TabIndex = 12;
            this.btnSendToPaymentList.Text = "Select Booking";
            this.btnSendToPaymentList.UseVisualStyleBackColor = false;
            this.btnSendToPaymentList.Click += new System.EventHandler(this.btnSendToPaymentList_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(518, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 45);
            this.button1.TabIndex = 13;
            this.button1.Text = "Remove Booking";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnRmBooking_click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1596, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label1.Size = new System.Drawing.Size(120, 38);
            this.label1.TabIndex = 14;
            this.label1.Text = "Checkout:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(1596, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 829);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.bookingsList);
            this.panel2.Location = new System.Drawing.Point(8, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 992);
            this.panel2.TabIndex = 16;
            // 
            // UserControlPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSendToPaymentList);
            this.Controls.Add(this.LblBooking);
            this.Controls.Add(this.lbl_button_val);
            this.Name = "UserControlPayment";
            this.Size = new System.Drawing.Size(1904, 1041);
            this.Load += new System.EventHandler(this.UserControlPayment_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label lbl_button_val;
        public Button btnClear;
        public ListBox listBox1;
        public Label lblTotal;
        public Button btnPay;
        public Label LblBooking;
        public ListBox bookingsList;
        public Button btnSendToPaymentList;
        public Button button1;
        public Label label1;
        private Panel panel1;
        private Panel panel2;
    }

}
