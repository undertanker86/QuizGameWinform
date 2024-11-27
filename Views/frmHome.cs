using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuizGame.Models.Connection;

namespace QuizGame.Views
{
    public partial class frmHome : Form
    {
        private int currentUserId;

        public frmHome()
        {
            InitializeComponent();
            DisplayTop10Players(lblRank);
        }

        public string UserName
        {
            set
            {
                txtHelloUser.Text = $"Welcome, {value}!";
            }
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


        public void SetCurrentUserId(int userId)
        {
            currentUserId = userId;
        }

        private DataTable GetTopUsers()
        {
            string query = @"
                SELECT TOP 10 
                    u.UserId, 
                    u.FullName, 
                    SUM(qr.Score) AS TotalScore
                FROM 
                    Users u
                JOIN 
                    QuizResults qr ON u.UserId = qr.UserId
                GROUP BY 
                    u.UserId, u.FullName
                ORDER BY 
                    TotalScore DESC";

            using (var connection = new Connection())
            {
                return connection.ExecuteQuery(query);
            }
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            DataTable topUsers = GetTopUsers();
        }

        private void btn_PlayQuiz_Click(object sender, EventArgs e)
        {
            frmPlayQuiz playQuizForm = new frmPlayQuiz(currentUserId);
            playQuizForm.Show();
            this.Hide();
        }

        private void btnViewResult_Click(object sender, EventArgs e)
        {
            frmResult resultForm = new frmResult(currentUserId);
            resultForm.Show();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            frmEditInfo editInfoForm = new frmEditInfo(currentUserId);
            editInfoForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void lblRank_Click(object sender, EventArgs e)
        {

        }
    }
}
