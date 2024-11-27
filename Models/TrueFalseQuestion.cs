using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Models
{
    public class TrueFalseQuestion : Question
    {
        public bool Answer { get; set; }

        public override void DisplayQuestion()
        {
            // Hiển thị câu hỏi đúng/sai
        }
    }
}
