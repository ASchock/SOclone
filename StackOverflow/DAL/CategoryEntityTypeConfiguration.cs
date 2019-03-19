using StackOverflow.Models;

namespace StackOverflow.DAL
{
    public class CategoryEntityTypeConfiguration : EntityBaseEntityTypeConfiguration<Category>
    {
        public CategoryEntityTypeConfiguration()
        {
            Property(x => x.Name).IsRequired();
            HasMany(x => x.Questions).WithRequired(x => x.Category);
        }
    }
}