using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PancakeProwler.Data.Common.Models
{
    public class Meal
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Sponsor Name")]
        public string SponsorName { get; set; }

        [Display(Name="Sponsor Website")]
        public string SponsorWebSite { get; set; }

        [EmailAddress]
        [Display(Name="Sponsor EMail")]
        public string SponsorEMail { get; set; }

        [Display(Name="Sponsor Twitter")]
        public string SponsorTwitter { get; set; }

        [Required]
        [Display(Name="Contact Name") ]
        public string ContactName { get; set; }

        [EmailAddress]
        [Display(Name="Contact EMail")]
        public string ContactEMail { get; set; }
        [Phone]
        [Display(Name="Contact Phone Number")]
        public string ContactPhoneNumber { get; set; }

        [UIHint("Textarea")]
        public string Address { get; set; }

        [UIHint("Hidden")]
        public decimal Latitude { get; set; }

        [UIHint("Hidden")]
        public decimal Longitude { get; set; }

        public DateTime Date { get; set; }

        [UIHint("Textarea")]
        public string Description { get; set; }

        [UIHint("FileUpload")]
        public string ImageLocation { get; set; }//link into blob storage

    }
}