using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMSUser
{
    public partial class RegisterUser : UserControl
    {
        private LoginForm parentForm;
        public RegisterUser(LoginForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }


        private DatabaseHelper dbHelper = new DatabaseHelper(); // Create an instance of DatabaseHelper

        public object BCrypt { get; private set; }

        private void RegUser_Click(object sender, EventArgs e)
        {
            // Step 1: Retrieve input values
            string firstName = tbFName.Text.Trim();
            string lastName = tbLName.Text.Trim();
            string phoneNumber = tbPhoneNumber.Text.Trim();
            string address = tbAddress.Text.Trim();
            DateTime dateOfBirth = DOB.SelectedDate;
            string employmentStatus = cmbEmploymentStatus.SelectedItem?.ToString();
            string monthlyIncome = tbMonthlyIncome.Text.Trim();
            string Username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            // Step 2: Validate inputs
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(address) || string.IsNullOrEmpty(employmentStatus) || string.IsNullOrEmpty(monthlyIncome) ||
                string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!phoneNumber.All(char.IsDigit) || phoneNumber.Length != 11)
            {
                MessageBox.Show("Phone number must be exactly 11 digits and numeric only.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-age)) age--; // Correct for leap year offset
            if (age < 18)
            {
                MessageBox.Show("User must be at least 18 years old.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(monthlyIncome, out decimal incomeValue))
            {
                MessageBox.Show("Monthly Income must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Step 3: Check if Phone Number, Username, or Full Name + DOB combination already exists
            string checkQuery = @"SELECT 1 FROM Users 
                      WHERE PhoneNumber = @PhoneNumber 
                         OR Username = @Username
                         OR (FirstName = @FirstName AND LastName = @LastName AND DateOfBirth = @DateOfBirth)";
            SqlParameter[] checkParams =
            {
                new SqlParameter("@PhoneNumber", phoneNumber),
                new SqlParameter("@Username", Username),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@DateOfBirth", dateOfBirth)
            };

            if (dbHelper.ValueExists(checkQuery, checkParams))
            {
                MessageBox.Show("Phone number, username, or a user with the same full name and date of birth already exists!",
                                "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // Step 4: Hash password
            // string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Step 5: Insert User into Database
            string insertQuery = @"INSERT INTO Users (FirstName, LastName, PhoneNumber, Address, DateOfBirth, EmploymentStatus, MonthlyIncome, Username, passwordHash)
                                   VALUES (@FirstName, @LastName, @PhoneNumber, @Address, @DateOfBirth, @EmploymentStatus, @MonthlyIncome, @Username, @PasswordHash)";

            SqlParameter[] insertParams =
            {
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@PhoneNumber", phoneNumber),
                new SqlParameter("@Address", address),
                new SqlParameter("@DateOfBirth", dateOfBirth),
                new SqlParameter("@EmploymentStatus", employmentStatus),
                new SqlParameter("@MonthlyIncome", incomeValue),
                new SqlParameter("@Username", Username),
                new SqlParameter("@PasswordHash", password)
            };



            if (dbHelper.ExecuteQuery(insertQuery, insertParams))
            {
                MessageBox.Show("Registration Successful!", "Success",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);



                parentForm.LoginPanel.Controls.Clear(); // ✅ use the stored reference
                UserLogin UserLogin = new UserLogin(parentForm);
                UserLogin.Dock = DockStyle.Fill;
                parentForm.LoginPanel.Controls.Add(UserLogin);



            }
            else
            {
                MessageBox.Show("Registration Failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.LoginPanel.Controls.Clear(); // ✅ use the stored reference
            UserLogin UserLogin = new UserLogin(parentForm);
            UserLogin.Dock = DockStyle.Fill;
            parentForm.LoginPanel.Controls.Add(UserLogin);
        }

        private void tbMonthlyIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control characters like backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Allow only digits
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control characters like backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Allow only digits
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }




        private void tbMonthlyIncome_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(txt.Text)) return;

            string value = txt.Text.Replace(",", "");

            if (decimal.TryParse(value, out decimal number))
            {
                txt.TextChanged -= tbMonthlyIncome_TextChanged; // Avoid recursion
                txt.Text = string.Format("{0:N0}", number);
                txt.SelectionStart = txt.Text.Length; // Move caret to end
                txt.TextChanged += tbMonthlyIncome_TextChanged;
            }
        }







        private void RegisterUser_Load_1(object sender, EventArgs e)
        {

        }

        private void DOB_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}