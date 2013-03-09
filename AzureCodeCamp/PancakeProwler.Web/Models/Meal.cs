using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PancakeProwler.Web.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Sponsor Sponsor {get;set;}

        public virtual ContactInformaiton ContactInformation { get; set; }

        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageLocation { get; set; }//link into blob storage

    }
}