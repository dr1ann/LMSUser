using System.Drawing;
using System.Windows.Forms;

namespace LMSUser
{

    partial class UserDashboard
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
            this.lblUserCredit = new System.Windows.Forms.Label();
            this.btnApplyLoan = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogout = new LMSUser.UserDashboard.RoundedButton();
            this.dgvUserLoans = new System.Windows.Forms.DataGridView();
            this.btnApp = new LMSUser.UserDashboard.RoundedButton();
            this.btnCashin = new LMSUser.UserDashboard.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserLoans)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserCredit
            // 
            this.lblUserCredit.AutoSize = true;
            this.lblUserCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(20)))), ((int)(((byte)(38)))));
            this.lblUserCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCredit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUserCredit.Location = new System.Drawing.Point(26, 95);
            this.lblUserCredit.Name = "lblUserCredit";
            this.lblUserCredit.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.lblUserCredit.Size = new System.Drawing.Size(91, 43);
            this.lblUserCredit.TabIndex = 9;
            this.lblUserCredit.Text = "label1";
         
            // 
            // btnApplyLoan
            // 
            this.btnApplyLoan.Location = new System.Drawing.Point(0, 0);
            this.btnApplyLoan.Name = "btnApplyLoan";
            this.btnApplyLoan.Size = new System.Drawing.Size(75, 23);
            this.btnApplyLoan.TabIndex = 13;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUsername.Location = new System.Drawing.Point(25, 62);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(35, 13);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "label1";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(723, 40);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(61, 28);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dgvUserLoans
            // 
            this.dgvUserLoans.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.dgvUserLoans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUserLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserLoans.EnableHeadersVisualStyles = false;
            this.dgvUserLoans.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.dgvUserLoans.Location = new System.Drawing.Point(28, 159);
            this.dgvUserLoans.Name = "dgvUserLoans";
            this.dgvUserLoans.Size = new System.Drawing.Size(757, 197);
            this.dgvUserLoans.TabIndex = 11;
            this.dgvUserLoans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserLoans_CellClick);
            // 
            // btnApp
            // 
            this.btnApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApp.FlatAppearance.BorderSize = 0;
            this.btnApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnApp.ForeColor = System.Drawing.Color.White;
            this.btnApp.Location = new System.Drawing.Point(667, 111);
            this.btnApp.Name = "btnApp";
            this.btnApp.Size = new System.Drawing.Size(118, 40);
            this.btnApp.TabIndex = 12;
            this.btnApp.Text = "Apply Loan";
            this.btnApp.UseVisualStyleBackColor = false;
            this.btnApp.Click += new System.EventHandler(this.btnApplyLoan_Click);
            // 
            // btnCashin
            // 
            this.btnCashin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnCashin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCashin.FlatAppearance.BorderSize = 0;
            this.btnCashin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCashin.ForeColor = System.Drawing.Color.White;
            this.btnCashin.Location = new System.Drawing.Point(680, 410);
            this.btnCashin.Name = "btnCashin";
            this.btnCashin.Size = new System.Drawing.Size(118, 40);
            this.btnCashin.TabIndex = 14;
            this.btnCashin.Text = "Cash in";
            this.btnCashin.UseVisualStyleBackColor = false;
            this.btnCashin.Click += new System.EventHandler(this.btnCashin_Click);
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.btnCashin);
            this.Controls.Add(this.btnApp);
            this.Controls.Add(this.lblUserCredit);
            this.Controls.Add(this.dgvUserLoans);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnApplyLoan);
            this.Controls.Add(this.lblUsername);
            this.Name = "UserDashboard";
            this.Size = new System.Drawing.Size(801, 453);
            this.Load += new System.EventHandler(this.UserDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserLoans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserCredit;
        private System.Windows.Forms.Button btnApplyLoan;
        private System.Windows.Forms.Label lblUsername;
        private DataGridView dgvUserLoans;
        private RoundedButton btnApp;
        private RoundedButton btnLogout;
        private RoundedButton btnCashin;

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
