using System.Collections.Generic;

namespace BOOM.net.Models
{
    class BucketData
    {
        public List<string> Keys { get; set; }
        public IDictionary<string, string> Values { get; set; }
    }
}