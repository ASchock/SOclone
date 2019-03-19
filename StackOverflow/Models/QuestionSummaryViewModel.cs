using System;

namespace StackOverflow.Models
{
    public class QuestionSummaryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public DateTime Asked { get; set; }
        public int ViewCount { get; set; }
        public int AnswerCount { get; set; }
        public int VoteCount { get; set; }
    }
}