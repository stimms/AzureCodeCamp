using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PancakeProwler.Data.Common.Models
{
    public class Meal
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string SponsorName { get; set; }
        public string SponsorWebSite { get; set; }
        public string SponsorEMail { get; set; }
        public string SponsorTwitter { get; set; }

        [Required]
        public string ContactName { get; set; }

        [EmailAddress]
        public string ContactEMail { get; set; }
        public string ContactPhoneNumber { get; set; }

        [UIHint("Textarea")]
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        [UIHint("FileUpload")]
        public string ImageLocation { get; set; }//link into blob storage

    }
}