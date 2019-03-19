using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverflow.Models
{
    public class CreateQuestionViewModel
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public string Title { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        [Required]
        public int SelectedCategory { get; set; }
    }
}