using System;
using System.Linq;
using System.Collections.Generic;

namespace PancakeProwler.Data.Common.Models
{
    public class PancakeProwlerUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Twitter { get; set; }
    }
}
