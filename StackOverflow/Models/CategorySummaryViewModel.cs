using System.Collections.Generic;

namespace StackOverflow.Models
{
    public class CategorySummaryViewModel
    {
        public string Name { get; set; }
        public IEnumerable<QuestionSummaryViewModel> Questions { get; set; }
    }
}