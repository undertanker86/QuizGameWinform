using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuizGame.Models.Connection;
using System.Diagnostics;
using QuizGame.Models;

namespace QuizGame.Views
{
    public partial class frmCreateQuiz : Form
    {
        private List<Question> questions = new List<Question>();

        public frmCreateQuiz()
        {
            InitializeComponent();
            LoadTopics();
        }

        private void LoadTopics()
        {
            try
            {
                using (var connection = new Connection())
                {
                    string query = @"
                        SELECT t.Id, t.Name
                        FROM Topics t
                        LEFT JOIN Questions q ON t.Id = q.TopicId
                        WHERE q.Id IS NULL"; 

                    DataTable topics = connection.ExecuteQuery(query);

                    if (topics != null && topics.Rows.Count > 0)
                    {
                        comboBoxTopicName.DataSource = topics;
                        comboBoxTopicName.DisplayMember = "Name";
                        comboBoxTopicName.ValueMember = "Id";
                    }
                    else
                    {
                        comboBoxTopicName.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chủ đề: " + ex.Message);
            }
        }


        private void btnCreateQuiz_Click(object sender, EventArgs e)
        {
            int questionCount;
            if (int.TryParse(txtSoluong.Text, out questionCount))
            {
                panelQuestions.Controls.Clear();
                for (int i = 0; i < questionCount; i++)
                {
                    var questionPanel = new Panel
                    {
                        Size = new Size(900, 250),
                        Dock = DockStyle.Top,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(115, 10, 10, 10)
                    };

                    var txtQuestion = new TextBox
                    {
                        PlaceholderText = $"Enter Question {i + 1}",
                        Dock = DockStyle.Top,
                        Height = 30
                    };
                    questionPanel.Controls.Add(txtQuestion);

                    var comboBoxQuestionType = new ComboBox
                    {
                        Dock = DockStyle.Top,
                        Height = 30
                    };
                    comboBoxQuestionType.Items.AddRange(new string[] { "Multiple Choice", "Open-Ended", "True/False" });
                    comboBoxQuestionType.SelectedIndexChanged += (s, args) =>
                    {
                        questionPanel.Controls.Clear();
                        questionPanel.Controls.Add(txtQuestion);
                        questionPanel.Controls.Add(comboBoxQuestionType);

                        switch (comboBoxQuestionType.SelectedItem.ToString())
                        {
                            case "Multiple Choice":
                                for (int j = 0; j < 4; j++)
                                {
                                    var txtAnswer = new TextBox
                                    {
                                        PlaceholderText = $"Answer {j + 1}",
                                        Dock = DockStyle.Bottom,
                                        Height = 30
                                    };
                                    questionPanel.Controls.Add(txtAnswer);
                                }

                                var comboBoxIsCorrect = new ComboBox
                                {
                                    Dock = DockStyle.Bottom,
                                    Height = 30
                                };
                                comboBoxIsCorrect.Items.AddRange(new string[] { "1", "2", "3", "4" });
                                comboBoxIsCorrect.SelectedIndex = 0;
                                questionPanel.Controls.Add(comboBoxIsCorrect);
                                break;

                            case "Open-Ended":
                                var txtAnswerOpenEnded = new TextBox
                                {
                                    PlaceholderText = "Answer",
                                    Dock = DockStyle.Bottom,
                                    Height = 30
                                };
                                questionPanel.Controls.Add(txtAnswerOpenEnded);
                                break;

                            case "True/False":
                                var cbxAnswerTrueFalse = new ComboBox
                                {
                                    Dock = DockStyle.Bottom,
                                    Height = 30
                                };
                                cbxAnswerTrueFalse.Items.AddRange(new string[] { "True", "False" });
                                cbxAnswerTrueFalse.SelectedIndex = 0;
                                questionPanel.Controls.Add(cbxAnswerTrueFalse);
                                break;
                        }
                    };

                    questionPanel.Controls.Add(comboBoxQuestionType);
                    panelQuestions.Controls.Add(questionPanel);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxTopicName.SelectedValue == null)
            {
                MessageBox.Show("Please select a topic before saving.");
                return;
            }

            if (panelQuestions.Controls.Count == 0)
            {
                MessageBox.Show("Please create at least one question before saving.");
                return;
            }

            int selectedTopicId = (int)comboBoxTopicName.SelectedValue;

            using (var connection = new Connection())
            {
                try
                {
                    foreach (Control questionPanel in panelQuestions.Controls)
                    {
                        if (questionPanel is Panel panel)
                        {
                            string questionText = ((TextBox)panel.Controls[0]).Text;
                            string questionType = ((ComboBox)panel.Controls[1]).SelectedItem.ToString();

                            string questionInsertQuery = "INSERT INTO Questions (TopicId, QuestionText, QuestionType) OUTPUT INSERTED.Id VALUES (@TopicId, @QuestionText, @QuestionType)";
                            SqlParameter[] questionParams = new SqlParameter[]
                            {
                                new SqlParameter("@TopicId", selectedTopicId),
                                new SqlParameter("@QuestionText", questionText),
                                new SqlParameter("@QuestionType", questionType)
                            };

                            int questionId = (int)connection.ExecuteScalar(questionInsertQuery, questionParams);

                            switch (questionType)
                            {
                                case "Multiple Choice":
                                    var comboBoxIsCorrect = (ComboBox)panel.Controls[panel.Controls.Count - 1];
                                    int correctAnswerIndex = Convert.ToInt32(comboBoxIsCorrect.SelectedItem);

                                    for (int i = 2; i < panel.Controls.Count - 1; i++)
                                    {
                                        var txtAnswer = panel.Controls[i] as TextBox;
                                        if (txtAnswer != null)
                                        {
                                            string answerText = txtAnswer.Text;
                                            bool isCorrect = (i - 2) == correctAnswerIndex;

                                            string answerInsertQuery = "INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES (@QuestionId, @AnswerText, @IsCorrect)";
                                            SqlParameter[] answerParams = new SqlParameter[]
                                            {
                                        new SqlParameter("@QuestionId", questionId),
                                        new SqlParameter("@AnswerText", answerText),
                                        new SqlParameter("@IsCorrect", isCorrect)
                                            };
                                            connection.ExecuteNonQueryWithParams(answerInsertQuery, answerParams);
                                        }
                                    }
                                    break;

                                case "Open-Ended":
                                    var openEndedAnswer = (TextBox)panel.Controls[2];
                                    string openEndedText = openEndedAnswer.Text;
                                    string openEndedInsertQuery = "INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES (@QuestionId, @AnswerText, @IsCorrect)";
                                    SqlParameter[] openEndedParams = new SqlParameter[]
                                    {
                                new SqlParameter("@QuestionId", questionId),
                                new SqlParameter("@AnswerText", openEndedText),
                                new SqlParameter("@IsCorrect", false)
                                    };
                                    connection.ExecuteNonQueryWithParams(openEndedInsertQuery, openEndedParams);
                                    break;

                                case "True/False":
                                    var trueFalseAnswer = (ComboBox)panel.Controls[2];
                                    string trueFalseText = trueFalseAnswer.SelectedItem.ToString();
                                    string trueFalseInsertQuery = "INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES (@QuestionId, @AnswerText, @IsCorrect)";
                                    SqlParameter[] trueFalseParams = new SqlParameter[]
                                    {
                                new SqlParameter("@QuestionId", questionId),
                                new SqlParameter("@AnswerText", trueFalseText),
                                new SqlParameter("@IsCorrect", trueFalseText == "True")
                                    };
                                    connection.ExecuteNonQueryWithParams(trueFalseInsertQuery, trueFalseParams);
                                    break;
                            }
                        }
                    }

                    MessageBox.Show("Quiz saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the quiz: " + ex.Message);
                }
            }
        }


    }
}
