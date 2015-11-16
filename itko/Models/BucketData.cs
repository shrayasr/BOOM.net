using System.Collections.Generic;

namespace itko.Models
{
    class BucketData
    {
        public List<string> Keys { get; set; }
        public IDictionary<string, string> Values { get; set; }
    }
}