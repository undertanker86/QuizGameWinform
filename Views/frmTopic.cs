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
using System.Data.SqlClient;


namespace QuizGame.Views
{
    public partial class frmTopic : Form
    {
        private readonly Connection _connection;

        public frmTopic()
        {
            InitializeComponent();
            _connection = new Connection();
            LoadTopics();
            dgvTopics.SelectionChanged += DgvTopics_SelectionChanged;
        }

        private void DgvTopics_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTopics.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTopics.SelectedRows[0];

                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
            }
        }

        private void LoadTopics()
        {
            string query = "SELECT [Id], [Name] FROM [Topics]";
            DataTable topics = _connection.ExecuteQuery(query);
            dgvTopics.DataSource = topics;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtName.Text.Trim();
            string query = "SELECT [Id], [Name] FROM [Topics] WHERE [Name] LIKE @searchTerm";
            SqlParameter[] parameters = { new SqlParameter("@searchTerm", $"%{searchTerm}%") };
            DataTable searchResults = _connection.ExecuteQuery(query, parameters);
            dgvTopics.DataSource = searchResults;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string topicName = txtName.Text.Trim();
            if (string.IsNullOrEmpty(topicName))
            {
                MessageBox.Show("Please enter a topic name.");
                return;
            }

            string query = "INSERT INTO [Topics] ([Name]) VALUES (@Name)";
            SqlParameter[] parameters = { new SqlParameter("@Name", topicName) };

            _connection.ExecuteNonQueryWithParams(query, parameters);
            MessageBox.Show($"Added topic: {topicName}");
            LoadTopics(); 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTopics.SelectedRows.Count > 0)
            {
                int selectedId = (int)dgvTopics.SelectedRows[0].Cells["Id"].Value;
                string topicName = txtName.Text.Trim();
                if (string.IsNullOrEmpty(topicName))
                {
                    MessageBox.Show("Please enter a topic name.");
                    return;
                }

                string query = "UPDATE [Topics] SET [Name] = @Name WHERE [Id] = @Id";
                SqlParameter[] parameters = {
                new SqlParameter("@Name", topicName),
                new SqlParameter("@Id", selectedId)
            };

                _connection.ExecuteNonQueryWithParams(query, parameters);
                MessageBox.Show($"Edited topic: {topicName}");
                LoadTopics(); 
            }
            else
            {
                MessageBox.Show("Please select a topic to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTopics.SelectedRows.Count > 0)
            {
                int selectedId = (int)dgvTopics.SelectedRows[0].Cells["Id"].Value;

                // Kiểm tra xem có câu hỏi nào liên kết với chủ đề này không
                string checkQuery = "SELECT COUNT(*) FROM [Questions] WHERE [TopicId] = @TopicId";
                SqlParameter[] checkParams = { new SqlParameter("@TopicId", selectedId) };
                int questionCount = (int)_connection.ExecuteScalar(checkQuery, checkParams);

                if (questionCount > 0)
                {
                    // Nếu có câu hỏi liên quan, không cho phép xóa topic và thông báo lỗi
                    MessageBox.Show("Cannot delete the topic. Please delete the related questions first.");
                    return;
                }

                // Nếu không có câu hỏi liên quan, thực hiện xóa chủ đề
                string query = "DELETE FROM [Topics] WHERE [Id] = @Id";
                SqlParameter[] parameters = { new SqlParameter("@Id", selectedId) };

                try
                {
                    _connection.ExecuteNonQueryWithParams(query, parameters);
                    MessageBox.Show("Topic deleted.");
                    LoadTopics();
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi xảy ra trong quá trình xóa, hiển thị thông báo lỗi
                    MessageBox.Show($"Error occurred while deleting the topic: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a topic to delete.");
            }
        }
    }
}
