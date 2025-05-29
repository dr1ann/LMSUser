using System;
using System.Drawing;
using System.Windows.Forms;

namespace LMSUser
{
    public class CustomDatePicker : UserControl
    {
        private TextBox textBox;
        private Button dropDownButton;
        private MonthCalendar calendar;
        private Form popupForm;
        private bool isCalendarVisible = false;

        public DateTime SelectedDate
        {
            get => calendar.SelectionStart;
            set
            {
                calendar.SetDate(value);
                textBox.Text = value.ToShortDateString();
            }
        }

        public CustomDatePicker()
        {
            // Initialize TextBox
            textBox = new TextBox
            {
                BackColor = Color.FromArgb(37, 42, 69),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F),
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true,
                Width = 184,
                Location = new Point(0, 0)
            };

            // Initialize Button (dropdown arrow)
            dropDownButton = new Button
            {
                Text = "▼",
                Width = 30,
                Height = textBox.Height,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 42, 69),
                ForeColor = Color.White,
                Location = new Point(textBox.Width, 0),
                TabStop = false
            };
            dropDownButton.FlatAppearance.BorderSize = 0;

            // Initialize MonthCalendar
            calendar = new MonthCalendar
            {
                MaxSelectionCount = 1,
                BackColor = Color.White,
                ForeColor = Color.Black
            };

            // Event: When date selected, update TextBox and hide calendar
            calendar.DateSelected += (s, e) =>
            {
                SelectedDate = e.Start;
                HideCalendar();
            };

            // Event: Toggle calendar visibility on button click
            dropDownButton.Click += (s, e) =>
            {
                if (isCalendarVisible)
                    HideCalendar();
                else
                    ShowCalendar();
            };

            // Add controls
            Controls.Add(textBox);
            Controls.Add(dropDownButton);

