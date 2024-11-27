using QuizGame.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizGame.Models.Connection;
using QuizGame.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace QuizGame.Views
{
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void SendResetToken(string email, Guid resetToken, DateTime tokenExpiry)
        {
            // Send reset link email to the user
            SendMailController sendMailController = new SendMailController();
            string resetLink = $"{resetToken}";
            string subject = "Password Reset Request";
            string content = $"Hello,<br/>To reset your password, please enter reset token in your app:<br/><b>{resetLink}<b></a><br/>This link will expire on {tokenExpiry}.";
            sendMailController.SendMail(email, subject, content);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void btn_resetpassword_Click(object sender, EventArgs e)
        {
            string email = text_resetPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem email có tồn tại trong cơ sở dữ liệu không
            using (Connection connection = new Connection())
            {
                string query = "SELECT Email FROM Users WHERE Email = @Email";
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Email", email) };

                connection.OpenConnection();
                var result = connection.ExecuteScalar(query, parameters);
                connection.CloseConnection();

                if (result != null)
                {
                    // Nếu email hợp lệ, gửi mã reset và mở form nhập mã kích hoạt
                    Guid resetToken = Guid.NewGuid(); // Tạo reset token
                    DateTime tokenExpiry = DateTime.Now.AddHours(1); // Token hết hạn trong 1 giờ

                    // Gửi mã reset token qua email
                    SendResetToken(email, resetToken, tokenExpiry);

                    // Cập nhật reset token vào cơ sở dữ liệu
                    string updateQuery = "UPDATE Users SET ResetToken = @ResetToken, ResetTokenExpiry = @ResetTokenExpiry WHERE Email = @Email";
                    SqlParameter[] updateParameters = new SqlParameter[]
                    {
                new SqlParameter("@ResetToken", resetToken),
                new SqlParameter("@ResetTokenExpiry", tokenExpiry),
                new SqlParameter("@Email", email)
                    };
                    connection.OpenConnection();
                    connection.ExecuteNonQueryWithParams(updateQuery, updateParameters);
                    connection.CloseConnection();

                    // Mở form nhập mã kích hoạt
                    frmActivation activationForm = new frmActivation(email, isPasswordReset: true); // isPasswordReset = true
                    activationForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("This email is not registered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }
    }

}
