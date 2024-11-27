using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using QuizGame.Models.Connection;
namespace QuizGame.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your email address and password.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = ComputeSha256Hash(password);

            using (Connection conn = new Connection())
            {
                // Sửa query để kiểm tra trạng thái kích hoạt
                string query = "SELECT UserId, FullName, Role, IsActivated FROM Users WHERE Email = @Email AND Password = @Password";

                SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@Email", email),
            new SqlParameter("@Password", hashedPassword)
        };

                using (SqlDataReader reader = conn.ExecuteReader(query, parameters))
                {
                    if (reader.Read())
                    {
                        // Check if IsActivated is DBNull, and handle it accordingly
                        bool isActivated = reader.IsDBNull(reader.GetOrdinal("IsActivated"))
                                            ? false // or true depending on your logic
                                            : (bool)reader["IsActivated"];

                        if (!isActivated)
                        {
                            MessageBox.Show("Your account is not activated. Please check your email for the activation link.", "Account Not Activated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng lại nếu tài khoản chưa được kích hoạt
                        }

                        // Tiếp tục nếu tài khoản đã được kích hoạt
                        int userId = (int)reader["UserId"];
                        string role = reader["Role"].ToString();
                        string name = reader["FullName"].ToString();

                        if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        {
                            frmAdmin adminForm = new frmAdmin();
                            adminForm.AdminName = name;
                            adminForm.Show();
                        }
                        else
                        {
                            frmHome homeForm = new frmHome();
                            homeForm.UserName = name;
                            homeForm.SetCurrentUserId(userId);
                            homeForm.Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Email address or password is incorrect.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegistration frmRegistration = new frmRegistration();
            frmRegistration.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mở form quên mật khẩu
            frmForgotPassword forgotPasswordForm = new frmForgotPassword();
            forgotPasswordForm.Show();
            this.Hide(); // Ẩn form đăng nhập khi chuyển qua form quên mật khẩu
        }
    }
}
