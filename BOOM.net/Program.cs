using BOOM.net.Models;
using Jil;
using System;
using System.Collections.Generic;
using System.IO;

namespace BOOM.net
{
    class Program
    {
        static Root _db;

        static void Main(string[] args)
        {
            LoadDb();

            Console.ReadKey();
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
