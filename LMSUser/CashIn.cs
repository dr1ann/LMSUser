using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LMSUser
{
    public partial class CashIn : UserControl
    {
        private int userID; // Store the user ID
        private UserForm _parentForm;
        public CashIn(int userID, UserForm parentForm)
        {
            InitializeComponent();
            this.userID = userID;

            _parentForm = parentForm;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(tbAmount.Text.Trim(), out decimal amount))
            {
                DatabaseHelper db = new DatabaseHelper();

                // Assuming you have access to the userID here
                db.AddUserCreditBalance(userID, amount);
                MessageBox.Show("Credit balance updated successfully.");
            }
            else
            {
                MessageBox.Show("Invalid amount. Please enter a valid number.");
            }
        }


        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control characters like backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Allow only digits
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox; // Fully qualify TextBox to resolve ambiguity
            if (string.IsNullOrWhiteSpace(txt.Text)) return;

            string value = txt.Text.Replace(",", "");

            if (decimal.TryParse(value, out decimal number))
            {
                txt.TextChanged -= tbAmount_TextChanged; // Avoid recursion
                txt.Text = string.Format("{0:N0}", number);
                txt.SelectionStart = txt.Text.Length; // Move caret to end
                txt.TextChanged += tbAmount_TextChanged;
            }
        }


    }

}
