using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using QuizGame.Models.Connection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuizGame.Views
{
    public partial class frmUser : Form
    {
        private Connection connection;

        public frmUser()
        {
            InitializeComponent();
            connection = new Connection();
            LoadUsers();
            LoadGenderOptions();
            LoadRoleOptions();
            txtPassword.PasswordChar = '*';
        }

        private void LoadGenderOptions()
        {
            cbxGender.Items.Add("Male");
            cbxGender.Items.Add("Female");
            cbxGender.Items.Add("Other");
        }

        private void LoadRoleOptions()
        {
            comboBoxRole.Items.Add("admin");
            comboBoxRole.Items.Add("user");
            comboBoxRole.SelectedIndex = 1;
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
        private void LoadUsers()
        {
            string query = "SELECT [UserId], [FullName], [DateOfBirth], [Gender], [Email], [Password], [Role] FROM [QuizGame].[dbo].[Users]";

            try
            {
                DataTable dataTable = connection.ExecuteQuery(query);
                dgvUsers.DataSource = dataTable;
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

           
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (Connection connection = new Connection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Email", email) };

                connection.OpenConnection();
                var result = connection.ExecuteScalar(query, parameters);
                connection.CloseConnection();

             
                if ((int)result > 0)
                {
                    MessageBox.Show("Email existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nếu email chưa tồn tại, tiếp tục thêm tài khoản mới
                string hashedPassword = ComputeSha256Hash(txtPassword.Text);

                string insertQuery = "INSERT INTO Users (FullName, DateOfBirth, Gender, Email, Password, Role) VALUES (@FullName, @DateOfBirth, @Gender, @Email, @Password, @Role)";
                SqlParameter[] insertParameters = new SqlParameter[]
                {
            new SqlParameter("@FullName", txtFullName.Text),
            new SqlParameter("@DateOfBirth", dtpDateOfBirth.Value),
            new SqlParameter("@Gender", cbxGender.SelectedItem.ToString()),
            new SqlParameter("@Email", email),
            new SqlParameter("@Password", hashedPassword),
            new SqlParameter("@Role", comboBoxRole.SelectedItem.ToString())
                };

                try
                {
                  
                    connection.OpenConnection();
                    connection.ExecuteNonQueryWithParams(insertQuery, insertParameters);
                    connection.CloseConnection();

            
                    LoadUsers();
                    btnRefresh_Click(sender, e);

                
                    MessageBox.Show("Add Account Success !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int userId = (int)dgvUsers.CurrentRow.Cells[0].Value;
                string hashedPassword = ComputeSha256Hash(txtPassword.Text);

                string query = "UPDATE Users SET FullName = @FullName, DateOfBirth = @DateOfBirth, Gender = @Gender, Email = @Email, Password = @Password, Role = @Role WHERE UserId = @UserId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FullName", txtFullName.Text),
                    new SqlParameter("@DateOfBirth", dtpDateOfBirth.Value),
                    new SqlParameter("@Gender", cbxGender.SelectedItem.ToString()),
                    new SqlParameter("@Email", txtEmail.Text),
                    new SqlParameter("@Password", hashedPassword),
                    new SqlParameter("@Role", comboBoxRole.SelectedItem.ToString()),
                    new SqlParameter("@UserId", userId)
                };

                try
                {
                    connection.ExecuteNonQueryWithParams(query, parameters);
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvUsers.CurrentRow != null)
            {
                // Lấy UserId từ dòng hiện tại
                int userId = (int)dgvUsers.CurrentRow.Cells[0].Value;

                // Kiểm tra nếu người dùng có kết quả quiz
                string checkQuery = "SELECT COUNT(*) FROM QuizResults WHERE UserId = @UserId";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
            new SqlParameter("@UserId", userId)
                };

                try
                {
                    connection.OpenConnection();
                    int quizResultCount = (int)connection.ExecuteScalar(checkQuery, checkParameters);
                    connection.CloseConnection();

                    if (quizResultCount > 0)
                    {
                        // Nếu người dùng đã có kết quả quiz, không cho phép xóa
                        MessageBox.Show("Cannot Delete User. User has quiz results.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Hiển thị hộp thoại xác nhận xóa
                        DialogResult result = MessageBox.Show(
                            "Are you sure you want to delete this user?",
                            "Confirm Deletion",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.Yes)
                        {
                            // Chuẩn bị câu lệnh xóa
                            string query = "DELETE FROM Users WHERE UserId = @UserId";

                            SqlParameter[] parameters = new SqlParameter[]
                            {
                        new SqlParameter("@UserId", userId)
                            };

                            // Thực thi câu lệnh xóa
                            connection.OpenConnection();
                            connection.ExecuteNonQueryWithParams(query, parameters);
                            connection.CloseConnection();

                            // Tải lại danh sách người dùng sau khi xóa
                            LoadUsers();
                            MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking quiz results or deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = "SELECT UserId, FullName, DateOfBirth, Gender, Email, Role FROM Users WHERE FullName LIKE @FullName";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", "%" + txtFullName.Text + "%")
            };

            try
            {
                DataTable dataTable = connection.ExecuteQuery(query, parameters);
                dgvUsers.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching users: " + ex.Message);
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtEmail.Enabled = false;
                txtPassword.Enabled = false;
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                dtpDateOfBirth.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                cbxGender.SelectedItem = row.Cells["Gender"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPassword.Text = new string('*', row.Cells["Password"].Value.ToString().Length); 
                comboBoxRole.SelectedItem = row.Cells["Role"].Value.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
            cbxGender.SelectedIndex = -1;
            comboBoxRole.SelectedIndex = 1;
            txtEmail.Enabled = true;
            txtPassword.Enabled = true;
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

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Password" && e.RowIndex >= 0)
            {
                e.Value = new string('*', e.Value.ToString().Length); 
            }
        }
    }
}
