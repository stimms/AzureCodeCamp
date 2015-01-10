using System;
using System.Linq;
using System.Collections.Generic;

namespace PancakeProwler.Search
{
    public class SendToSearchEnvelope
    {
        public List<SendToSearchItem> value { get; set; }

        public SendToSearchEnvelope()
        {
            value = new List<SendToSearchItem>();
        }
    }
}
