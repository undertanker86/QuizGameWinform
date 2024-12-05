using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using QuizGame.Models.Connection;

namespace QuizGame.Views
{
    public partial class frmQuiz : Form
    {
        private int currentQuestionIndex = 0;
        private int topicId;
        private int currentUserId;
        private DataTable questions;
        private int score = 0;
        private System.Windows.Forms.Timer quizTimer;
        private int timeLeft = 20;
        private bool isQuizCompleted = false;
        private DateTime timeStart;

        public frmQuiz(int topicId, int userId)
        {
            InitializeComponent();
            this.topicId = topicId;
            this.currentUserId = userId;

            quizTimer = new System.Windows.Forms.Timer();
            quizTimer.Interval = 1000;
            quizTimer.Tick += QuizTimer_Tick;

            LoadQuestions();
            timeStart = DateTime.Now;
            DisplayCurrentQuestion();
            lblResult.Text = "Total Score: " + score;
        }

        private void QuizTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            lblTimer.Text = $"Time Left: {timeLeft}s";

            if (timeLeft <= 0)
            {
                quizTimer.Stop();
                MessageBox.Show("Time is up! Moving to the next question.");
                currentQuestionIndex++;
                DisplayCurrentQuestion();
            }
        }

        private void LoadQuestions()
        {
            using (var connection = new Connection())
            {
                string query = "SELECT Id, QuestionText, QuestionType, image FROM Questions WHERE TopicId = @TopicId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TopicId", topicId)
                };
                questions = connection.ExecuteQuery(query, parameters);
            }
        }

        private void DisplayCurrentQuestion()
        {
            if (currentQuestionIndex >= questions.Rows.Count)
            {
                MessageBox.Show("Quiz completed! Your total score is: " + score);
                lblResult.Text = "Total Score: " + score;
                lblResult.Visible = true;

                SaveQuizResult();
                isQuizCompleted = true;
                this.Close();
                return;
            }
            else
            { 
                var questionRow = questions.Rows[currentQuestionIndex];
                lblQuestion.Text = questionRow["QuestionText"].ToString();
                string questionType = questionRow["QuestionType"].ToString();

                panelAnswers.Controls.Clear();

                string imagePath = questionRow["image"]?.ToString();
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    pictureBoxQuestion.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pictureBoxQuestion.Image = null;
                }

                switch (questionType)
                {
                    case "Multiple Choice":
                        LoadMultipleChoiceAnswers();
                        break;
                    case "Open-Ended":
                        LoadOpenEndedAnswer();
                        break;
                    case "True/False":
                        LoadTrueFalseAnswer();
                        break;
                }

                timeLeft = 30;
                lblTimer.Text = $"Time Left: {timeLeft}s";
                quizTimer.Start();
            }

        }

        private void LoadMultipleChoiceAnswers()
        {
            int questionId = (int)questions.Rows[currentQuestionIndex]["Id"];
            using (var connection = new Connection())
            {
                string answerQuery = "SELECT AnswerText, IsCorrect FROM Answers WHERE QuestionId = @QuestionId";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@QuestionId", questionId)
                };
                DataTable answers = connection.ExecuteQuery(answerQuery, parameters);

                foreach (DataRow answer in answers.Rows)
                {
                    Panel answerPanel = new Panel
                    {
                        Dock = DockStyle.Top,
                        Padding = new Padding(5)
                    };

                    CheckBox checkBox = new CheckBox
                    {
                        Text = answer["AnswerText"].ToString(),
                        Dock = DockStyle.Left,
                        Tag = answer["IsCorrect"]
                    };

                    answerPanel.Controls.Add(checkBox);
                    panelAnswers.Controls.Add(answerPanel);
                }
            }
        }

        private void LoadOpenEndedAnswer()
        {
            TextBox txtAnswer = new TextBox
            {
                PlaceholderText = "Your answer here...",
                Dock = DockStyle.Top
            };
            panelAnswers.Controls.Add(txtAnswer);
        }

        private void LoadTrueFalseAnswer()
        {
            Panel truePanel = new Panel
            {
                Dock = DockStyle.Top,
                Padding = new Padding(5)
            };

            RadioButton rbTrue = new RadioButton
            {
                Text = "True",
                Dock = DockStyle.Fill,
                Tag = true
            };

            truePanel.Controls.Add(rbTrue);

            panelAnswers.Controls.Add(truePanel);

            Panel falsePanel = new Panel
            {
                Dock = DockStyle.Top,
                Padding = new Padding(5)
            };

            RadioButton rbFalse = new RadioButton
            {
                Text = "False",
                Dock = DockStyle.Fill,
                Tag = false
            };

            falsePanel.Controls.Add(rbFalse);

            panelAnswers.Controls.Add(falsePanel);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool isCorrect = false;
            string questionType = questions.Rows[currentQuestionIndex]["QuestionType"].ToString();
            string correctAnswers = "";  // Biến để lưu các đáp án đúng
                                         // Lấy thông tin đáp án đúng từ cơ sở dữ liệu
            int questionId_tmp = (int)questions.Rows[currentQuestionIndex]["Id"];
            using (var connection = new Connection())
            {
                string query = "SELECT AnswerText FROM Answers WHERE QuestionId = @QuestionId AND IsCorrect = 1";
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@QuestionId", questionId_tmp) };
                DataTable correctAnswerTable = connection.ExecuteQuery(query, parameters);

                foreach (DataRow row in correctAnswerTable.Rows)
                {
                    correctAnswers += row["AnswerText"].ToString() + "\n"; // Thêm đáp án đúng vào chuỗi
                }
            }

            if (questionType == "Multiple Choice")
            {
                bool allCorrectSelected = true;
                bool hasIncorrectSelected = false;

                foreach (Control control in panelAnswers.Controls)
                {
                    if (control is Panel panel && panel.Controls.OfType<CheckBox>().FirstOrDefault() is CheckBox checkBox)
                    {
                        bool isAnswerCorrect = bool.Parse(checkBox.Tag.ToString());

                        if (checkBox.Checked && !isAnswerCorrect)
                        {
                            hasIncorrectSelected = true;
                        }
                        else if (!checkBox.Checked && isAnswerCorrect)
                        {
                            allCorrectSelected = false;
                        }
                    }
                }

                if (allCorrectSelected && !hasIncorrectSelected)
                {
                    isCorrect = true;
                }
            }
            else if (questionType == "Open-Ended")
            {
                int questionId = (int)questions.Rows[currentQuestionIndex]["Id"];
                string correctAnswer = "";

                using (var connection = new Connection())
                {
                    string query = "SELECT AnswerText FROM Answers WHERE QuestionId = @QuestionId AND IsCorrect = 1";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@QuestionId", questionId)
                    };
                    object result = connection.ExecuteScalar(query, parameters);
                    if (result != null)
                    {
                        correctAnswer = result.ToString().Trim();
                    }
                }

                TextBox txtAnswer = panelAnswers.Controls.OfType<TextBox>().FirstOrDefault();
                if (txtAnswer != null)
                {
                    string userAnswer = txtAnswer.Text.Trim();
                    if (string.Equals(userAnswer, correctAnswer, StringComparison.OrdinalIgnoreCase))
                    {
                        isCorrect = true;
                    }
                }
            }
            else if (questionType == "True/False")
            {
                int questionId = (int)questions.Rows[currentQuestionIndex]["Id"];
                string correctAnswer = "";

                using (var connection = new Connection())
                {
                    string query = "SELECT AnswerText FROM Answers WHERE QuestionId = @QuestionId AND IsCorrect = 1";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@QuestionId", questionId)
                    };
                    object result = connection.ExecuteScalar(query, parameters);
                    if (result != null)
                    {
                        correctAnswer = result.ToString();
                    }
                }

                foreach (Control control in panelAnswers.Controls)
                {
                    if (control is Panel panel && panel.Controls.OfType<RadioButton>().FirstOrDefault() is RadioButton radioButton && radioButton.Checked)
                    {
                        if (radioButton.Tag.ToString().Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                        {
                            isCorrect = true;
                        }
                        break;
                    }
                }
            }

            if (isCorrect)
            {
                score += 10;
            }
            // Hiển thị đáp án đúng
            MessageBox.Show($"Correct Answers for this question:\n{correctAnswers}");

            lblResult.Text = "Total Score: " + score;
            currentQuestionIndex++;
            quizTimer.Stop();

            if (currentQuestionIndex >= questions.Rows.Count)
            {
                isQuizCompleted = true;
                MessageBox.Show($"Quiz completed! Your total score is: {score}");
                SaveQuizResult();
                this.Close();
            }
            else
            {
                DisplayCurrentQuestion();

            }
        }

        private void SaveQuizResult()
        {
            DateTime timeTaken = DateTime.Now;
            TimeSpan timeSpent = timeTaken - timeStart;
            int totalTimeInSeconds = (int)timeSpent.TotalSeconds;  
       

            string query = "INSERT INTO QuizResults (UserId, TopicId, Score, DateTaken, DateDuring) VALUES (@UserId, @TopicId, @Score, @DateTaken, @DateDuring)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@UserId", currentUserId),
            new SqlParameter("@TopicId", topicId),
            new SqlParameter("@Score", score),
            new SqlParameter("@DateTaken", DateTime.Now),  // Lưu thời điểm hoàn thành quiz
            new SqlParameter("@DateDuring", totalTimeInSeconds)
            };

            using (var connection = new Connection())
            {
                connection.ExecuteNonQueryWithParams(query, parameters);
            }

            NavigateToHome();
        }

        private void NavigateToHome()
        {
            frmHome homeForm = new frmHome();
            homeForm.SetCurrentUserId(currentUserId);
            homeForm.Show();
            this.Close();
        }

        private void frmQuiz_Load(object sender, EventArgs e)
        {

        }
        public void SetCurrentUserId(int userId) {
            this.currentUserId = userId;
        }

        private void frmQuiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isQuizCompleted == true)
            {
                e.Cancel = false;
                return;
            }
            var result = MessageBox.Show("Are you sure you want to quit the quiz? Your progress will not be saved.", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                quizTimer.Stop();
                score = 0;
                currentQuestionIndex = 0;
                frmHome homeForm = new frmHome();
                homeForm.SetCurrentUserId(currentUserId) ;
                homeForm.Show();
                e.Cancel = false;
            }
            else
            {
                e.Cancel=true;
            }
        }
    }
}
