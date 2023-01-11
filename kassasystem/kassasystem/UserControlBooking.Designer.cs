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
            this.bookings = new System.Windows.Forms.ListBox();
            this.availableRooms = new System.Windows.Forms.ListBox();
            this.btnNewBooking = new System.Windows.Forms.Button();
            this.btnEditBooking = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.inputFirstName = new System.Windows.Forms.TextBox();
            this.inputLastName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Location = new System.Drawing.Point(1389, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(279, 27);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker2.Location = new System.Drawing.Point(1111, 14);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(272, 27);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.Visible = false;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // bookings
            // 
            this.bookings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookings.FormattingEnabled = true;
            this.bookings.ItemHeight = 15;
            this.bookings.Location = new System.Drawing.Point(13, 104);
            this.bookings.Name = "bookings";
            this.bookings.Size = new System.Drawing.Size(406, 919);
            this.bookings.TabIndex = 2;
            // 
            // availableRooms
            // 
            this.availableRooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.availableRooms.FormattingEnabled = true;
            this.availableRooms.ItemHeight = 15;
            this.availableRooms.Location = new System.Drawing.Point(583, 14);
            this.availableRooms.Name = "availableRooms";
            this.availableRooms.Size = new System.Drawing.Size(522, 1009);
            this.availableRooms.TabIndex = 3;
            this.availableRooms.Visible = false;
            // 
            // btnNewBooking
            // 
            this.btnNewBooking.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewBooking.Location = new System.Drawing.Point(13, 14);
            this.btnNewBooking.Name = "btnNewBooking";
            this.btnNewBooking.Size = new System.Drawing.Size(152, 72);
            this.btnNewBooking.TabIndex = 4;
            this.btnNewBooking.Text = "New booking";
            this.btnNewBooking.UseVisualStyleBackColor = true;
            this.btnNewBooking.Click += new System.EventHandler(this.btnNewBooking_Click);
            // 
            // btnEditBooking
            // 
            this.btnEditBooking.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditBooking.Location = new System.Drawing.Point(425, 14);
            this.btnEditBooking.Name = "btnEditBooking";
            this.btnEditBooking.Size = new System.Drawing.Size(152, 72);
            this.btnEditBooking.TabIndex = 5;
            this.btnEditBooking.Text = "Edit booking";
            this.btnEditBooking.UseVisualStyleBackColor = true;
            this.btnEditBooking.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(1111, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 72);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // inputFirstName
            // 
            this.inputFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFirstName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputFirstName.Location = new System.Drawing.Point(1111, 63);
            this.inputFirstName.Name = "inputFirstName";
            this.inputFirstName.PlaceholderText = "First name";
            this.inputFirstName.Size = new System.Drawing.Size(272, 27);
            this.inputFirstName.TabIndex = 7;
            this.inputFirstName.UseWaitCursor = true;
            this.inputFirstName.Visible = false;
            // 
            // inputLastName
            // 
            this.inputLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputLastName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputLastName.Location = new System.Drawing.Point(1389, 63);
            this.inputLastName.Name = "inputLastName";
            this.inputLastName.PlaceholderText = "Last name";
            this.inputLastName.Size = new System.Drawing.Size(279, 27);
            this.inputLastName.TabIndex = 8;
            this.inputLastName.Visible = false;
            // 
            // UserControlBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.inputLastName);
            this.Controls.Add(this.inputFirstName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEditBooking);
            this.Controls.Add(this.btnNewBooking);
            this.Controls.Add(this.availableRooms);
            this.Controls.Add(this.bookings);
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
        public ListBox bookings;
        public ListBox availableRooms;
        public Button btnNewBooking;
        public Button btnEditBooking;
        public Button btnSave;
        public TextBox inputFirstName;
        public TextBox inputLastName;
    }
}
