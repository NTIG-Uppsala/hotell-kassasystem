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
            this.btn_person = new System.Windows.Forms.Button();
            this.btn_room = new System.Windows.Forms.Button();
            this.lbl_button_val = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_person
            // 
            this.btn_person.Location = new System.Drawing.Point(12, 12);
            this.btn_person.Name = "btn_person";
            this.btn_person.Size = new System.Drawing.Size(197, 91);
            this.btn_person.TabIndex = 0;
            this.btn_person.Text = "person";
            this.btn_person.UseVisualStyleBackColor = true;
            this.btn_person.Click += new System.EventHandler(this.btn_person_Click);
            // 
            // btn_room
            // 
            this.btn_room.Location = new System.Drawing.Point(231, 12);
            this.btn_room.Name = "btn_room";
            this.btn_room.Size = new System.Drawing.Size(182, 91);
            this.btn_room.TabIndex = 1;
            this.btn_room.Text = "room";
            this.btn_room.UseVisualStyleBackColor = true;
            this.btn_room.Click += new System.EventHandler(this.btn_room_Click);
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
            this.btn_clear.Location = new System.Drawing.Point(12, 262);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 292);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.lbl_button_val);
            this.Controls.Add(this.btn_room);
            this.Controls.Add(this.btn_person);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_person;
        private Button btn_room;
        private Label lbl_button_val;
        private Button btn_clear;
    }
}