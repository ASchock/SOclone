using System;
using System.Collections.Generic;

namespace StackOverflow.Models
{
    public class Question : EntityBase
    {
        protected Question()
        {
            Asked = DateTime.Now;
            Answers = new List<Answer>();
        }

        public Question(string title, string text, Category category) : this()
        {
            Title = title;
            Text = text;
            Category = category;
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public virtual Category Category { get; set; }
        public DateTime Asked { get; protected set; }
        public int ViewCount { get; set; }
        public int VoteCount { get; set; }

        public virtual IList<Answer> Answers { get; protected set; }
    }
}