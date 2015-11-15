using BOOM.net.Models;
using Jil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOM.net
{
    class Program
    {
        static void Main(string[] args)
        {
            var metadata = new MetadataData { Buckets = new List<string> { "foo" } };
            var fooData = new BucketData
            {
                Keys = new List<string> { "k1", "k2" },
                Values = new Dictionary<string, string>
                {
                    { "k1", "v1" },
                    { "k2", "v2" }
                }
            };

            var root = new Root
            {
                Metadata = metadata,
                Data = new Dictionary<string, BucketData>
                {
                    { "foo", fooData }
                }
            };

            var op = JSON.Serialize(root);

            Console.WriteLine(op);
            Console.ReadKey();
        }
    }
}
