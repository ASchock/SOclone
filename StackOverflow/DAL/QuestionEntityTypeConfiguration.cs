using StackOverflow.Models;

namespace StackOverflow.DAL
{
    public class QuestionEntityTypeConfiguration : EntityBaseEntityTypeConfiguration<Question>
    {
        public QuestionEntityTypeConfiguration()
        {
            Property(x => x.Title).IsRequired();
            Property(x => x.Text).IsRequired();
            Property(x => x.Asked).IsRequired();
            Property(x => x.VoteCount).IsRequired();
            Property(x => x.ViewCount).IsRequired();
            HasMany(x => x.Answers).WithRequired();
            HasRequired(x => x.Category).WithMany(x => x.Questions);
        }
    }
}