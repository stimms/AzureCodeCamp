using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PancakeProwler.Data.Common.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SponsorName { get; set; }
        public string SponsorWebSite { get; set; }
        public string SponsorEMail { get; set; }
        public string SponsorTwitter { get; set; }

        public string ContactName { get; set; }
        public string ContactEMail { get; set; }
        public string ContactPhoneNumber { get; set; }

        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageLocation { get; set; }//link into blob storage

    }
}