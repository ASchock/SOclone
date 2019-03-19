using System;

namespace StackOverflow.Models
{
    public class Answer : EntityBase
    {
        public Answer()
        {
            Answered = DateTime.Now;
        }
        public Answer(string text) : this()
        {
            Text = text;
        }

        public string Text { get; set; }
        public DateTime Answered { get; set; }
    }
}