using QuizGame.Controllers;
using QuizGame.Models.Connection;
using QuizGame.Models;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace QuizGame.Views
{
    public partial class frmRegistration : Form

    {
        private void ResendActivationCode(string email)
        {
            // Tạo mã kích hoạt mới
            Guid newActivationCode = Guid.NewGuid();

            Connection connection = new Connection();
            string updateQuery = "UPDATE Users SET ActivationCode = @ActivationCode WHERE Email = @Email";

            SqlParameter[] updateParameters = new SqlParameter[]
            {
        new SqlParameter("@ActivationCode", newActivationCode),
        new SqlParameter("@Email", email)
            };

            try
            {
                connection.OpenConnection();
                connection.ExecuteNonQueryWithParams(updateQuery, updateParameters);
                connection.CloseConnection();

                // Gửi email kích hoạt
                SendMailController sendMailController = new SendMailController();
                string subject = "Resend Activation Code - QuizApp";
                string activationLink = $"Active Token: {newActivationCode}";
                string content = $"Hello,<br/>We noticed that your account is not activated yet.<br/>" +
                                 $"Please Enter Active Token {activationLink}";

                sendMailController.SendMail(email, subject, content);

                MessageBox.Show("A new activation email has been sent. Please check your inbox.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmActivation activationForm = new frmActivation(email); // Truyền email để hỗ trợ hiển thị hoặc logic kích hoạt
                activationForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to resend activation email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmRegistration(string email) : this()
        {
            txtEmail.Text = email; // Hiển thị email đã nhập trước đó
            txtEmail.Enabled = false; // Không cho phép chỉnh sửa email

            // Kiểm tra email trong cơ sở dữ liệu
            Connection connection = new Connection();
            string query = "SELECT IsActivated FROM Users WHERE Email = @Email";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Email", email)
            };

            try
            {
                connection.OpenConnection();
                var result = connection.ExecuteScalar(query, parameters);
                connection.CloseConnection();

                if (result != null && !(bool)result) // Tài khoản tồn tại nhưng chưa kích hoạt
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "Your account exists but is not activated. Do you want to resend the activation email?",
                        "Account Not Activated",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Gửi lại mã kích hoạt
                        ResendActivationCode(email);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmRegistration()
        {
            InitializeComponent();
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            cmbGender.SelectedIndex = 0;
            txtPassword.PasswordChar = '*';
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




        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các trường
            string fullName = txtFullName.Text.Trim();
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            string gender = cmbGender.SelectedItem.ToString();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = "user";

            // Kiểm tra hợp lệ
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash mật khẩu
            string hashedPassword = ComputeSha256Hash(password);

            // Tạo mã kích hoạt
            Guid activationCode = Guid.NewGuid();
              
            // Tạo kết nối cơ sở dữ liệu
            Connection connection = new Connection();

            if (!string.IsNullOrEmpty(email))
            {
                string query_1 = "SELECT IsActivated FROM Users WHERE Email = @Email";
                SqlParameter[] parameters_1 = new SqlParameter[]
                {
        new SqlParameter("@Email", email)
                };

                try
                {
                    connection.OpenConnection();
                    var result = connection.ExecuteScalar(query_1, parameters_1);
                    connection.CloseConnection();

                    if (result != null)
                    {
                        if (!(bool)result) // Tài khoản tồn tại nhưng chưa kích hoạt
                        {
                            DialogResult dialogResult = MessageBox.Show(
                                "This email is already registered but not activated. Do you want to resend the activation email?",
                                "Account Not Activated",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (dialogResult == DialogResult.Yes)
                            {
                                ResendActivationCode(email);
                            }

                            return; // Không thực hiện đăng ký mới
                        }
                        else
                        {
                            MessageBox.Show("This email is already registered and activated. Please log in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Không thực hiện đăng ký mới
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string query = "INSERT INTO Users (FullName, DateOfBirth, Gender, Email, Password, Role, ActivationCode, IsActivated) " +
                           "VALUES (@FullName, @DateOfBirth, @Gender, @Email, @Password, @Role, @ActivationCode, 0)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@DateOfBirth", dateOfBirth),
                new SqlParameter("@Gender", gender),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", hashedPassword),
                new SqlParameter("@Role", role),
                new SqlParameter("@ActivationCode", activationCode)
            };

            try
            {
                // Lưu vào cơ sở dữ liệu
                connection.ExecuteNonQueryWithParams(query, parameters);

                // Gửi email kích hoạt
                SendMailController sendMailController = new SendMailController();
                string subject = "Account Activation - QuizApp";
                string activationLink = $"{activationCode}";
                string content = $"Hello {fullName},<br/>Please click the link below to activate your account:{activationLink}";
                sendMailController.SendMail(email, subject, content);

                MessageBox.Show("Registration successful! Please check your email to activate your account.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển sang frmActivation
                frmActivation activationForm = new frmActivation(email); // Truyền email để hỗ trợ hiển thị hoặc logic kích hoạt
                activationForm.Show();
                this.Hide();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed! Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }
    }


}
