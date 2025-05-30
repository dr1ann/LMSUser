using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LMSUser.DatabaseHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
namespace LMSUser
{
    internal class DatabaseHelper
    {
        // Replace with your actual SQL Server connection string
        //private readonly string connectionString = "Server=LAPTOP-GHQG6N7F\\SQLEXPRESS01;Database=DB_KASALIGAN_LOAN_SYSTEM;Trusted_Connection=True;";
        private readonly string connectionString = "Server=DESKTOP-0TPQ7D6\\SQLEXPRESS01;Database=DB_KASALIGAN_LOAN_SYSTEM;Trusted_Connection=True;";

        // Method to get SQL Connection
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Method to execute INSERT, UPDATE, DELETE queries
        public bool ExecuteQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Method to check if a value exists in a table (e.g., check if phone number already exists)
        public bool ValueExists(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        object result = cmd.ExecuteScalar();
                        return result != null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool ValidateLogin(string username, string password)
        {
            string query = "SELECT COUNT(1) FROM Users WHERE Username = @username AND PasswordHash = @password";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password); // In real apps, use hashing!

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public string GetFullName(string username, string password)
        {
            string fullName = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName FROM Users WHERE Username = @Username AND PasswordHash = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            fullName = $"{firstName} {lastName}";
                        }
                    }
                }
            }
            return fullName;
        }
        public string GetStatus(string username, string password)
        {
            string status = ""; // Renamed variable to avoid conflict
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Status FROM Users WHERE Username = @Username AND PasswordHash = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            status = reader["Status"].ToString(); // Use the renamed variable
                        }
                    }
                }
            }
            return status;
        }


        public int GetUserID(string username, string password)
        {
            int userID = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID FROM Users WHERE Username = @Username AND PasswordHash = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userID = Convert.ToInt32(reader["UserID"]);
                        }
                    }
                }
            }
            return userID;
        }

        public decimal GetUserCreditBalance(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CreditBalance FROM Users WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0m;
                }
            }
        }

        public bool InsertLoan(int userID, decimal amount, int term, string loanPurpose, decimal monthlyPayment, decimal newBalance, decimal interest, Image validID, Image proofOfIncome)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    byte[] idBytes = ImageToByteArray(validID);
                    byte[] proofBytes = ImageToByteArray(proofOfIncome);

                    string query = @"
        INSERT INTO Loan 
        (UserID, Amount, Term, LoanPurpose, MonthlyPayment, Status, NewBalance, Interest, ValidID, ProofOfIncome)
        VALUES 
        (@UserID, @Amount, @Term, @LoanPurpose, @MonthlyPayment, @Status, @NewBalance, @Interest, @ValidID, @ProofOfIncome)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Term", term);
                        cmd.Parameters.AddWithValue("@LoanPurpose", loanPurpose);
                        cmd.Parameters.AddWithValue("@MonthlyPayment", monthlyPayment);
                        cmd.Parameters.AddWithValue("@Status", "Pending");
                        cmd.Parameters.AddWithValue("@NewBalance", newBalance);
                        cmd.Parameters.AddWithValue("@Interest", interest);
                        cmd.Parameters.AddWithValue("@ValidID", idBytes);
                        cmd.Parameters.AddWithValue("@ProofOfIncome", proofBytes);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting loan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public bool SaveUserImages(int userID, Image validID, Image proofOfIncome)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Convert images to byte arrays
                byte[] idBytes = ImageToByteArray(validID);
                byte[] proofBytes = ImageToByteArray(proofOfIncome);

                string query = @"UPDATE Users 
                         SET ValidID = @ValidID, ProofOfIncome = @Proof 
                         WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ValidID", idBytes);
                    cmd.Parameters.AddWithValue("@Proof", proofBytes);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool UserHasUploadedDocuments(int userId)
        {
            string query = "SELECT ValidId, ProofOfIncome FROM Users WHERE UserID = @UserID";
            SqlParameter[] parameters = {
        new SqlParameter("@UserID", userId)
    };

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        object idImage = reader["ValidId"];
                        object proofImage = reader["ProofOfIncome"];

                        return idImage != DBNull.Value && proofImage != DBNull.Value;
                    }
                }
            }

            return false;
        }

        public decimal GetLoanRemainingBalance(int loanId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT NewBalance FROM Loan WHERE LoanID = @LoanID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoanID", loanId);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }


        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }


        public DataTable GetActiveLoansByUser(int userId)
        {
            DataTable dt = new DataTable();

            string query = @"  
SELECT  
    l.LoanID, -- Include but won't display  
    l.Amount AS [Principal],  
    l.LoanPurpose AS [Loan Purpose],  
    l.monthlyPayment AS [Monthly Payment],  
    l.Term,  
    l.Status  
FROM  
    Loan l  
WHERE  
    l.Status IN ('Completed', 'Disbursed') AND l.UserID = @UserID";


            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }
        public bool AddPaymentAndUpdateLoan(int userId, int loanId, decimal monthlyPayment)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {

                    // Check if loan is already fully paid
                    string balanceQuery = "SELECT NewBalance FROM Loan WHERE LoanID = @LoanID";
                    SqlCommand cmdBalance = new SqlCommand(balanceQuery, conn, transaction);
                    cmdBalance.Parameters.AddWithValue("@LoanID", loanId);
                    decimal currentBalance = Convert.ToDecimal(cmdBalance.ExecuteScalar());

                    if (currentBalance <= 0)
                    {
                        MessageBox.Show("This loan has already been fully paid.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        transaction.Rollback();
                        return false;
                    }





                    // Get loan disbursement date (start date for payments)
                    string getLoanDate = "SELECT DisbursedAt FROM Disbursement WHERE LoanID = @LoanID";
                    SqlCommand cmdDate = new SqlCommand(getLoanDate, conn, transaction);
                    cmdDate.Parameters.AddWithValue("@LoanID", loanId);
                    DateTime loanStartDate = Convert.ToDateTime(cmdDate.ExecuteScalar());


                    // Count existing payments
                    string countQuery = "SELECT COUNT(*) FROM Payments WHERE LoanID = @LoanID";
                    SqlCommand cmdCount = new SqlCommand(countQuery, conn, transaction);
                    cmdCount.Parameters.AddWithValue("@LoanID", loanId);
                    int paymentsMade = (int)cmdCount.ExecuteScalar();

                    // Compute due date for current payment
                    DateTime expectedDueDate = loanStartDate.AddMonths(paymentsMade);
                    DateTime today = DateTime.Now;

                    string remark;
                    if (today.Date < expectedDueDate.Date)
                        remark = "Early";
                    else if (today.Date == expectedDueDate.Date)
                        remark = "On Time";
                    else
                        remark = "Late";

                    // Get user's credit balance
                    string creditQuery = "SELECT CreditBalance FROM [Users] WHERE UserID = @UserID";
                    SqlCommand cmdCredit = new SqlCommand(creditQuery, conn, transaction);
                    cmdCredit.Parameters.AddWithValue("@UserID", userId);
                    decimal creditBalance = Convert.ToDecimal(cmdCredit.ExecuteScalar());

                    if (creditBalance < monthlyPayment)
                    {
                        MessageBox.Show("Insufficient credit balance for this payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return false;
                    }

                    // Subtract from user's credit balance
                    string updateUser = @"UPDATE [Users]
                          SET CreditBalance = CreditBalance - @MonthlyPayment
                          WHERE UserID = @UserID";
                    SqlCommand cmdUser = new SqlCommand(updateUser, conn, transaction);
                    cmdUser.Parameters.AddWithValue("@MonthlyPayment", monthlyPayment);
                    cmdUser.Parameters.AddWithValue("@UserID", userId);
                    cmdUser.ExecuteNonQuery();

                    // Subtract from loan's new balance
                    string updateLoan = @"UPDATE Loan
                          SET NewBalance = NewBalance - @MonthlyPayment
                          WHERE LoanID = @LoanID";
                    SqlCommand cmdLoan = new SqlCommand(updateLoan, conn, transaction);
                    cmdLoan.Parameters.AddWithValue("@MonthlyPayment", monthlyPayment);
                    cmdLoan.Parameters.AddWithValue("@LoanID", loanId);
                    cmdLoan.ExecuteNonQuery();





                    // Update admin wallet (assuming it has a TotalBalance column)
                    string updateAdminWallet = @"UPDATE AdminWallet
                     SET TotalBalance = TotalBalance + @Amount,
                         LastUpdated = GETDATE()";
                    SqlCommand cmdAdminWallet = new SqlCommand(updateAdminWallet, conn, transaction);
                    cmdAdminWallet.Parameters.AddWithValue("@Amount", monthlyPayment);
                    cmdAdminWallet.ExecuteNonQuery();





                    // Insert payment record
                    string insertPayment = @"INSERT INTO Payments (LoanID, Balance, Status, Remarks, PaymentDate)
                 VALUES (@LoanID, @Balance, 'Paid', @Remarks, GETDATE())";

                    SqlCommand cmdPayment = new SqlCommand(insertPayment, conn, transaction);
                    cmdPayment.Parameters.AddWithValue("@LoanID", loanId);
                    cmdPayment.Parameters.AddWithValue("@Balance", monthlyPayment);
                    cmdPayment.Parameters.AddWithValue("@Remarks", remark);
                    cmdPayment.ExecuteNonQuery();

                    // ✅ Now check if the loan is fully paid and mark as Completed
                    string checkBalance = "SELECT NewBalance FROM Loan WHERE LoanID = @LoanID";
                    SqlCommand cmdCheck = new SqlCommand(checkBalance, conn, transaction);
                    cmdCheck.Parameters.AddWithValue("@LoanID", loanId);
                    decimal remainingBalance = Convert.ToDecimal(cmdCheck.ExecuteScalar());

                    if (remainingBalance <= 0)
                    {
                        string updateStatus = "UPDATE Loan SET Status = 'Completed' WHERE LoanID = @LoanID";
                        SqlCommand cmdStatus = new SqlCommand(updateStatus, conn, transaction);
                        cmdStatus.Parameters.AddWithValue("@LoanID", loanId);
                        cmdStatus.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error processing payment: " + ex.Message);
                    return false;
                }


            }
        }


        //public bool AddPaymentAndUpdateLoan(int userId, int loanId, decimal monthlyPayment)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        SqlTransaction transaction = conn.BeginTransaction();

        //        try
        //        {



        //            // Get loan disbursement date (start date for payments)
        //            string getLoanDate = "SELECT DisbursedAt FROM Disbursement WHERE LoanID = @LoanID";
        //            SqlCommand cmdDate = new SqlCommand(getLoanDate, conn, transaction);
        //            cmdDate.Parameters.AddWithValue("@LoanID", loanId);
        //            DateTime loanStartDate = Convert.ToDateTime(cmdDate.ExecuteScalar());


        //            // Count existing payments
        //            string countQuery = "SELECT COUNT(*) FROM Payments WHERE LoanID = @LoanID";
        //            SqlCommand cmdCount = new SqlCommand(countQuery, conn, transaction);
        //            cmdCount.Parameters.AddWithValue("@LoanID", loanId);
        //            int paymentsMade = (int)cmdCount.ExecuteScalar();

        //            // Compute due date for current payment
        //            DateTime expectedDueDate = loanStartDate.AddMonths(paymentsMade);
        //            DateTime today = DateTime.Now;

        //            string remark;
        //            if (today.Date < expectedDueDate.Date)
        //                remark = "Early";
        //            else if (today.Date == expectedDueDate.Date)
        //                remark = "On Time";
        //            else
        //                remark = "Late";

        //            // Get user's credit balance
        //            string creditQuery = "SELECT CreditBalance FROM [Users] WHERE UserID = @UserID";
        //            SqlCommand cmdCredit = new SqlCommand(creditQuery, conn, transaction);
        //            cmdCredit.Parameters.AddWithValue("@UserID", userId);
        //            decimal creditBalance = Convert.ToDecimal(cmdCredit.ExecuteScalar());

        //            if (creditBalance < monthlyPayment)
        //            {
        //                MessageBox.Show("Insufficient credit balance for this payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                transaction.Rollback();
        //                return false;
        //            }

        //            // Subtract from user's credit balance
        //            string updateUser = @"UPDATE [Users]
        //                  SET CreditBalance = CreditBalance - @MonthlyPayment
        //                  WHERE UserID = @UserID";
        //            SqlCommand cmdUser = new SqlCommand(updateUser, conn, transaction);
        //            cmdUser.Parameters.AddWithValue("@MonthlyPayment", monthlyPayment);
        //            cmdUser.Parameters.AddWithValue("@UserID", userId);
        //            cmdUser.ExecuteNonQuery();

        //            // Subtract from loan's new balance
        //            string updateLoan = @"UPDATE Loan
        //                  SET NewBalance = NewBalance - @MonthlyPayment
        //                  WHERE LoanID = @LoanID";
        //            SqlCommand cmdLoan = new SqlCommand(updateLoan, conn, transaction);
        //            cmdLoan.Parameters.AddWithValue("@MonthlyPayment", monthlyPayment);
        //            cmdLoan.Parameters.AddWithValue("@LoanID", loanId);
        //            cmdLoan.ExecuteNonQuery();





        //            // Update admin wallet (assuming it has a TotalBalance column)
        //            string updateAdminWallet = @"UPDATE AdminWallet
        //             SET TotalBalance = TotalBalance + @Amount,
        //                 LastUpdated = GETDATE()";
        //            SqlCommand cmdAdminWallet = new SqlCommand(updateAdminWallet, conn, transaction);
        //            cmdAdminWallet.Parameters.AddWithValue("@Amount", monthlyPayment);
        //            cmdAdminWallet.ExecuteNonQuery();





        //            // Insert payment record
        //            string insertPayment = @"INSERT INTO Payments (LoanID, Balance, Status, Remarks, PaymentDate)
        //         VALUES (@LoanID, @Balance, 'Paid', @Remarks, GETDATE())";

        //            SqlCommand cmdPayment = new SqlCommand(insertPayment, conn, transaction);
        //            cmdPayment.Parameters.AddWithValue("@LoanID", loanId);
        //            cmdPayment.Parameters.AddWithValue("@Balance", monthlyPayment);
        //            cmdPayment.Parameters.AddWithValue("@Remarks", remark);
        //            cmdPayment.ExecuteNonQuery();

        //            transaction.Commit();
        //            return true;


        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            MessageBox.Show("Error processing payment: " + ex.Message);
        //            return false;
        //        }


        //    }
        //}


        public DataTable GetPaymentHistoryByLoanId(int loanId)
        {
            DataTable dt = new DataTable();

            string query = @"
SELECT 
    ps.MonthIndex,
    FORMAT(ps.DueDate, 'yyyy-MM-dd') AS [Due Date],
    FORMAT(p.PaymentDate, 'yyyy-MM-dd') AS [Payment Date],
    ps.MonthlyPayment AS [Monthly Payment],
    ps.ScheduledBalance AS [Balance],
    ISNULL(p.Status, 'Not yet paid') AS [Status],
    ISNULL(p.Remarks, '') AS [Remarks]
FROM PaymentSchedule ps
LEFT JOIN (
    SELECT 
        ROW_NUMBER() OVER (ORDER BY PaymentDate) AS PaymentIndex,
        PaymentDate,
        Status,
        Remarks,
        LoanID
    FROM Payments
    WHERE LoanID = @LoanID
) p ON ps.LoanID = p.LoanID AND ps.MonthIndex = p.PaymentIndex
WHERE ps.LoanID = @LoanID
ORDER BY ps.MonthIndex;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LoanID", loanId);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving generated payment schedule: " + ex.Message);
            }

            return dt;
        }


        public void AddUserCreditBalance(int userId, decimal amountToAdd)
        {
            string query = @"
        UPDATE Users
        SET CreditBalance = ISNULL(CreditBalance, 0) + @Amount
        WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Amount", amountToAdd);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public decimal GetUserMaxLoanAmount(int userId)
        {
          
            string query = "SELECT max_loan_amount FROM Users WHERE userID = @UserID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null && decimal.TryParse(result.ToString(), out decimal maxAmount))
                {
                    return maxAmount;
                }
                else
                {
                    throw new Exception("Unable to retrieve max loan amount for the user.");
                }
            }
        }


        public decimal GetCurrentInterestRate()
        {
            decimal rate = 0.10m; // fallback value

            string query = "SELECT TOP 1 Rate FROM Interest ORDER BY ID DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    rate = Convert.ToDecimal(result);
                }
            }

            return rate;
        }










    }
}
