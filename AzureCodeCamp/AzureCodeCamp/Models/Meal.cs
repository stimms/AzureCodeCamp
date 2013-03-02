using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureCodeCamp.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Sponsor Sponsor {get;set;}

        public virtual ContactInformaiton ContactInformation { get; set; }

        public string Address { get; set; }
    }
}