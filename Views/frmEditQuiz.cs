using System.Data;
using System.Data.SqlClient;
using QuizGame.Models.Connection;

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
                string query = "SELECT Id, QuestionText, QuestionType, image FROM Questions WHERE TopicId = @TopicId";
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

                    var pictureBox = new PictureBox
                    {
                        Size = new Size(150, 150),
                        Dock = DockStyle.Left,
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    string imagePath = row["image"]?.ToString();
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        pictureBox.Image = Image.FromFile(imagePath);
                        pictureBox.Tag = imagePath;
                    }
                    else
                    {
                        pictureBox.Image = null; // Nếu không có ảnh
                        pictureBox.Tag = null;
                    }
                    questionPanel.Controls.Add(pictureBox);

                    LoadAnswers(questionPanel, Convert.ToInt32(row["Id"]), row["QuestionType"].ToString());

                    var btnEdit = new Button
                    {
                        Text = "Edit",
                        Dock = DockStyle.Left,
                        Width = 75
                    };
                    btnEdit.Click += (s, args) =>
                    {
                        EditQuestion(Convert.ToInt32(row["Id"]), txtQuestion.Text, comboBoxQuestionType.SelectedItem.ToString(), pictureBox.Tag?.ToString());
                        using (var connection = new Connection())
                        {
                            string getImageQuery = "SELECT image FROM Questions WHERE Id = @QuestionId";
                            SqlParameter[] parameters = { new SqlParameter("@QuestionId", Convert.ToInt32(row["Id"])) };
                            string updatedImagePath = connection.ExecuteScalar(getImageQuery, parameters)?.ToString();

                            if (!string.IsNullOrEmpty(updatedImagePath) && File.Exists(updatedImagePath))
                            {
                                pictureBox.Image = Image.FromFile(updatedImagePath);
                                pictureBox.Tag = updatedImagePath;
                            }
                            else
                            {
                                pictureBox.Image = null;
                                pictureBox.Tag = null;
                            }
                        }
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
                        foreach (DataRow answerRow in answers.Rows)
                        {
                            var panelAnswer = new Panel
                            {
                                Dock = DockStyle.Top,
                                Height = 40
                            };

                            var txtAnswer = new TextBox
                            {
                                Text = answerRow["AnswerText"].ToString(),
                                Dock = DockStyle.Left,
                                Width = 600,
                                PlaceholderText = "Answer Text"
                            };
                            panelAnswer.Controls.Add(txtAnswer);

                            var chkCorrect = new CheckBox
                            {
                                Text = "Correct",
                                Dock = DockStyle.Right,
                                AutoSize = true,
                                Checked = (bool)answerRow["IsCorrect"]
                            };
                            panelAnswer.Controls.Add(chkCorrect);

                            questionPanel.Controls.Add(panelAnswer);
                        }
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

        private void EditQuestion(int questionId, string newQuestionText, string questionType, string currentImagePath)
        {
            using (var connection = new Connection())
            {
                try
                {
                    string imagePath = currentImagePath;
                    if (MessageBox.Show("Do you want to change the image?", "Edit Image", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (var openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string newImagePath = Path.Combine(Application.StartupPath, "images", Path.GetFileName(openFileDialog.FileName));
                                File.Copy(openFileDialog.FileName, newImagePath, true);
                                imagePath = newImagePath;
                            }
                        }
                    }

                    string updateQuery = "UPDATE Questions SET QuestionText = @QuestionText, QuestionType = @QuestionType, image = @ImagePath WHERE Id = @QuestionId";
                    SqlParameter[] parameters =
                    {
                new SqlParameter("@QuestionText", newQuestionText),
                new SqlParameter("@QuestionType", questionType),
                new SqlParameter("@ImagePath", (object)imagePath ?? DBNull.Value),
                new SqlParameter("@QuestionId", questionId)
            };
                    connection.ExecuteNonQueryWithParams(updateQuery, parameters);

                    string deleteAnswersQuery = "DELETE FROM Answers WHERE QuestionId = @QuestionId";
                    SqlParameter[] deleteParams = { new SqlParameter("@QuestionId", questionId) };
                    connection.ExecuteNonQueryWithParams(deleteAnswersQuery, deleteParams);

                    var questionPanel = panelQuestions.Controls
                        .OfType<Panel>()
                        .FirstOrDefault(p => p.Controls.OfType<TextBox>().Any(t => t.Text == newQuestionText));

                    if (questionPanel == null)
                    {
                        MessageBox.Show("Failed to find the panel for this question.");
                        return;
                    }

                    foreach (Control answerPanel in questionPanel.Controls.OfType<Panel>())
                    {
                        var txtAnswer = answerPanel.Controls.OfType<TextBox>().FirstOrDefault();
                        var chkCorrect = answerPanel.Controls.OfType<CheckBox>().FirstOrDefault();

                        if (txtAnswer != null && chkCorrect != null)
                        {
                            string answerText = txtAnswer.Text;
                            bool isCorrect = chkCorrect.Checked;

                            string insertAnswerQuery = "INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES (@QuestionId, @AnswerText, @IsCorrect)";
                            SqlParameter[] answerParams =
                            {
                        new SqlParameter("@QuestionId", questionId),
                        new SqlParameter("@AnswerText", answerText),
                        new SqlParameter("@IsCorrect", isCorrect)
                    };
                            connection.ExecuteNonQueryWithParams(insertAnswerQuery, answerParams);
                        }
                    }

                    MessageBox.Show("Question and answers updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the question: " + ex.Message);
                }
            }
        }

        private void DeleteQuestion(int questionId)
        {
            try
            {
                using (var connection = new Connection())
                {
                    string getTopicIdQuery = "SELECT TopicId FROM Questions WHERE Id = @QuestionId";
                    SqlParameter[] getTopicIdParams = { new SqlParameter("@QuestionId", questionId) };
                    object topicIdObj = connection.ExecuteScalar(getTopicIdQuery, getTopicIdParams);

                    if (topicIdObj == null || topicIdObj == DBNull.Value)
                    {
                        MessageBox.Show("Question not found.");
                        return;
                    }

                    int topicId = Convert.ToInt32(topicIdObj);

                    string checkQuizResultsQuery = "SELECT COUNT(*) FROM QuizResults WHERE TopicId = @TopicId";
                    SqlParameter[] checkQuizResultsParams = { new SqlParameter("@TopicId", topicId) };
                    int quizResultsCount = (int)connection.ExecuteScalar(checkQuizResultsQuery, checkQuizResultsParams);

                    if (quizResultsCount > 0)
                    {
                        MessageBox.Show("Cannot delete this question because its topic has been answered by users.");
                        return;
                    }


                    string deleteAnswersQuery = "DELETE FROM Answers WHERE QuestionId = @QuestionId";
                    SqlParameter[] answerParams = { new SqlParameter("@QuestionId", questionId) };
                    connection.ExecuteNonQueryWithParams(deleteAnswersQuery, answerParams);

                    string deleteQuestionQuery = "DELETE FROM Questions WHERE Id = @QuestionId";
                    SqlParameter[] questionParams = { new SqlParameter("@QuestionId", questionId) };
                    connection.ExecuteNonQueryWithParams(deleteQuestionQuery, questionParams);

                    MessageBox.Show("Question and related answers deleted successfully!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the question: " + ex.Message);
            }
        }

    }

}
