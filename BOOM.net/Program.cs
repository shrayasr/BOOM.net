using BOOM.net.Models;
using Jil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BOOM.net
{
    class Program
    {
        static Root _db;

        static void Main(string[] args)
        {
            LoadDb();
            ParseAndGo(args);
        }

        private static void ParseAndGo(IEnumerable<string> argsToProcess)
        {
            var args = argsToProcess.Select(arg => arg.ToLower()).ToList();

            if (args.Count == 0)
            {
                PrintBucketsAndCounts();
                return;
            }

            var cmd = args[0];

            if (cmd == "all")
                Console.WriteLine("All buckets and their entries");

            else if (cmd == "delete")
                Console.WriteLine("delete buckets");
        }

        private static void PrintBucketsAndCounts()
        {
            if (_db.Metadata.Buckets.Count == 0)
                Console.WriteLine("No buckets");

            else
            {
                _db.Metadata.Buckets.ForEach(bucket =>
                {
                    var keyCount = _db.Data[bucket].Keys.Count;
                    Console.WriteLine("{0} ({1})", bucket, keyCount);
                });
            }
        }

        private static Root GetStarterTemplate()
        {
            var metadata = new MetadataData { Buckets = new List<string>() };

            var root = new Root
            {
                Metadata = metadata,
                Data = new Dictionary<string, BucketData>()
            };

            return root;
        }

        private static void LoadDb()
        {
            if (!File.Exists(Settings.DB_LOCATION))
            {
                var starterTemplate = GetStarterTemplate();
                File.WriteAllText(Settings.DB_LOCATION, JSON.Serialize(starterTemplate));
            }

            _db = JSON.Deserialize<Root>(File.ReadAllText(Settings.DB_LOCATION));
        }
    }
}
