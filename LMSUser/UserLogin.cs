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
    public partial class UserLogin : UserControl
    {
        private LoginForm parentForm; // This expects a Login type, not UserForm

        // Constructor updated to accept a Login type
        public UserLogin(LoginForm parent)
        {
            InitializeComponent();
            this.parentForm = parent; // Now correctly assigns a Login instance
        }

        //private void tbUsername_TextChanged(object sender, EventArgs e)
        //{
        //    label5.Visible = false;
        //}

        //private void tbPassword_TextChanged(object sender, EventArgs e)
        //{
        //    label6.Visible = false;
        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            DatabaseHelper db = new DatabaseHelper();
            if (db.ValidateLogin(username, password))
            {
                string fullName = db.GetFullName(username, password);
                string status = db.GetStatus(username, password);
                int userID = db.GetUserID(username, password);
                new UserForm (fullName, status, userID).Show(); // Pass full name

                Form parentForm = this.FindForm(); // gets the Login form
                if (parentForm != null)
                {
                    parentForm.Hide(); // you can also use parentForm.Close(); if you want to close it entirely
                }
            }
            else
            {
                // Invalid login: Show a message indicating that the username or password is incorrect
                MessageBox.Show("Invalid username or password.");
                tbPassword.Text = "";
                tbUsername.Text = "";
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            parentForm.LoginPanel.Controls.Clear(); // ✅ use the stored reference
            RegisterUser regUser = new RegisterUser(parentForm);
            regUser.Dock = DockStyle.Fill;
            parentForm.LoginPanel.Controls.Add(regUser);
        }

        private void labelGreeting_Click(object sender, EventArgs e)
        {

        }
    }
}
