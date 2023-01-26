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
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.LblBooking = new System.Windows.Forms.Label();
            this.btnSendToPaymentList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bookingsList = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.searchBookings = new System.Windows.Forms.TextBox();
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
            this.btnClear.Location = new System.Drawing.Point(1082, 934);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(382, 96);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(1082, 876);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(814, 52);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: 0.00 SEK";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.BackColor = System.Drawing.Color.Lime;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPay.Location = new System.Drawing.Point(1470, 934);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(426, 96);
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
            // btnSendToPaymentList
            // 
            this.btnSendToPaymentList.BackColor = System.Drawing.Color.LightGray;
            this.btnSendToPaymentList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToPaymentList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSendToPaymentList.Location = new System.Drawing.Point(708, 38);
            this.btnSendToPaymentList.Name = "btnSendToPaymentList";
            this.btnSendToPaymentList.Size = new System.Drawing.Size(175, 45);
            this.btnSendToPaymentList.TabIndex = 12;
            this.btnSendToPaymentList.Text = "Select Booking";
            this.btnSendToPaymentList.UseVisualStyleBackColor = false;
            this.btnSendToPaymentList.Click += new System.EventHandler(this.btnSendToPaymentList_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1082, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label1.Size = new System.Drawing.Size(120, 38);
            this.label1.TabIndex = 14;
            this.label1.Text = "Checkout:";
            // 
            // bookingsList
            // 
            this.bookingsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookingsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader11});
            this.bookingsList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bookingsList.FullRowSelect = true;
            this.bookingsList.GridLines = true;
            this.bookingsList.Location = new System.Drawing.Point(8, 76);
            this.bookingsList.Name = "bookingsList";
            this.bookingsList.Size = new System.Drawing.Size(694, 954);
            this.bookingsList.TabIndex = 17;
            this.bookingsList.UseCompatibleStateImageBehavior = false;
            this.bookingsList.View = System.Windows.Forms.View.Details;
            this.bookingsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.bookingsList_ColumnClick);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Last name";
            this.columnHeader7.Width = 110;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Check-in date";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Check-out date";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "First name";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Room";
            this.columnHeader10.Width = 120;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Roomnumber";
            this.columnHeader11.Width = 110;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(1082, 38);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(814, 829);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "First name";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Last name";
            this.columnHeader5.Width = 110;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Check-in date";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Check-out date";
            this.columnHeader12.Width = 120;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Room";
            this.columnHeader13.Width = 120;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Roomnumber";
            this.columnHeader14.Width = 110;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Price";
            this.columnHeader15.Width = 120;
            // 
            // searchBookings
            // 
            this.searchBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchBookings.Location = new System.Drawing.Point(8, 41);
            this.searchBookings.Name = "searchBookings";
            this.searchBookings.PlaceholderText = "Search bookings";
            this.searchBookings.Size = new System.Drawing.Size(694, 29);
            this.searchBookings.TabIndex = 23;
            this.searchBookings.TextChanged += new System.EventHandler(this.searchBookings_TextChanged);
            // 
            // UserControlPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.searchBookings);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bookingsList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnSendToPaymentList);
            this.Controls.Add(this.LblBooking);
            this.Controls.Add(this.lbl_button_val);
            this.Name = "UserControlPayment";
            this.Size = new System.Drawing.Size(1904, 1041);
            this.Load += new System.EventHandler(this.UserControlPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label lbl_button_val;
        public Button btnClear;
        public Label lblTotal;
        public Button btnPay;
        public Label LblBooking;
        public Button btnSendToPaymentList;
        public Label label1;
        public ListView bookingsList;
        public ColumnHeader columnHeader2;
        public ListView listView1;
        public ColumnHeader columnHeader4;
        public ColumnHeader columnHeader5;
        public ColumnHeader columnHeader7;
        public ColumnHeader columnHeader8;
        public ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private TextBox searchBookings;
    }

}
