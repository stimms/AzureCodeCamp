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
        public string Name { get; set; }
        public String Contributor { get; set; }

        public IEnumerable<string> Ingredients { get; set; }

        public IEnumerable<string> Steps { get; set; }

        public string ImageLocation { get; set; }
    }
}