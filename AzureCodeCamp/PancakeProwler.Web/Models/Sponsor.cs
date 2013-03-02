using System;
using System.Linq;
using System.Collections.Generic;

namespace PancakeProwler.Web.Models
{
    public class Sponsor
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string WebSite { get; set; }
        public string EMail { get; set; }
        public string Twitter { get; set; }

    }
}
