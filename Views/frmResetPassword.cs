using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizGame.Models.Connection;
using QuizGame.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace QuizGame.Views
{
    public partial class frmResetPassword : Form
    {
        private Guid resetToken;

        public frmResetPassword(Guid token)
        {
            InitializeComponent();
            this.resetToken = token;
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private void btn_newPassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Kiểm tra tính hợp lệ của mật khẩu
            if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("The new password and confirmation password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra token có hợp lệ không và chưa hết hạn
            using (Connection connection = new Connection())
            {
                string query = "SELECT ResetTokenExpiry FROM Users WHERE ResetToken = @ResetToken";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ResetToken", resetToken)
                };

                try
                {
                    connection.OpenConnection();
                    var result = connection.ExecuteScalar(query, parameters);
                    connection.CloseConnection();

                    if (result == null)
                    {
                        MessageBox.Show("Invalid or expired reset token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime tokenExpiry = (DateTime)result;
                    if (DateTime.Now > tokenExpiry)
                    {
                        MessageBox.Show("The reset token has expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Hash mật khẩu mới
                    string hashedPassword = ComputeSha256Hash(newPassword);

                    // Cập nhật mật khẩu mới trong cơ sở dữ liệu
                    string updateQuery = "UPDATE Users SET Password = @Password WHERE ResetToken = @ResetToken";
                    SqlParameter[] updateParameters = new SqlParameter[]
                    {
                        new SqlParameter("@Password", hashedPassword),
                        new SqlParameter("@ResetToken", resetToken)
                    };

                    connection.OpenConnection();
                    int rowsAffected = connection.ExecuteNonQuery(updateQuery, updateParameters);
                    connection.CloseConnection();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password has been successfully reset.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Mở lại form login hoặc thực hiện hành động khác
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error occurred while resetting the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

            private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
