using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PancakeProwler.Search
{
    public class SendToSearchItem
    {
        [JsonProperty(PropertyName = "@search.action")]
        public string Action { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string ingredients { get; set; }
        public string steps { get; set; }
    }
}
