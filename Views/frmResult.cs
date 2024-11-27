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
                    string query = "SELECT T.Name AS Topic, QR.DateTaken, QR.Score " +
                                   "FROM QuizResults QR " +
                                   "JOIN Topics T ON QR.TopicId = T.Id " +
                                   "WHERE QR.UserId = @UserId ORDER BY QR.DateTaken DESC";

                    SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@UserId", currentUserId)
            };

                    Console.WriteLine("Executing Query: " + query);
                    Console.WriteLine("Parameters: UserId = " + currentUserId);

                    DataTable quizResults = connection.ExecuteQuery(query, parameters);

                    if (quizResults.Rows.Count > 0)
                    {
                        dgvResults.DataSource = quizResults;

                        int totalWidth = dgvResults.Width;
                        int columnWidth = totalWidth / 3;

                        dgvResults.Columns[0].Width = columnWidth; // Topic
                        dgvResults.Columns[1].Width = columnWidth; // DateTaken
                        dgvResults.Columns[2].Width = columnWidth; // Score
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
