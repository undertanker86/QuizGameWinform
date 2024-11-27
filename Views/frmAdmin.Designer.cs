namespace QuizGame.Views
{
    partial class frmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            txtHello = new Label();
            chartTopicsMax = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dataGridViewResult = new DataGridView();
            panel1 = new Panel();
            button5 = new Button();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            lblRank = new Label();
            RANK = new Label();
            ((System.ComponentModel.ISupportInitialize)chartTopicsMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtHello
            // 
            txtHello.AutoSize = true;
            txtHello.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtHello.Location = new Point(17, 331);
            txtHello.Margin = new Padding(4, 0, 4, 0);
            txtHello.Name = "txtHello";
            txtHello.Size = new Size(90, 35);
            txtHello.TabIndex = 1;
            txtHello.Text = "label1";
            // 
            // chartTopicsMax
            // 
            chartArea1.Name = "ChartArea1";
            chartTopicsMax.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartTopicsMax.Legends.Add(legend1);
            chartTopicsMax.Location = new Point(1344, 5);
            chartTopicsMax.Margin = new Padding(4, 5, 4, 5);
            chartTopicsMax.Name = "chartTopicsMax";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartTopicsMax.Series.Add(series1);
            chartTopicsMax.Size = new Size(546, 521);
            chartTopicsMax.TabIndex = 5;
            chartTopicsMax.Text = "chart1";
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Location = new Point(1344, 646);
            dataGridViewResult.Margin = new Padding(4, 5, 4, 5);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.RowHeadersWidth = 62;
            dataGridViewResult.Size = new Size(546, 237);
            dataGridViewResult.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(button5);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txtHello);
            panel1.Location = new Point(0, 5);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(412, 1326);
            panel1.TabIndex = 7;
            // 
            // button5
            // 
            button5.BackColor = Color.NavajoWhite;
            button5.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            button5.Location = new Point(4, 571);
            button5.Margin = new Padding(4, 5, 4, 5);
            button5.Name = "button5";
            button5.Size = new Size(404, 83);
            button5.TabIndex = 10;
            button5.Text = "Quiz Edit";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(17, 15);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(274, 287);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.NavajoWhite;
            button4.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            button4.Location = new Point(4, 762);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(404, 77);
            button4.TabIndex = 8;
            button4.Text = "Logout";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.NavajoWhite;
            button3.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            button3.Location = new Point(4, 664);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(404, 88);
            button3.TabIndex = 7;
            button3.Text = "User Management";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.NavajoWhite;
            button2.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            button2.Location = new Point(4, 476);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(404, 85);
            button2.TabIndex = 6;
            button2.Text = "Quiz Create";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.NavajoWhite;
            button1.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(4, 383);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(404, 83);
            button1.TabIndex = 5;
            button1.Text = "Topic Management";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1344, 576);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 24);
            label1.TabIndex = 8;
            label1.Text = "User list:";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblRank);
            panel2.Controls.Add(RANK);
            panel2.Location = new Point(464, 5);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(818, 1151);
            panel2.TabIndex = 9;
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.Font = new Font("Sitka Small", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRank.Location = new Point(284, 137);
            lblRank.Margin = new Padding(4, 0, 4, 0);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(152, 48);
            lblRank.TabIndex = 1;
            lblRank.Text = "lblRank";
            // 
            // RANK
            // 
            RANK.AutoSize = true;
            RANK.Font = new Font("Sitka Small", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RANK.Location = new Point(272, 26);
            RANK.Margin = new Padding(4, 0, 4, 0);
            RANK.Name = "RANK";
            RANK.Size = new Size(164, 65);
            RANK.TabIndex = 0;
            RANK.Text = "RANK";
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1898, 1160);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(dataGridViewResult);
            Controls.Add(chartTopicsMax);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUIZGAME";
            ((System.ComponentModel.ISupportInitialize)chartTopicsMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label txtHello;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopicsMax;
        private DataGridView dataGridViewResult;
        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button4;
        private Label label1;
        private Panel panel2;
        private Label RANK;
        private Label lblRank;
        private Button button5;
    }
}