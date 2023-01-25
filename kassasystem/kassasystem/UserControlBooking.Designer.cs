namespace kassasystem
{
    partial class UserControlBooking
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnNewBooking = new System.Windows.Forms.Button();
            this.btnEditBooking = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.inputFirstName = new System.Windows.Forms.TextBox();
            this.inputLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.unpaidBookings = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.paidBookings = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.availableRooms = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.searchPaidBookings = new System.Windows.Forms.TextBox();
            this.searchUnpaidBookings = new System.Windows.Forms.TextBox();
            this.roomOccupation = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Location = new System.Drawing.Point(1389, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(279, 27);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker2.Location = new System.Drawing.Point(1111, 29);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(272, 27);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.Visible = false;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // btnNewBooking
            // 
            this.btnNewBooking.BackColor = System.Drawing.Color.LightGray;
            this.btnNewBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewBooking.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewBooking.Location = new System.Drawing.Point(560, 41);
            this.btnNewBooking.Name = "btnNewBooking";
            this.btnNewBooking.Size = new System.Drawing.Size(175, 45);
            this.btnNewBooking.TabIndex = 4;
            this.btnNewBooking.Text = "New booking";
            this.btnNewBooking.UseVisualStyleBackColor = false;
            this.btnNewBooking.Click += new System.EventHandler(this.btnNewBooking_Click);
            // 
            // btnEditBooking
            // 
            this.btnEditBooking.BackColor = System.Drawing.Color.LightGray;
            this.btnEditBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBooking.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditBooking.Location = new System.Drawing.Point(560, 146);
            this.btnEditBooking.Name = "btnEditBooking";
            this.btnEditBooking.Size = new System.Drawing.Size(175, 45);
            this.btnEditBooking.TabIndex = 5;
            this.btnEditBooking.Text = "Edit booking";
            this.btnEditBooking.UseVisualStyleBackColor = false;
            this.btnEditBooking.Click += new System.EventHandler(this.btnEditBooking_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(1111, 978);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 45);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // inputFirstName
            // 
            this.inputFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFirstName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputFirstName.Location = new System.Drawing.Point(1111, 62);
            this.inputFirstName.Name = "inputFirstName";
            this.inputFirstName.PlaceholderText = "First name";
            this.inputFirstName.Size = new System.Drawing.Size(272, 27);
            this.inputFirstName.TabIndex = 7;
            this.inputFirstName.Visible = false;
            // 
            // inputLastName
            // 
            this.inputLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputLastName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputLastName.Location = new System.Drawing.Point(1389, 62);
            this.inputLastName.Name = "inputLastName";
            this.inputLastName.PlaceholderText = "Last name";
            this.inputLastName.Size = new System.Drawing.Size(279, 27);
            this.inputLastName.TabIndex = 8;
            this.inputLastName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 643);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Paid bookings:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(8, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label2.Size = new System.Drawing.Size(200, 38);
            this.label2.TabIndex = 11;
            this.label2.Text = "Unpaid bookings:";
            // 
            // unpaidBookings
            // 
            this.unpaidBookings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader12,
            this.columnHeader13});
            this.unpaidBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.unpaidBookings.FullRowSelect = true;
            this.unpaidBookings.GridLines = true;
            this.unpaidBookings.Location = new System.Drawing.Point(8, 76);
            this.unpaidBookings.Name = "unpaidBookings";
            this.unpaidBookings.Size = new System.Drawing.Size(546, 564);
            this.unpaidBookings.TabIndex = 12;
            this.unpaidBookings.UseCompatibleStateImageBehavior = false;
            this.unpaidBookings.View = System.Windows.Forms.View.Details;
            this.unpaidBookings.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.unpaidBookings_ColumnClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "First name";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Last name";
            this.columnHeader10.Width = 150;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Check-in date";
            this.columnHeader12.Width = 120;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Check-out date";
            this.columnHeader13.Width = 120;
            // 
            // paidBookings
            // 
            this.paidBookings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.paidBookings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader14});
            this.paidBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.paidBookings.FullRowSelect = true;
            this.paidBookings.GridLines = true;
            this.paidBookings.Location = new System.Drawing.Point(8, 713);
            this.paidBookings.Name = "paidBookings";
            this.paidBookings.Size = new System.Drawing.Size(546, 310);
            this.paidBookings.TabIndex = 15;
            this.paidBookings.UseCompatibleStateImageBehavior = false;
            this.paidBookings.View = System.Windows.Forms.View.Details;
            this.paidBookings.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.paidBookings_ColumnClick);
            // 
            // columnHeader11
            // 
            this.columnHeader11.DisplayIndex = 1;
            this.columnHeader11.Text = "Last name";
            this.columnHeader11.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 0;
            this.columnHeader4.Text = "First name";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Check-in date";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Check-out date";
            this.columnHeader14.Width = 120;
            // 
            // availableRooms
            // 
            this.availableRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.availableRooms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.availableRooms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.availableRooms.FullRowSelect = true;
            this.availableRooms.GridLines = true;
            this.availableRooms.Location = new System.Drawing.Point(1111, 95);
            this.availableRooms.Name = "availableRooms";
            this.availableRooms.Size = new System.Drawing.Size(557, 877);
            this.availableRooms.TabIndex = 16;
            this.availableRooms.UseCompatibleStateImageBehavior = false;
            this.availableRooms.View = System.Windows.Forms.View.Details;
            this.availableRooms.Visible = false;
            this.availableRooms.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.availableRooms_ColumnClick);
            this.availableRooms.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.availableRooms_ItemSelectionChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Room number";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Room type";
            this.columnHeader6.Width = 160;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Total people";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Floor";
            this.columnHeader8.Width = 50;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Price / Night";
            this.columnHeader9.Width = 120;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemove.Location = new System.Drawing.Point(560, 95);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(175, 45);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove Booking";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1111, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Check-In";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(1389, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "Check-Out";
            this.label4.Visible = false;
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelBooking.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBooking.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelBooking.Location = new System.Drawing.Point(1493, 978);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(175, 45);
            this.btnCancelBooking.TabIndex = 20;
            this.btnCancelBooking.Text = "Cancel";
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            this.btnCancelBooking.Visible = false;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // searchPaidBookings
            // 
            this.searchPaidBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchPaidBookings.Location = new System.Drawing.Point(8, 678);
            this.searchPaidBookings.Name = "searchPaidBookings";
            this.searchPaidBookings.Size = new System.Drawing.Size(546, 29);
            this.searchPaidBookings.TabIndex = 21;
            this.searchPaidBookings.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // searchUnpaidBookings
            // 
            this.searchUnpaidBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchUnpaidBookings.Location = new System.Drawing.Point(8, 41);
            this.searchUnpaidBookings.Name = "searchUnpaidBookings";
            this.searchUnpaidBookings.Size = new System.Drawing.Size(546, 29);
            this.searchUnpaidBookings.TabIndex = 22;
            this.searchUnpaidBookings.TextChanged += new System.EventHandler(this.searchUnpaidBookings_TextChanged);
            // 
            // roomOccupation
            // 
            this.roomOccupation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader15});
            this.roomOccupation.Location = new System.Drawing.Point(900, 29);
            this.roomOccupation.Name = "roomOccupation";
            this.roomOccupation.Size = new System.Drawing.Size(205, 185);
            this.roomOccupation.TabIndex = 23;
            this.roomOccupation.UseCompatibleStateImageBehavior = false;
            this.roomOccupation.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Check-in date";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Check-out date";
            this.columnHeader15.Width = 100;
            // 
            // UserControlBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.roomOccupation);
            this.Controls.Add(this.searchUnpaidBookings);
            this.Controls.Add(this.searchPaidBookings);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.availableRooms);
            this.Controls.Add(this.paidBookings);
            this.Controls.Add(this.unpaidBookings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputLastName);
            this.Controls.Add(this.inputFirstName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEditBooking);
            this.Controls.Add(this.btnNewBooking);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "UserControlBooking";
            this.Size = new System.Drawing.Size(1671, 1030);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DateTimePicker dateTimePicker1;
        public DateTimePicker dateTimePicker2;
        public Button btnNewBooking;
        public Button btnEditBooking;
        public Button btnSave;
        public TextBox inputFirstName;
        public TextBox inputLastName;
        public Label label1;
        public Label label2;
        public ListView unpaidBookings;
        public ColumnHeader columnHeader2;
        public ListView paidBookings;
        public ColumnHeader columnHeader4;
        public ListView availableRooms;
        public ColumnHeader columnHeader5;
        public ColumnHeader columnHeader6;
        public ColumnHeader columnHeader7;
        public ColumnHeader columnHeader8;
        public ColumnHeader columnHeader9;
        public ColumnHeader columnHeader10;
        public ColumnHeader columnHeader11;
        public Button btnRemove;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader14;
        private Label label3;
        private Label label4;
        public Button btnCancelBooking;
        private TextBox searchPaidBookings;
        private TextBox searchUnpaidBookings;
        private ListView roomOccupation;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader15;
    }
}
