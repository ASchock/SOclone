using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Models
{
    public class Category : EntityBase
    {
        public Category()
        {
            Questions = new List<Question>();
        }

        public Category(string name) : this()
        {
            Name = name;
        }

        [Required]
        public string Name { get; set; }
        public virtual IList<Question> Questions { get; protected set; }
    }
}