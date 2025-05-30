using System.Drawing;
using System.Windows.Forms;

namespace LMSUser
{
    partial class LoanApplicationForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbLoanAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoanTerm = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLoanPurpose = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pbProof = new System.Windows.Forms.PictureBox();
            this.pbID = new System.Windows.Forms.PictureBox();
            this.lblIDStatus = new System.Windows.Forms.Label();
            this.lblProofStatus = new System.Windows.Forms.Label();
            this.btnUploadProof = new LMSUser.LoanApplicationForm.RoundedButton();
            this.btnUploadID = new LMSUser.LoanApplicationForm.RoundedButton();
            this.btnNext = new LMSUser.LoanApplicationForm.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbProof)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbID)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(55, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loan Application Form";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbLoanAmount
            // 
            this.tbLoanAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.tbLoanAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLoanAmount.ForeColor = System.Drawing.Color.White;
            this.tbLoanAmount.Location = new System.Drawing.Point(112, 173);
            this.tbLoanAmount.Name = "tbLoanAmount";
            this.tbLoanAmount.Size = new System.Drawing.Size(200, 27);
            this.tbLoanAmount.TabIndex = 1;

            this.tbLoanAmount.KeyPress += tbLoanAmount_KeyPress;
            this.tbLoanAmount.TextChanged += tbLoanAmount_TextChanged;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(112, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loan Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(112, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Term";
            // 
            // cbLoanTerm
            // 
            this.cbLoanTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.cbLoanTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoanTerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLoanTerm.ForeColor = System.Drawing.Color.White;
            this.cbLoanTerm.FormattingEnabled = true;
            this.cbLoanTerm.Items.AddRange(new object[] {
            "3 months to pay",
            "6 months to pay",
            "9 months to pay",
            "1 year to pay",
            "2 years to pay",
            "3 years to pay"});
            this.cbLoanTerm.Location = new System.Drawing.Point(112, 248);
            this.cbLoanTerm.Name = "cbLoanTerm";
            this.cbLoanTerm.Size = new System.Drawing.Size(200, 28);
            this.cbLoanTerm.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(112, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Purpose of Loan";
            // 
            // cbLoanPurpose
            // 
            this.cbLoanPurpose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(69)))));
            this.cbLoanPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoanPurpose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLoanPurpose.ForeColor = System.Drawing.Color.White;
            this.cbLoanPurpose.FormattingEnabled = true;
            this.cbLoanPurpose.Items.AddRange(new object[] {
            "Personal",
            "Business",
            "Emergency",
            "Education",
            "Medical bills"});
            this.cbLoanPurpose.Location = new System.Drawing.Point(112, 323);
            this.cbLoanPurpose.Name = "cbLoanPurpose";
            this.cbLoanPurpose.Size = new System.Drawing.Size(200, 28);
            this.cbLoanPurpose.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(413, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Upload Recent Payslip";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(417, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Upload Valid ID";
            // 
            // pbProof
            // 
            this.pbProof.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProof.Location = new System.Drawing.Point(413, 128);
            this.pbProof.Name = "pbProof";
            this.pbProof.Size = new System.Drawing.Size(250, 100);
            this.pbProof.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProof.TabIndex = 18;
            this.pbProof.TabStop = false;
            this.pbProof.Click += new System.EventHandler(this.pbProof_Click);
            // 
            // pbID
            // 
            this.pbID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbID.Location = new System.Drawing.Point(417, 305);
            this.pbID.Name = "pbID";
            this.pbID.Size = new System.Drawing.Size(250, 100);
            this.pbID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbID.TabIndex = 19;
            this.pbID.TabStop = false;
            // 
            // lblIDStatus
            // 
            this.lblIDStatus.AutoSize = true;
            this.lblIDStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDStatus.ForeColor = System.Drawing.Color.Red;
            this.lblIDStatus.Location = new System.Drawing.Point(506, 418);
            this.lblIDStatus.Name = "lblIDStatus";
            this.lblIDStatus.Size = new System.Drawing.Size(106, 17);
            this.lblIDStatus.TabIndex = 25;
            this.lblIDStatus.Text = "No ID Uploaded";
            this.lblIDStatus.Click += new System.EventHandler(this.btnUploadID_Click);
            // 
            // lblProofStatus
            // 
            this.lblProofStatus.AutoSize = true;
            this.lblProofStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProofStatus.ForeColor = System.Drawing.Color.Red;
            this.lblProofStatus.Location = new System.Drawing.Point(502, 241);
            this.lblProofStatus.Name = "lblProofStatus";
            this.lblProofStatus.Size = new System.Drawing.Size(188, 17);
            this.lblProofStatus.TabIndex = 22;
            this.lblProofStatus.Text = "No Proof of Income Uploaded";
            this.lblProofStatus.Click += new System.EventHandler(this.lblProofStatus_Click);
            // 
            // btnUploadProof
            // 
            this.btnUploadProof.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnUploadProof.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadProof.FlatAppearance.BorderSize = 0;
            this.btnUploadProof.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadProof.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUploadProof.ForeColor = System.Drawing.Color.White;
            this.btnUploadProof.Location = new System.Drawing.Point(418, 234);
            this.btnUploadProof.Name = "btnUploadProof";
            this.btnUploadProof.Size = new System.Drawing.Size(78, 32);
            this.btnUploadProof.TabIndex = 27;
            this.btnUploadProof.Text = "Upload";
            this.btnUploadProof.UseVisualStyleBackColor = false;
            this.btnUploadProof.Click += new System.EventHandler(this.btnUploadProof_Click);
            // 
            // btnUploadID
            // 
            this.btnUploadID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnUploadID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadID.FlatAppearance.BorderSize = 0;
            this.btnUploadID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUploadID.ForeColor = System.Drawing.Color.White;
            this.btnUploadID.Location = new System.Drawing.Point(422, 411);
            this.btnUploadID.Name = "btnUploadID";
            this.btnUploadID.Size = new System.Drawing.Size(78, 32);
            this.btnUploadID.TabIndex = 28;
            this.btnUploadID.Text = "Upload";
            this.btnUploadID.UseVisualStyleBackColor = false;
            this.btnUploadID.Click += new System.EventHandler(this.btnUploadID_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(592, 45);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(190, 39);
            this.btnNext.TabIndex = 30;
            this.btnNext.Text = "Calculate Monthly Payment";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // LoanApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnUploadID);
            this.Controls.Add(this.btnUploadProof);
            this.Controls.Add(this.lblProofStatus);
            this.Controls.Add(this.lblIDStatus);
            this.Controls.Add(this.pbID);
            this.Controls.Add(this.pbProof);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbLoanPurpose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbLoanTerm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLoanAmount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Name = "LoanApplicationForm";
            this.Size = new System.Drawing.Size(801, 453);
            this.Load += new System.EventHandler(this.LoanApplicationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProof)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #region Designer Variables
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLoanAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLoanTerm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLoanPurpose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbProof;
        private System.Windows.Forms.PictureBox pbID;
        
        private System.Windows.Forms.Label lblIDStatus;
        private System.Windows.Forms.Label lblProofStatus;
        #endregion

       
        private RoundedButton btnLogout;
        private RoundedButton btnUploadProof;
        private RoundedButton btnUploadID;
        private RoundedButton btnNext;

        class RoundedButton : Button
        {
            public int rdus = 10;
            System.Drawing.Drawing2D.GraphicsPath GetRoundPath(RectangleF Rect, int radius)
            {
                float r2 = radius / 2f;
                System.Drawing.Drawing2D.GraphicsPath GraphPath = new System.Drawing.Drawing2D.GraphicsPath();
                GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
                GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
                GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
                GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
                GraphPath.AddArc(Rect.X + Rect.Width - radius,
                        Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
                GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
                GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
                GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
                GraphPath.CloseFigure();
                return GraphPath;
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
                using (System.Drawing.Drawing2D.GraphicsPath GraphPath = GetRoundPath(Rect, rdus))
                {
                    this.Region = new Region(GraphPath);

                }
            }

        }
    }
}

