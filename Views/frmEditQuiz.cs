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
    public partial class frmEditQuiz : Form
    {
        public frmEditQuiz()
        {
            InitializeComponent();
            LoadTopics();
            comboBoxTopicName.SelectedIndexChanged += comboBoxTopicName_SelectedIndexChanged;
        }

        private void LoadTopics()
        {
            using (var connection = new Connection())
            {
                string query = "SELECT Id, Name FROM Topics";
                DataTable topics = connection.ExecuteQuery(query);
                comboBoxTopicName.DataSource = topics;
                comboBoxTopicName.DisplayMember = "Name";
                comboBoxTopicName.ValueMember = "Id";
            }
        }

        private void comboBoxTopicName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTopicId = (int)comboBoxTopicName.SelectedValue;
            LoadQuestions(selectedTopicId);
        }

        private void LoadQuestions(int topicId)
        {
            panelQuestions.Controls.Clear();
            using (var connection = new Connection())
            {
                string query = "SELECT Id, QuestionText, QuestionType FROM Questions WHERE TopicId = @TopicId";
                SqlParameter[] parameters = { new SqlParameter("@TopicId", topicId) };
                DataTable questions = connection.ExecuteQuery(query, parameters);

                foreach (DataRow row in questions.Rows)
                {
                    var questionPanel = new Panel
                    {
                        Size = new Size(900, 300),
                        Dock = DockStyle.Top,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(0, 0, 0, 10)
                    };

                    var txtQuestion = new TextBox
                    {
                        Text = row["QuestionText"].ToString(),
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
                    comboBoxQuestionType.SelectedItem = row["QuestionType"].ToString();
                    questionPanel.Controls.Add(comboBoxQuestionType);

                    LoadAnswers(questionPanel, Convert.ToInt32(row["Id"]), row["QuestionType"].ToString());

                    var btnEdit = new Button
                    {
                        Text = "Edit",
                        Dock = DockStyle.Left,
                        Width = 75
                    };
                    btnEdit.Click += (s, args) =>
                    {
                        EditQuestion(Convert.ToInt32(row["Id"]), txtQuestion.Text, comboBoxQuestionType.SelectedItem.ToString());
                    };
                    questionPanel.Controls.Add(btnEdit);

                    var btnDelete = new Button
                    {
                        Text = "Delete",
                        Dock = DockStyle.Left,
                        Width = 90
                    };
                    btnDelete.Click += (s, args) =>
                    {
                        DeleteQuestion(Convert.ToInt32(row["Id"]));
                        LoadQuestions(topicId);
                    };
                    questionPanel.Controls.Add(btnDelete);

                    panelQuestions.Controls.Add(questionPanel);
                }
            }
        }

        private void LoadAnswers(Panel questionPanel, int questionId, string questionType)
        {
            using (var connection = new Connection())
            {
                string query = "SELECT AnswerText, IsCorrect FROM Answers WHERE QuestionId = @QuestionId";
                SqlParameter[] parameters = { new SqlParameter("@QuestionId", questionId) };
                DataTable answers = connection.ExecuteQuery(query, parameters);

                switch (questionType)
                {
                    case "Multiple Choice":
                        for (int i = 0; i < answers.Rows.Count; i++)
                        {
                            var txtAnswer = new TextBox
                            {
                                Text = answers.Rows[i]["AnswerText"].ToString(),
                                Dock = DockStyle.Top,
                                Height = 30,
                                PlaceholderText = $"Answer {i + 1}"
                            };
                            questionPanel.Controls.Add(txtAnswer);
                        }

                        var comboBoxIsCorrect = new ComboBox
                        {
                            Dock = DockStyle.Top,
                            Height = 30
                        };
                        comboBoxIsCorrect.Items.AddRange(new string[] { "0", "1", "2", "3" });
                        comboBoxIsCorrect.SelectedIndex = answers.Rows.Cast<DataRow>().ToList().FindIndex(x => (bool)x["IsCorrect"]);
                        questionPanel.Controls.Add(comboBoxIsCorrect);
                        break;

                    case "Open-Ended":
                        var txtAnswerOpenEnded = new TextBox
                        {
                            Text = answers.Rows.Count > 0 ? answers.Rows[0]["AnswerText"].ToString() : string.Empty,
                            Dock = DockStyle.Top,
                            Height = 30,
                            PlaceholderText = "Answer"
                        };
                        questionPanel.Controls.Add(txtAnswerOpenEnded);
                        break;

                    case "True/False":
                        var cbxAnswerTrueFalse = new ComboBox
                        {
                            Dock = DockStyle.Top,
                            Height = 30
                        };
                        cbxAnswerTrueFalse.Items.AddRange(new string[] { "True", "False" });
                        cbxAnswerTrueFalse.SelectedItem = answers.Rows.Count > 0 && (bool)answers.Rows[0]["IsCorrect"] ? "True" : "False";
                        questionPanel.Controls.Add(cbxAnswerTrueFalse);
                        break;
                }
            }
        }

        private void EditQuestion(int questionId, string newQuestionText, string questionType)
        {
            using (var connection = new Connection())
            {
                string updateQuery = "UPDATE Questions SET QuestionText = @QuestionText, QuestionType = @QuestionType WHERE Id = @QuestionId";
                SqlParameter[] parameters =
                {
                new SqlParameter("@QuestionText", newQuestionText),
                new SqlParameter("@QuestionType", questionType),
                new SqlParameter("@QuestionId", questionId)
            };
                connection.ExecuteNonQueryWithParams(updateQuery, parameters);
                MessageBox.Show("Question updated successfully!");
            }
        }

        private void DeleteQuestion(int questionId)
        {
            using (var connection = new Connection())
            {
                string checkQuery = "SELECT COUNT(*) FROM Answers WHERE QuestionId = @QuestionId";
                SqlParameter[] checkParameters = { new SqlParameter("@QuestionId", questionId) };
                int answerCount = (int)connection.ExecuteScalar(checkQuery, checkParameters);

                if (answerCount > 0)
                {
                    MessageBox.Show("Cannot delete the question because it has been answered by users.");
                    return;
                }

                string deleteQuery = "DELETE FROM Questions WHERE Id = @QuestionId";
                SqlParameter[] parameters = { new SqlParameter("@QuestionId", questionId) };
                connection.ExecuteNonQueryWithParams(deleteQuery, parameters);
                MessageBox.Show("Question deleted successfully!");
            }
        }

    }

}
