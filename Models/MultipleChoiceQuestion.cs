using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Models
{
    public class MultipleChoiceQuestion : Question
    {
        public string[] Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public override void DisplayQuestion()
        {
            // Hiển thị câu hỏi nhiều lựa chọn
        }
    }

}
