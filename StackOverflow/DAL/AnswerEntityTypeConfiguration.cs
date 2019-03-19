using StackOverflow.Models;

namespace StackOverflow.DAL
{
    public class AnswerEntityTypeConfiguration : EntityBaseEntityTypeConfiguration<Answer>
    {
        public AnswerEntityTypeConfiguration()
        {
            Property(x => x.Text).IsRequired();
            Property(x => x.Answered).IsRequired();
        }
    }
}