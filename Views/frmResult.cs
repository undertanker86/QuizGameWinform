using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuizGame.Models.Connection;

namespace QuizGame.Views
{
    public partial class frmResult : Form
    {
        private int currentUserId;

        public frmResult(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            this.Load += new EventHandler(frmResult_Load);
        }

        private void frmResult_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Current User ID: " + currentUserId);
            LoadResults();
        }

        private void LoadResults()
        {
            try
            {
                using (var connection = new Connection())
                {
                    string query = "SELECT T.Name AS Topic, QR.DateTaken, QR.Score, QR.DateDuring " +
                                   "FROM QuizResults QR " +
                                   "JOIN Topics T ON QR.TopicId = T.Id " +
                                   "WHERE QR.UserId = @UserId ORDER BY QR.DateTaken DESC";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@UserId", currentUserId)
                    };

                    Console.WriteLine("Executing Query: " + query);
                    Console.WriteLine("Parameters: UserId = " + currentUserId);

                    DataTable quizResults = connection.ExecuteQuery(query, parameters);

                    if (quizResults.Rows.Count > 0)
                    {
                        // Thêm cột mới cho DateDuring đã định dạng
                        quizResults.Columns.Add("TimeSpent", typeof(string));

                        foreach (DataRow row in quizResults.Rows)
                        {
                            if (int.TryParse(row["DateDuring"].ToString(), out int totalSeconds))
                            {
                                TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);
                                row["TimeSpent"] = $"{(int)timeSpan.TotalMinutes:D2}:{timeSpan.Seconds:D2}";
                            }
                            else
                            {
                                row["TimeSpent"] = "00:00";
                            }
                        }

                        // Thiết lập DataSource cho DataGridView
                        dgvResults.DataSource = quizResults;

                        // Đặt lại các cột trong DataGridView
                        dgvResults.Columns["Topic"].Width = dgvResults.Width / 4;
                        dgvResults.Columns["DateTaken"].Width = dgvResults.Width / 4;
                        dgvResults.Columns["Score"].Width = dgvResults.Width / 4;
                        dgvResults.Columns["TimeSpent"].Width = dgvResults.Width / 4;

                        // Đổi tên cột mới
                        dgvResults.Columns["TimeSpent"].HeaderText = "Time During (mm:ss)";
                    }
                    else
                    {
                        MessageBox.Show("No results found for this user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvResults.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmResult_Load_1(object sender, EventArgs e)
        {
            Console.WriteLine("Current User ID: " + currentUserId);
            LoadResults();
        }
    }
}
