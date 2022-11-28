namespace kassasystem
{
    partial class Form1
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
        private void InitializeComponent()
        {
            this.btn_two_single_beds = new System.Windows.Forms.Button();
            this.btn_double_bed = new System.Windows.Forms.Button();
            this.lbl_button_val = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbl_total = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_two_single_beds
            // 
            this.btn_two_single_beds.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_two_single_beds.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_two_single_beds.Location = new System.Drawing.Point(12, 12);
            this.btn_two_single_beds.Name = "btn_two_single_beds";
            this.btn_two_single_beds.Size = new System.Drawing.Size(197, 91);
            this.btn_two_single_beds.TabIndex = 0;
            this.btn_two_single_beds.Text = "room 2 single beds";
            this.btn_two_single_beds.UseVisualStyleBackColor = false;
            this.btn_two_single_beds.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_double_bed
            // 
            this.btn_double_bed.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_double_bed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_double_bed.Location = new System.Drawing.Point(215, 12);
            this.btn_double_bed.Name = "btn_double_bed";
            this.btn_double_bed.Size = new System.Drawing.Size(182, 91);
            this.btn_double_bed.TabIndex = 1;
            this.btn_double_bed.Text = "room 1 double bed";
            this.btn_double_bed.UseVisualStyleBackColor = false;
            this.btn_double_bed.Click += new System.EventHandler(this.btn_Click);
            // 
            // lbl_button_val
            // 
            this.lbl_button_val.AutoSize = true;
            this.lbl_button_val.Font = new System.Drawing.Font("Segoe UI", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_button_val.Location = new System.Drawing.Point(78, 145);
            this.lbl_button_val.Name = "lbl_button_val";
            this.lbl_button_val.Size = new System.Drawing.Size(0, 114);
            this.lbl_button_val.TabIndex = 2;
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.BackColor = System.Drawing.Color.Red;
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_clear.Location = new System.Drawing.Point(898, 589);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(168, 96);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "CLEAR";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(898, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(374, 504);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 0;
            // 
            // lbl_total
            // 
            this.lbl_total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_total.AutoSize = true;
            this.lbl_total.BackColor = System.Drawing.Color.White;
            this.lbl_total.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_total.Location = new System.Drawing.Point(908, 468);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(124, 37);
            this.lbl_total.TabIndex = 4;
            this.lbl_total.Text = "Total: 0kr";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(1109, 589);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 96);
            this.button1.TabIndex = 5;
            this.button1.Text = "PAY";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(898, 521);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "Remove 1x Product";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1111, 521);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 35);
            this.button3.TabIndex = 7;
            this.button3.Text = "Remove Product";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(692, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(692, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Checkout date";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1284, 697);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.lbl_button_val);
            this.Controls.Add(this.btn_double_bed);
            this.Controls.Add(this.btn_two_single_beds);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Button btn_two_single_beds;
        public Button btn_double_bed;
        public Label lbl_button_val;
        public Button btn_clear;
        public ListBox listBox1;
        public Label lbl_total;
        public Button button1;
        private Button button2;
        private Button button3;
        private DateTimePicker dateTimePicker1;
        private Label label1;
    }
}