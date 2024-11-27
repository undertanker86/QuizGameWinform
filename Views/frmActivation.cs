using QuizGame.Models.Connection;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuizGame.Views
{
    public partial class frmActivation : Form
    {
        private string userEmail; // Save email user
        private bool isPasswordReset; // Kiểm tra xem có phải quá trình reset mật khẩu không

        public frmActivation(string email, bool isPasswordReset = false)
        {
            InitializeComponent();
            userEmail = email;
            this.isPasswordReset = isPasswordReset;
            // Nếu là quá trình reset mật khẩu, có thể hiển thị thông báo khác
            if (isPasswordReset)
            {
                lblMessage.Text = "Please enter the reset token sent to your email.";
            }
            else
            {
                lblMessage.Text = "Please enter the activation code sent to your email.";
            }
        }



        // Xử lý khi người dùng nhấn nút Activate
        private void btnActivate_Click(object sender, EventArgs e)
        {
            string activationCodeInput = txtActivationCode.Text.Trim();

            if (string.IsNullOrEmpty(activationCodeInput))
            {
                MessageBox.Show("Please enter the activation code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Guid activationCode = Guid.Parse(activationCodeInput);
                Connection connection = new Connection();

                // Nếu là reset mật khẩu, sẽ kiểm tra ResetToken thay vì ActivationCode
                string query = isPasswordReset
                    ? "SELECT UserId FROM Users WHERE ResetToken = @ResetToken AND Email = @Email AND ResetTokenExpiry > GETDATE()"
                    : "SELECT UserId FROM Users WHERE ActivationCode = @ActivationCode AND Email = @Email AND IsActivated = 0";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ActivationCode", activationCode),
                    new SqlParameter("@Email", userEmail)
                };

                if (isPasswordReset)
                {
                    // Cập nhật câu truy vấn cho trường hợp reset password
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@ResetToken", activationCode),
                        new SqlParameter("@Email", userEmail)
                    };
                }

                connection.OpenConnection();
                var result = connection.ExecuteScalar(query, parameters);
                connection.CloseConnection();

                if (result != null)
                {
                    if (isPasswordReset)
                    {
                        // Nếu là reset mật khẩu, chuyển đến form nhập mật khẩu mới
                        frmResetPassword resetPasswordForm = new frmResetPassword(activationCode);
                        resetPasswordForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Nếu là kích hoạt tài khoản, cập nhật trạng thái tài khoản
                        string updateQuery = "UPDATE Users SET IsActivated = 1 WHERE ActivationCode = @ActivationCode AND Email = @Email";
                        connection.OpenConnection();
                        int rowsAffected = connection.ExecuteNonQuery(updateQuery, parameters);
                        connection.CloseConnection();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your account has been successfully activated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmLogin loginForm = new frmLogin();
                            loginForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Activation failed. The code may be invalid or already activated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(isPasswordReset ? "Invalid reset token or expired." : "Invalid activation code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid activation code format. Please check again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý khi người dùng nhấn nút Back
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (isPasswordReset)
            {
                // Nếu là quá trình reset mật khẩu, chuyển về form quên mật khẩu
                frmForgotPassword forgotPasswordForm = new frmForgotPassword();
                forgotPasswordForm.Show();
            }
            else
            {
                // Nếu là quá trình kích hoạt tài khoản, chuyển về form đăng ký
                frmRegistration registrationForm = new frmRegistration();
                registrationForm.Show();
            }
            this.Hide(); // Ẩn form hiện tại
        }
    }
}
