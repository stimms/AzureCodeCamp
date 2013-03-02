using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PancakeProwler.Web.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PancakeProwlerUser Contributor { get; set; }

        //TODO: ingredients to be put in table storage

        //TODO: actual steps to make recipe are to be located in table storage

        //TODO: picture to be located in blob storage
    }
}