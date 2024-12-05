using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuizGame.Models.Connection;

namespace QuizGame.Views
{
    public partial class frmEditInfo : Form
    {
        private int userId;

        public frmEditInfo(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadGenderOptions();
            LoadUserInfo();
            txtPassword.PasswordChar = '*';
        }

        private void LoadUserInfo()
        {
            using (var connection = new Connection())
            {
                string query = "SELECT FullName, DateOfBirth, Gender, Email FROM Users WHERE UserId = @UserId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserId", userId)
                };

                DataTable userInfo = connection.ExecuteQuery(query, parameters);
                if (userInfo.Rows.Count > 0)
                {
                    var row = userInfo.Rows[0];
                    txtFullName.Text = row["FullName"].ToString();
                    dtpDateOfBirth.Value = Convert.ToDateTime(row["DateOfBirth"]);
                    cmbGender.SelectedItem = row["Gender"].ToString();
                    txtEmail.Text = row["Email"].ToString(); // Hiển thị email nhưng không cho chỉnh sửa

                    // Làm cho txtEmail không thể chỉnh sửa
                    txtEmail.Enabled = false;
                }
            }
        }

        private void LoadGenderOptions()
        {
            var genders = new List<string> { "Male", "Female", "Other" };

            cmbGender.DataSource = genders;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra mật khẩu mới nếu có thay đổi
            string passwordHash = null;
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                // Mã hóa mật khẩu mới nếu người dùng đã nhập mật khẩu mới
                passwordHash = ComputeSha256Hash(txtPassword.Text);
            }

            string query = "UPDATE Users SET FullName = @FullName, DateOfBirth = @DateOfBirth, Gender = @Gender, Password = @Password WHERE UserId = @UserId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", txtFullName.Text),
                new SqlParameter("@DateOfBirth", dtpDateOfBirth.Value),
                new SqlParameter("@Gender", cmbGender.SelectedItem.ToString()),
                new SqlParameter("@UserId", userId),
                new SqlParameter("@Password", passwordHash ?? (object)DBNull.Value) // Cập nhật mật khẩu nếu có
            };

            using (var connection = new Connection())
            {
                connection.ExecuteNonQueryWithParams(query, parameters);
            }

            MessageBox.Show("Information updated successfully!");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
            this.Close();
        }
        private string ComputeSha256Hash(string rawData)
        {
            using (var sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(rawData));
                var builder = new System.Text.StringBuilder();
                foreach (var byteData in bytes)
                {
                    builder.Append(byteData.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
