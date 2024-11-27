using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Models
{
    public class OpenEndedQuestion : Question
    {
        public string Answer { get; set; }

        public override void DisplayQuestion()
        {
            // Hiển thị câu hỏi mở
        }
    }
}
