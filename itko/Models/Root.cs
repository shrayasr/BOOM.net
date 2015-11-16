using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOM.net.Models
{
    class Root
    {
        public MetadataData Metadata { get; set; }
        public IDictionary<string, BucketData> Data { get; set; }
    }
}
