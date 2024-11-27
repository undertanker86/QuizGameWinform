using System;
using System.Collections.Generic;

namespace QuizGame.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name; // Sử dụng để hiển thị tên trong ComboBox
        }
    }

}
