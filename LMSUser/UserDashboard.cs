using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace LMSUser
{
    public partial class UserDashboard : UserControl
    {
        private int userID;
        private UserForm parentForm;
        private FlowLayoutPanel breadcrumbPanel;
        private LinkLabel linkDashboard;
        private Label lblSeparator;
        private Label lblCurrentPage;

        private GraphicsPath GetRoundPath(Rectangle bounds, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            GraphPath.AddLine(bounds.X + r2, bounds.Y, bounds.Right - r2, bounds.Y);
            GraphPath.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            GraphPath.AddLine(bounds.Right, bounds.Y + r2, bounds.Right, bounds.Bottom - r2);
            GraphPath.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            GraphPath.AddLine(bounds.Right - r2, bounds.Bottom, bounds.X + r2, bounds.Bottom);
            GraphPath.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            GraphPath.AddLine(bounds.X, bounds.Bottom - r2, bounds.X, bounds.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        public UserDashboard(string fullName, string status, int userID, UserForm parent)
        {
            InitializeComponent();

            // Show description based on status
            if (status.ToLower() == "pending")
            {
                btnApp.Visible = false;
            } else {
                btnApp.Visible = true;
            }

                // Breadcrumb setup
                breadcrumbPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    FlowDirection = FlowDirection.LeftToRight,
                    Padding = new Padding(10, 10, 0, 10),
                    BackColor = Color.Transparent
                };

            linkDashboard = new LinkLabel
            {
                Text = "Dashboard",
                AutoSize = true,
                LinkColor = Color.LightBlue,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                LinkBehavior = LinkBehavior.NeverUnderline
            };


            //linkDashboard.Click += (s, e) =>
            //{
            //    // Reload this same dashboard control
            //    parentForm.UserPanel.Controls.Clear();
            //    UserDashboard dashboard = new UserDashboard(lblUsername.Text.Replace("Welcome! ", ""), userID, parentForm)
            //    {
            //        Dock = DockStyle.Fill
            //    };
            //    parentForm.UserPanel.Controls.Add(dashboard);
            //};

            breadcrumbPanel.Controls.Add(linkDashboard);
            breadcrumbPanel.Controls.Add(lblSeparator);
            breadcrumbPanel.Controls.Add(lblCurrentPage);
            this.Controls.Add(breadcrumbPanel);
            breadcrumbPanel.BringToFront();

            this.userID = userID;
            this.parentForm = parent;

            DatabaseHelper db = new DatabaseHelper();

            lblUsername.Text = "Welcome! " + fullName;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUserCredit.Text = "Credit Score: " + db.GetUserCreditBalance(userID).ToString("N0");
            lblUserCredit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            
        }




        private void btnApplyLoan_Click(object sender, EventArgs e)
        {
            parentForm.UserPanel.Controls.Clear();
            string cleanUsername = lblUsername.Text.Replace("Welcome! ", "").Trim();
            LoanApplicationForm loanForm = new LoanApplicationForm(parentForm.UserID, parentForm.Status, cleanUsername, parentForm)
            {
                Dock = DockStyle.Fill
            };
            parentForm.UserPanel.Controls.Add(loanForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            parentForm.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void LoadUserLoans()
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable loans = db.GetActiveLoansByUser(userID);
            dgvUserLoans.DataSource = loans;
        }

        private void SetupUserLoanGrid()
        {

            dgvUserLoans.AllowUserToAddRows = false;
            // Remove existing event handlers to prevent duplication
            dgvUserLoans.CellPainting -= dgvUserLoans_CellPainting;
            dgvUserLoans.CellClick -= dgvUserLoans_CellClick;

            dgvUserLoans.Columns.Clear();

            // Fetch data
            DatabaseHelper DB = new DatabaseHelper();
            dgvUserLoans.DataSource = DB.GetActiveLoansByUser(userID);
            dgvUserLoans.ReadOnly = true;

            // GENERAL GRID SETTINGS
            dgvUserLoans.BackgroundColor = Color.FromArgb(25, 30, 54);
            dgvUserLoans.BorderStyle = BorderStyle.None;
            dgvUserLoans.GridColor = Color.FromArgb(45, 50, 70);
            dgvUserLoans.EnableHeadersVisualStyles = false;
            dgvUserLoans.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            
            // HEADER STYLE
            dgvUserLoans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 40, 64);
            dgvUserLoans.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUserLoans.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            dgvUserLoans.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvUserLoans.GridColor = Color.FromArgb(45, 50, 70);
            dgvUserLoans.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            dgvUserLoans.ColumnHeadersHeight = 35;

            // CELL STYLE
            dgvUserLoans.DefaultCellStyle.BackColor = Color.FromArgb(25, 30, 54);
            dgvUserLoans.DefaultCellStyle.ForeColor = Color.White;
            dgvUserLoans.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 60, 90);
            dgvUserLoans.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUserLoans.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvUserLoans.RowTemplate.Height = 60;
            dgvUserLoans.RowHeadersVisible = false;
            dgvUserLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Hide internal column
            if (dgvUserLoans.Columns.Contains("LoanID"))
                dgvUserLoans.Columns["LoanID"].Visible = false;

            // Only add the action column if it doesn't exist
            if (!dgvUserLoans.Columns.Contains("ActionColumn"))
            {
                DataGridViewTextBoxColumn actionCol = new DataGridViewTextBoxColumn
                {
                    Name = "ActionColumn",
                    HeaderText = "Action",
                    ReadOnly = true
                };
                dgvUserLoans.Columns.Add(actionCol);
            }

            // Add event handlers
            dgvUserLoans.CellPainting += dgvUserLoans_CellPainting;
            dgvUserLoans.CellClick += dgvUserLoans_CellClick;
        }

        // Custom paint logic for "View" and "Pay" stacked buttons
        private void dgvUserLoans_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvUserLoans.Columns["ActionColumn"].Index)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;

                Rectangle cellBounds = e.CellBounds;

                int buttonHeight = (cellBounds.Height - 15) / 2;
                Rectangle viewRect = new Rectangle(cellBounds.X + 10, cellBounds.Y + 5, cellBounds.Width - 20, buttonHeight);
                Rectangle payRect = new Rectangle(cellBounds.X + 10, cellBounds.Y + buttonHeight + 10, cellBounds.Width - 20, buttonHeight);

                int radius = 10;

                using (GraphicsPath viewPath = GetRoundPath(viewRect, radius))
                using (GraphicsPath payPath = GetRoundPath(payRect, radius))
                using (SolidBrush viewBrush = new SolidBrush(Color.FromArgb(52, 152, 219))) // View color
                using (SolidBrush payBrush = new SolidBrush(Color.FromArgb(46, 204, 113)))  // Pay color
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                using (Font btnFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    typeof(DataGridView).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                    null, dgvUserLoans, new object[] { true });


                    // Draw View button
                    e.Graphics.FillPath(viewBrush, viewPath);
                    e.Graphics.DrawString("View", btnFont, textBrush, viewRect, format);

                    // Draw Pay button
                    e.Graphics.FillPath(payBrush, payPath);
                    e.Graphics.DrawString("Pay", btnFont, textBrush, payRect, format);
                }
            }
        }

        private void dgvUserLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvUserLoans.Columns["ActionColumn"].Index)
            {
                Rectangle cellBounds = dgvUserLoans.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                int buttonHeight = (cellBounds.Height - 10) / 2;

                Point mousePos = dgvUserLoans.PointToClient(Cursor.Position);
                int relativeY = mousePos.Y - cellBounds.Y;

                int loanId = Convert.ToInt32(dgvUserLoans.Rows[e.RowIndex].Cells["LoanID"].Value);
                decimal monthlyPayment = Convert.ToDecimal(dgvUserLoans.Rows[e.RowIndex].Cells["Monthly Payment"].Value);
                DatabaseHelper db = new DatabaseHelper();
                decimal creditBalance = db.GetUserCreditBalance(userID);

                if (relativeY <= buttonHeight + 5)
                {
                    // View clicked
                    PaymentHistory historyForm = new PaymentHistory(loanId);
                    historyForm.ShowDialog();
                }
                else
                {
                    // Pay clicked
                    string message = $"Monthly Payment: ₱{monthlyPayment:N2}\n\nDo you want to proceed with this payment?";
                    DialogResult result = MessageBox.Show(message, "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (creditBalance < monthlyPayment)
                        {
                            MessageBox.Show("Insufficient credit balance to make this payment.", "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        bool paymentSuccess = db.AddPaymentAndUpdateLoan(userID, loanId, monthlyPayment);
                        if (paymentSuccess)
                        {
                            MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SetupUserLoanGrid();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while processing the payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }



        private void UserDashboard_Load(object sender, EventArgs e)
        {
            LoadUserLoans();
            SetupUserLoanGrid();
        }



        private void btnBacktoUserLoanTable_Click(object sender, EventArgs e)
        {
            LoadUserLoans();
        }

        private void lblUserCredit_Click(object sender, EventArgs e)
        {

        }
    }
}