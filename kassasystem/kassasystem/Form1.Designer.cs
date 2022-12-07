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

        private Button CreateButton(string Name, string Text, int x, int y)
        {
            var button = new System.Windows.Forms.Button();

            button.Text = Text;
            button.Name = Name;
            button.BackColor = System.Drawing.Color.LightSkyBlue;
            button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button.Location = new System.Drawing.Point(x, y);

            button.Size = new System.Drawing.Size(200, 90);
            button.TabIndex = 0;
            button.UseVisualStyleBackColor = false;

            return button;

        }
        private void InitializeComponent()
        {
            this.lbl_button_val = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.BtnRemove1x = new System.Windows.Forms.Button();
            this.BtnRemoveAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckOutDayPicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // Generate room buttons
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
            SQLiteConnection con = new SQLiteConnection(String.Format(@"Data Source=C:\Users\{0}\Documents\hotel_database\database.db", userName));
            con.Open();
            var roomTypes = new List<string>();

            string query = "SELECT type FROM roomTypes";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            int x = 15;
            int y = 144;
            int offset = 0;

            while (rdr.Read())
            {
                //System.Diagnostics.Debug.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)}");

                roomTypes.Add($"{rdr.GetString(0)}");
                string roomType = rdr.GetString(0);
                this.priceList.Add(roomType, 2000);
                Button newButton = CreateButton(roomType, roomType, x+offset, y);
                offset += 200;
                newButton.Click += new System.EventHandler(this.BtnClick);
                this.Controls.Add(newButton);

            }
            //for (int xyz = 0; xyz < roomTypes.Count; xyz++)
            //{
            //    System.Diagnostics.Debug.WriteLine(roomTypes[x]);
            //}
            con.Close();

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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Checkout date";

            // 
            // CheckOutDayPicker
            // 
            this.CheckOutDayPicker.Location = new System.Drawing.Point(12, 53);
            this.CheckOutDayPicker.MinDate = new System.DateTime(2022, 11, 29, 0, 0, 0, 0);
            this.CheckOutDayPicker.Name = "CheckOutDayPicker";
            this.CheckOutDayPicker.Size = new System.Drawing.Size(200, 23);
            this.CheckOutDayPicker.TabIndex = 8;
            this.CheckOutDayPicker.Value = new System.DateTime(2022, 11, 29, 12, 30, 0, 0);
            this.CheckOutDayPicker.ValueChanged += new System.EventHandler(this.CheckOutDayPicker_ValueChanged);

            // 
            // Room type label
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 109);
            this.label2.Name = "Room type label";
            this.label2.Size = new System.Drawing.Size(140, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "Room types";
            
            // 
            // hotelPaymentAndBookingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckOutDayPicker);
            this.Controls.Add(this.BtnRemoveAll);
            this.Controls.Add(this.BtnRemove1x);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lbl_button_val);
            this.Name = "hotelPaymentAndBookingSystem";
            this.Text = "Hotel Payment And Booking System";
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
        private Label label1;
        private DateTimePicker CheckOutDayPicker;
        private Label label2;
    }
}