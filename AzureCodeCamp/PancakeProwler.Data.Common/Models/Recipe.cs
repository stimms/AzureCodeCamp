using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PancakeProwler.Data.Common.Models
{
    public class Recipe
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name="Recipe Name")]
        public string Name { get; set; }

        [Display(Name="Your Name")]
        public String Contributor { get; set; }

        public IEnumerable<string> Ingredients { get; set; }

        public IEnumerable<string> Steps { get; set; }

        [UIHint("FileUpload")]
        [Display(Name="Upload a picture of your creation")]
        public string ImageLocation { get; set; }
    }
}