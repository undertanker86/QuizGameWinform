using System.Data;
using System.Data.SqlClient;
using QuizGame.Models.Connection;

namespace QuizGame.Views
{
    public partial class frmPlayQuiz : Form
    {
        private int currentUserId; 

        public frmPlayQuiz(int userId) 
        {
            InitializeComponent();
            currentUserId = userId; 
            LoadTopics();
            txtRules.Text = "### Quiz Game Rules\n\n" +
                    "1. **Objective**:\n" +
                    "- Players will answer a series of quiz questions related to a specific topic. The goal is to achieve the highest score possible.\n\n" +
                    "2. **Preparation**:\n" +
                    "- The game will consist of multiple questions, each belonging to one of three types: **Multiple Choice**, **Open-Ended**, \n" +
                    "and **True/False**.\n" +
                    "- Players must select a topic before starting the game.\n\n" +
                    "3. **Gameplay**:\n" +
                    "- The game will be played within a set time limit for each question (e.g., 30 seconds).\n" +
                    "- Each question will be displayed randomly. Players will be required to answer by selecting one of the options or typing their answer\n" +
                    "for open - ended questions.\n" +
                    "4. **Scoring**:\n" +
                    "- Each correct answer will earn the player 10 points.\n" +
                    "- Incorrect answers will not deduct points.\n\n" +
                    "5. **Time Rules**:\n" +
                    "- If players do not answer within the allocated time, the game will automatically move to the next question without awarding points \n" +
                    "for that question.\n" +
                    "- The remaining time will be displayed for the player.\n\n";
        }

        private void LoadTopics()
        {
            using (var connection = new Connection())
            {
                string query = @"
                    SELECT t.Id, t.Name 
                    FROM Topics t
                    INNER JOIN Questions q ON t.Id = q.TopicId
                    GROUP BY t.Id, t.Name";

                DataTable topics = connection.ExecuteQuery(query);

                comboBoxTopics.DataSource = topics;
                comboBoxTopics.DisplayMember = "Name";
                comboBoxTopics.ValueMember = "Id";
            }
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            if (comboBoxTopics.SelectedValue == null)
            {
                MessageBox.Show("Please select a topic to start the quiz.");
                return;
            }

            int selectedTopicId = (int)comboBoxTopics.SelectedValue;
            bool hasTakenQuiz = false;

            using (var dbConnection = new Connection())
            {
                string query = "SELECT COUNT(*) FROM [QuizGame].[dbo].[QuizResults] WHERE [UserId] = @UserId AND [TopicId] = @TopicId";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@UserId", currentUserId),
            new SqlParameter("@TopicId", selectedTopicId)
                };

                int count = (int)dbConnection.ExecuteScalar(query, parameters);
                hasTakenQuiz = (count > 0);
            }

            if (hasTakenQuiz)
            {
                DialogResult dialogResult = MessageBox.Show("You have taken this quiz, do you confirm to retake it?",
                                            "Confirmation",
                                            MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            frmQuiz quizForm = new frmQuiz(selectedTopicId, currentUserId);
            quizForm.Show();
            this.Hide();
        }

    }
}
