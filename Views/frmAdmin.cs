using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGame.Models.Connection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace QuizGame.Views
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            DisplayTopicPlayerCount(chartTopicsMax);
            DisplayPlayerResults(dataGridViewResult);
            DisplayTop10Players(lblRank);
        }

        public void DisplayTop10Players(Label lblRank)
        {
            DataTable topPlayers = new DataTable();
            StringBuilder rankDisplay = new StringBuilder();

            try
            {
                using (var connection = new Connection())
                {
                    string query = @"
                        SELECT TOP 10 U.FullName AS Name, MAX(QR.Score) AS Score
                        FROM QuizResults QR
                        JOIN Users U ON QR.UserId = U.UserId
                        GROUP BY U.FullName
                        ORDER BY Score DESC";

                    topPlayers = connection.ExecuteQuery(query);
                }

                int rank = 1;
                foreach (DataRow row in topPlayers.Rows)
                {
                    string name = row.Field<string>("Name");
                    int score = row.Field<int>("Score");

                    rankDisplay.AppendLine($"{rank}. {name} - {score}\n");
                    rank++;
                }

                lblRank.Text = rankDisplay.ToString();
                lblRank.TextAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving top player data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void DisplayTopicPlayerCount(Chart chartTopicsMax)
        {
            DataTable topicPlayerCounts = new DataTable();

            try
            {
                using (var connection = new Connection())
                {
                    string query = @"
                        SELECT T.Name AS TopicName, COUNT(QR.UserId) AS PlayerCount
                        FROM QuizResults QR
                        JOIN Topics T ON QR.TopicId = T.Id
                        GROUP BY T.Name
                        ORDER BY PlayerCount DESC";

                    topicPlayerCounts = connection.ExecuteQuery(query);
                }

                chartTopicsMax.Series.Clear();
                chartTopicsMax.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chartTopicsMax.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "TopicPlayers",
                    Color = System.Drawing.Color.NavajoWhite,
                    IsValueShownAsLabel = true,
                    ChartType = SeriesChartType.Pie
                };

                chartTopicsMax.Series.Add(series);

                foreach (DataRow topic in topicPlayerCounts.Rows)
                {
                    string topicName = topic.Field<string>("TopicName");
                    int playerCount = topic.Field<int>("PlayerCount");

                    series.Points.AddXY(topicName, playerCount);
                }

                chartTopicsMax.Titles.Clear();
                chartTopicsMax.Titles.Add("Player Count by Topic");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving player count data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisplayPlayerResults(DataGridView dataGridViewResult)
        {
            DataTable playerResults = new DataTable();

            try
            {
                using (var connection = new Connection())
                {
                    string query = @"
                        SELECT U.FullName AS Name, MAX(QR.Score) AS Score
                        FROM QuizResults QR
                        JOIN Users U ON QR.UserId = U.UserId
                        GROUP BY U.FullName
                        ORDER BY Score DESC";

                    playerResults = connection.ExecuteQuery(query);
                }

                dataGridViewResult.DataSource = null;
                dataGridViewResult.Columns.Clear();

                dataGridViewResult.Columns.Add("Name", "Name");
                dataGridViewResult.Columns.Add("Score", "Score");

                dataGridViewResult.Columns[0].Width = dataGridViewResult.Width / 2;
                dataGridViewResult.Columns[1].Width = dataGridViewResult.Width / 2;

                foreach (DataRow row in playerResults.Rows)
                {
                    dataGridViewResult.Rows.Add(row["Name"], row["Score"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving player data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string AdminName
        {
            set
            {
                txtHello.Text = $"Hello, {value}!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCreateQuiz createQuizForm = new frmCreateQuiz();
            createQuizForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmUser User = new frmUser();
            User.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTopic Topic = new frmTopic();
            Topic.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmEditQuiz EditQuiz = new frmEditQuiz();
            EditQuiz.Show();
        }
    }
}
