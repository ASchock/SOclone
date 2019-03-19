using StackOverflow.Models;
using System.Data.Entity.ModelConfiguration;

namespace StackOverflow.DAL
{
    public class EntityBaseEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : EntityBase
    {
        public EntityBaseEntityTypeConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}