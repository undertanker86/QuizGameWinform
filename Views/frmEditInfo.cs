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
                    txtEmail.Text = row["Email"].ToString();
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
            string query = "UPDATE Users SET FullName = @FullName, DateOfBirth = @DateOfBirth, Gender = @Gender, Email = @Email WHERE UserId = @UserId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", txtFullName.Text),
                new SqlParameter("@DateOfBirth", dtpDateOfBirth.Value),
                new SqlParameter("@Gender", cmbGender.SelectedItem.ToString()),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@UserId", userId)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
