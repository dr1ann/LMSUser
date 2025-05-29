using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMSUser
{
    public partial class PaymentHistory : Form
    {
        private int loanId;

        public PaymentHistory(int loanId)
        {
            InitializeComponent();
            this.loanId = loanId;
        }

        private void PaymentHistory_Load(object sender, EventArgs e)
        {
            LoadPaymentHistory();
        }

        private void LoadPaymentHistory()
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable dt = db.GetPaymentHistoryByLoanId(loanId);
            dgvPaymentHistory.DataSource = dt;

            // Hide internal ID
            if (dgvPaymentHistory.Columns.Contains("PaymentID"))
                dgvPaymentHistory.Columns["PaymentID"].Visible = false;

            // GENERAL GRID SETTINGS
            dgvPaymentHistory.BackgroundColor = Color.FromArgb(25, 30, 54);
            dgvPaymentHistory.BorderStyle = BorderStyle.None;
            dgvPaymentHistory.GridColor = Color.FromArgb(45, 50, 70);
            dgvPaymentHistory.EnableHeadersVisualStyles = false;
            dgvPaymentHistory.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // HEADER STYLE
            dgvPaymentHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 40, 64);
            dgvPaymentHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPaymentHistory.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            dgvPaymentHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPaymentHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            dgvPaymentHistory.ColumnHeadersHeight = 35;

            // CELL STYLE
            dgvPaymentHistory.DefaultCellStyle.BackColor = Color.FromArgb(25, 30, 54);
            dgvPaymentHistory.DefaultCellStyle.ForeColor = Color.White;
            dgvPaymentHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 60, 90);
            dgvPaymentHistory.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPaymentHistory.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPaymentHistory.RowTemplate.Height = 60;
            dgvPaymentHistory.RowHeadersVisible = false;
            dgvPaymentHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



    }
}