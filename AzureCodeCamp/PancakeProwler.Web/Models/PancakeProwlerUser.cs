using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PancakeProwler.Web.Models
{
    public class PancakeProwlerUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Twitter { get; set; }
    }
}
