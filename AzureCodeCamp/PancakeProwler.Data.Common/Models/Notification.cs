using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PancakeProwler.Data.Common.Models
{
    public class Notification
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}