            // Set control size
            this.Width = textBox.Width + dropDownButton.Width;
            this.Height = textBox.Height;
        }

        private void ShowCalendar()
        {
            if (popupForm == null || popupForm.IsDisposed)
            {
                popupForm = new Form
                {
                    FormBorderStyle = FormBorderStyle.None,
                    ShowInTaskbar = false,
                    StartPosition = FormStartPosition.Manual,
                    BackColor = Color.White,
                    ControlBox = false,
                    TopMost = true
                };
                popupForm.Controls.Add(calendar);
                popupForm.Deactivate += (s, e) => HideCalendar();

                // Force layout of the calendar so its PreferredSize is accurate
                popupForm.Load += (s, e) =>
                {
                    popupForm.ClientSize = calendar.PreferredSize;
                };
            }

            // Set size early just in case Load doesn't trigger (e.g. already loaded)
            calendar.PerformLayout(); // Forces layout now
            popupForm.ClientSize = calendar.PreferredSize;

            // Position popup below the control
            Point screenLocation = this.PointToScreen(new Point(0, this.Height));
            popupForm.Location = screenLocation;

            popupForm.Show();
            isCalendarVisible = true;
        }



        private void HideCalendar()
        {
            if (popupForm != null && !popupForm.IsDisposed)
            {
                popupForm.Hide();
            }
            isCalendarVisible = false;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!this.Visible)
            {
                HideCalendar();
            }
        }
    }

    partial class RegisterUser
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
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DOB = new LMSUser.CustomDatePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbFName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEmploymentStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMonthlyIncome = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.btnBack = new LMSUser.RoundedButton();
            this.RegUser = new LMSUser.RoundedButton();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(271, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 25);
            this.label4.TabIndex = 56;
            this.label4.Text = "Security Credentials";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(271, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(217, 25);
            this.label10.TabIndex = 51;
            this.label10.Text = "Employment details";
            // 
            // DOB
            // 
            this.DOB.Location = new System.Drawing.Point(36, 417);
            this.DOB.Name = "DOB";
            this.DOB.SelectedDate = new System.DateTime(2025, 5, 27, 21, 39, 55, 703);
            this.DOB.Size = new System.Drawing.Size(220, 27);
            this.DOB.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(33, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 19);
            this.label7.TabIndex = 46;
            this.label7.Text = "Date of birth";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(31, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 25);
            this.label5.TabIndex = 41;
            this.label5.Text = "Contact Information";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(119, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 43);
            this.label1.TabIndex = 38;
            this.label1.Text = "REGISTRATION FORM";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 39;
            this.label2.Text = "Last Name";
            // 
            // tbLName
            // 
            this.tbLName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.tbLName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tbLName.ForeColor = System.Drawing.Color.White;
            this.tbLName.Location = new System.Drawing.Point(32, 146);
            this.tbLName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLName.Multiline = true;
            this.tbLName.Name = "tbLName";
            this.tbLName.Size = new System.Drawing.Size(178, 27);
            this.tbLName.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(32, 190);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 19);
            this.label15.TabIndex = 65;
            this.label15.Text = "First Name";
            // 
            // tbFName
            // 
            this.tbFName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.tbFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tbFName.ForeColor = System.Drawing.Color.White;
            this.tbFName.Location = new System.Drawing.Point(35, 212);
            this.tbFName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFName.Multiline = true;
            this.tbFName.Name = "tbFName";
            this.tbFName.Size = new System.Drawing.Size(178, 27);
            this.tbFName.TabIndex = 64;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(32, 258);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 19);
            this.label16.TabIndex = 67;
            this.label16.Text = "Address";
            // 
            // tbAddress
            // 
            this.tbAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.tbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tbAddress.ForeColor = System.Drawing.Color.White;
            this.tbAddress.Location = new System.Drawing.Point(35, 280);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(178, 27);
            this.tbAddress.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(33, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 69;
            this.label3.Text = "Phone";
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.tbPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tbPhoneNumber.ForeColor = System.Drawing.Color.White;
            this.tbPhoneNumber.Location = new System.Drawing.Point(36, 351);
            this.tbPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPhoneNumber.Multiline = true;
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(178, 27);
            this.tbPhoneNumber.TabIndex = 68;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(273, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 19);
            this.label6.TabIndex = 71;
            this.label6.Text = "Employment";
            // 
            // cmbEmploymentStatus
            // 
            this.cmbEmploymentStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.cmbEmploymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmploymentStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmploymentStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbEmploymentStatus.ForeColor = System.Drawing.Color.White;
            this.cmbEmploymentStatus.Items.AddRange(new object[] {
            "Employed",
            "Unemployed",
            "Self-employed"});
            this.cmbEmploymentStatus.Location = new System.Drawing.Point(276, 146);
            this.cmbEmploymentStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEmploymentStatus.Name = "cmbEmploymentStatus";
            this.cmbEmploymentStatus.Size = new System.Drawing.Size(178, 28);
            this.cmbEmploymentStatus.TabIndex = 70;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(273, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 19);
            this.label8.TabIndex = 73;
            this.label8.Text = "Monthly Income";
            // 
            // tbMonthlyIncome
            // 
            this.tbMonthlyIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.tbMonthlyIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMonthlyIncome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tbMonthlyIncome.ForeColor = System.Drawing.Color.White;
            this.tbMonthlyIncome.Location = new System.Drawing.Point(276, 212);
            this.tbMonthlyIncome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMonthlyIncome.Multiline = true;
            this.tbMonthlyIncome.Name = "tbMonthlyIncome";
            this.tbMonthlyIncome.Size = new System.Drawing.Size(178, 27);
            this.tbMonthlyIncome.TabIndex = 72;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(273, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 19);
            this.label9.TabIndex = 77;
            this.label9.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tbPassword.ForeColor = System.Drawing.Color.White;
            this.tbPassword.Location = new System.Drawing.Point(276, 398);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(178, 27);
            this.tbPassword.TabIndex = 76;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(273, 304);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 19);
            this.label11.TabIndex = 75;
            this.label11.Text = "Username";
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.tbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tbUsername.ForeColor = System.Drawing.Color.White;
            this.tbUsername.Location = new System.Drawing.Point(276, 326);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUsername.Multiline = true;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(178, 27);
            this.tbUsername.TabIndex = 74;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(23, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(39, 25);
            this.btnBack.TabIndex = 62;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // RegUser
            // 
            this.RegUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.RegUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegUser.FlatAppearance.BorderSize = 0;
            this.RegUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegUser.ForeColor = System.Drawing.Color.White;
            this.RegUser.Location = new System.Drawing.Point(138, 467);
            this.RegUser.Name = "RegUser";
            this.RegUser.Size = new System.Drawing.Size(254, 47);
            this.RegUser.TabIndex = 61;
            this.RegUser.Text = "REGISTER";
            this.RegUser.UseVisualStyleBackColor = false;
            this.RegUser.Click += new System.EventHandler(this.RegUser_Click);
            // 
            // RegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbMonthlyIncome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbEmploymentStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPhoneNumber);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbFName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.RegUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DOB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLName);
            this.Name = "RegisterUser";
            this.Size = new System.Drawing.Size(533, 529);
            this.Load += new System.EventHandler(this.RegisterUser_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton RegUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private CustomDatePicker DOB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLName;
        private RoundedButton btnBack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbFName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbEmploymentStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMonthlyIncome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbUsername;



}
}
