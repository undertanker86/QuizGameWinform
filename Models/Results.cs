using System;

namespace QuizGame.Models
{
    public class Result
    {
        public int ResultsId { get; set; } // ID của kết quả
        public int UserId { get; set; } // ID của người dùng
        public int Score { get; set; } // Điểm số
        public DateTime DateTaken { get; set; } // Ngày giờ thực hiện quiz
        public int TopicId { get; set; } // ID của chủ đề

        public Result(int userId, int score, DateTime dateTaken, int topicId)
        {
            UserId = userId;
            Score = score;
            DateTaken = dateTaken;
            TopicId = topicId;
        }

        public Result() { } // Constructor mặc định
    }
}
