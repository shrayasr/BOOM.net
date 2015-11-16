using System.Collections.Generic;

namespace itko.Models
{
    class Root
    {
        public MetadataData Metadata { get; set; }
        public IDictionary<string, BucketData> Data { get; set; }
    }
}
