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
        private int timeLeft = 30; 

        public frmQuiz(int topicId, int userId)
        {
            InitializeComponent();
            this.topicId = topicId;
            this.currentUserId = userId; 

            quizTimer = new System.Windows.Forms.Timer();
            quizTimer.Interval = 1000; 
            quizTimer.Tick += QuizTimer_Tick; 

            LoadQuestions();
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
                string query = "SELECT Id, QuestionText, QuestionType FROM Questions WHERE TopicId = @TopicId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TopicId", topicId)
                };
                questions = connection.ExecuteQuery(query, parameters);
            }
        }

        private void DisplayCurrentQuestion()
        {
            if (currentQuestionIndex < questions.Rows.Count)
            {
                var questionRow = questions.Rows[currentQuestionIndex];
                lblQuestion.Text = questionRow["QuestionText"].ToString();
                string questionType = questionRow["QuestionType"].ToString();

                panelAnswers.Controls.Clear();

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
            else
            {
                MessageBox.Show("Quiz completed! Your total score is: " + score);
                lblResult.Text = "Total Score: " + score; 
                lblResult.Visible = true; 

                SaveQuizResult(); 

                this.Close(); 
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

                    RadioButton radioButton = new RadioButton
                    {
                        Text = answer["AnswerText"].ToString(),
                        Dock = DockStyle.Fill,
                        Tag = answer["IsCorrect"]
                    };

                    answerPanel.Controls.Add(radioButton);

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

            if (questions.Rows[currentQuestionIndex]["QuestionType"].ToString() == "Multiple Choice")
            {
                foreach (Control control in panelAnswers.Controls)
                {
                    if (control is RadioButton radioButton && radioButton.Checked)
                    {
                        isCorrect = Convert.ToBoolean(radioButton.Tag);
                        break;
                    }
                }
            }
            else if (questions.Rows[currentQuestionIndex]["QuestionType"].ToString() == "Open-Ended")
            {
                TextBox txtAnswer = panelAnswers.Controls.OfType<TextBox>().FirstOrDefault();
                if (txtAnswer != null && txtAnswer.Text.Equals("Answer", StringComparison.OrdinalIgnoreCase))
                {
                    isCorrect = true;
                }
            }
            else if (questions.Rows[currentQuestionIndex]["QuestionType"].ToString() == "True/False")
            {
                foreach (Control control in panelAnswers.Controls)
                {
                    if (control is RadioButton radioButton && radioButton.Checked)
                    {
                        isCorrect = Convert.ToBoolean(radioButton.Tag);
                        break;
                    }
                }
            }

            if (isCorrect)
            {
                score += 10; 
            }

            lblResult.Text = "Total Score: " + score; 
            currentQuestionIndex++;
            quizTimer.Stop(); 
            DisplayCurrentQuestion(); 
        }

        private void SaveQuizResult()
        {
            string query = "INSERT INTO QuizResults (UserId, TopicId, DateTaken, Score) VALUES (@UserId, @TopicId, @DateTaken, @Score)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", currentUserId), 
                new SqlParameter("@TopicId", topicId), 
                new SqlParameter("@DateTaken", DateTime.Now), 
                new SqlParameter("@Score", score) 
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
    }
}
