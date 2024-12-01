using System.Data;
using System.Data.SqlClient;
using QuizGame.Models.Connection;
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
        private string SaveImage(PictureBox pictureBox)
        {
            if (pictureBox != null && pictureBox.Image != null && pictureBox.Tag != null)
            {
                string originalImagePath = pictureBox.Tag.ToString();
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(originalImagePath);
                string newImagePath = Path.Combine(Application.StartupPath, "images", newFileName);
                File.Copy(originalImagePath, newImagePath, true);
                return newImagePath;
            }
            return null;
        }

        private void SaveAnswers(Panel panel, int questionId, string questionType, Connection connection)
        {
            switch (questionType)
            {
                case "Multiple Choice":
                    var answerPanels = panel.Controls.OfType<Panel>().ToList();

                    foreach (var answerPanel in answerPanels)
                    {
                        var txtAnswer = answerPanel.Controls.OfType<TextBox>().FirstOrDefault();
                        var btnCorrect = answerPanel.Controls.OfType<RadioButton>().FirstOrDefault();

                        if (txtAnswer != null && btnCorrect != null)
                        {
                            string answerText = txtAnswer.Text;
                            bool isCorrect = btnCorrect.Checked;

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
                    var txtOpenEndedAnswer = panel.Controls.OfType<TextBox>().Skip(1).FirstOrDefault();
                    if (txtOpenEndedAnswer != null)
                    {
                        string openEndedAnswer = txtOpenEndedAnswer.Text;
                        string openEndedInsertQuery = "INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES (@QuestionId, @AnswerText, @IsCorrect)";
                        SqlParameter[] openEndedParams = new SqlParameter[]
                        {
                            new SqlParameter("@QuestionId", questionId),
                            new SqlParameter("@AnswerText", openEndedAnswer),
                            new SqlParameter("@IsCorrect", true)
                        };
                        connection.ExecuteNonQueryWithParams(openEndedInsertQuery, openEndedParams);
                    }
                    break;

                case "True/False":
                    //var trueFalseComboBox = panel.Controls.OfType<ComboBox>().Skip(1).FirstOrDefault();
                    //if (trueFalseComboBox != null && trueFalseComboBox.SelectedItem != null)
                    //{
                    //    string trueFalseAnswer = trueFalseComboBox.SelectedItem.ToString();
                    //    string trueFalseInsertQuery = "INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES (@QuestionId, @AnswerText, @IsCorrect)";
                    //    SqlParameter[] trueFalseParams = new SqlParameter[]
                    //    {
                    //        new SqlParameter("@QuestionId", questionId),
                    //        new SqlParameter("@AnswerText", trueFalseAnswer),
                    //        new SqlParameter("@IsCorrect", trueFalseAnswer == "True")
                    //    };
                    //    connection.ExecuteNonQueryWithParams(trueFalseInsertQuery, trueFalseParams);
                    //}
                    //break;
                    var trueFalseComboBox = panel.Controls.OfType<ComboBox>().Skip(1).FirstOrDefault();
                    if (trueFalseComboBox != null && trueFalseComboBox.SelectedItem != null)
                    {
                        string trueFalseAnswer = trueFalseComboBox.SelectedItem.ToString();

                        // Nếu đáp án là "True" hoặc "False", ta xác định đáp án đúng bằng cách so sánh với lựa chọn người dùng
                        //bool isCorrect = trueFalseAnswer == "True" ? true : false;  // Nếu "True" là đáp án đúng thì IsCorrect = 1
                        int isCorrect = 1;  // Nếu "True" là đáp án đúng thì IsCorrect = 1

                        string trueFalseInsertQuery = "INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES (@QuestionId, @AnswerText, @IsCorrect)";
                        SqlParameter[] trueFalseParams = new SqlParameter[]
                        {
                            new SqlParameter("@QuestionId", questionId),
                            new SqlParameter("@AnswerText", trueFalseAnswer),
                            new SqlParameter("@IsCorrect", isCorrect)  // Gán 1 nếu đúng, 0 nếu sai
                        };
                        connection.ExecuteNonQueryWithParams(trueFalseInsertQuery, trueFalseParams);
                    }
                    break;
            }
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
                MessageBox.Show("Error for load topic: " + ex.Message);
            }
        }

        private Panel CreateQuestionPanel(int questionNumber)
        {
            var questionPanel = new Panel
            {
                Size = new Size(900, 300),
                Dock = DockStyle.Top,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            var txtQuestion = new TextBox
            {
                PlaceholderText = $"Enter Question {questionNumber}",
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
            comboBoxQuestionType.SelectedIndex = 0;
            questionPanel.Controls.Add(comboBoxQuestionType);

            var pictureBox = new PictureBox
            {
                Size = new Size(150, 150),
                Dock = DockStyle.Left,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            questionPanel.Controls.Add(pictureBox);

            var btnUploadImage = new Button
            {
                Text = "Upload Image",
                Dock = DockStyle.Left,
                Height = 30
            };
            btnUploadImage.Click += (s, args) =>
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                        pictureBox.Tag = openFileDialog.FileName;
                    }
                }
            };
            questionPanel.Controls.Add(btnUploadImage);

            comboBoxQuestionType.SelectedIndexChanged += (s, args) =>
            {
                questionPanel.Controls.Clear();
                questionPanel.Controls.Add(txtQuestion);
                questionPanel.Controls.Add(comboBoxQuestionType);
                questionPanel.Controls.Add(pictureBox);
                questionPanel.Controls.Add(btnUploadImage);

                switch (comboBoxQuestionType.SelectedItem.ToString())
                {
                    case "Multiple Choice":
                        for (int j = 0; j < 4; j++)
                        {
                            var panelAnswer = new Panel
                            {
                                Dock = DockStyle.Top,
                                Height = 40
                            };

                            var txtAnswer = new TextBox
                            {
                                PlaceholderText = $"Answer {j + 1}",
                                Dock = DockStyle.Left,
                                Width = 600
                            };
                            panelAnswer.Controls.Add(txtAnswer);

                            var btnCorrect = new RadioButton
                            {
                                Text = "Correct",
                                Dock = DockStyle.Right,
                                AutoSize = true
                            };
                            panelAnswer.Controls.Add(btnCorrect);

                            questionPanel.Controls.Add(panelAnswer);
                        }
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

            return questionPanel;
        }


        private void btnCreateQuiz_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoluong.Text, out int questionCount))
            {
                panelQuestions.Controls.Clear();

                for (int i = 0; i < questionCount; i++)
                {
                    var questionPanel = CreateQuestionPanel(i + 1);
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

            DialogResult result = MessageBox.Show("Are you sure you want to save this quiz?", "Confirm Save", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            string imagesFolderPath = Path.Combine(Application.StartupPath, "images");
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
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
                            var txtQuestion = panel.Controls.OfType<TextBox>().FirstOrDefault();
                            var comboBoxQuestionType = panel.Controls.OfType<ComboBox>().FirstOrDefault();
                            var pictureBox = panel.Controls.OfType<PictureBox>().FirstOrDefault();

                            if (txtQuestion == null || comboBoxQuestionType == null || comboBoxQuestionType.SelectedItem == null)
                            {
                                MessageBox.Show("Missing question text or type.");
                                continue;
                            }

                            string questionText = txtQuestion.Text;
                            string questionType = comboBoxQuestionType.SelectedItem.ToString();
                            string imagePath = SaveImage(pictureBox);

                            string questionInsertQuery = "INSERT INTO Questions (TopicId, QuestionText, QuestionType, image) OUTPUT INSERTED.Id VALUES (@TopicId, @QuestionText, @QuestionType, @ImagePath)";
                            SqlParameter[] questionParams = new SqlParameter[]
                            {
                                new SqlParameter("@TopicId", selectedTopicId),
                                new SqlParameter("@QuestionText", questionText),
                                new SqlParameter("@QuestionType", questionType),
                                new SqlParameter("@ImagePath", (object)imagePath ?? DBNull.Value)
                            };

                            int questionId = (int)connection.ExecuteScalar(questionInsertQuery, questionParams);

                            // Lưu câu trả lời theo loại
                            SaveAnswers(panel, questionId, questionType, connection);
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
