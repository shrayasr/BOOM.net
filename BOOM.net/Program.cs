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
                printBucketsAndEntries();

            else if (cmd == "delete")
            {
                if (args.Count == 2)
                {
                    var bucket = args[1];
                    DeleteBucket(bucket);
                }

                else if (args.Count == 3)
                {
                    var bucket = args[1];
                    var key = args[2];
                    DeleteKeyInBucket(bucket, key);
                }
            }

            else
            {
                var bucket = cmd;

                if (args.Count == 1)
                    CreateOrListBucket(bucket);

                else if (args.Count == 2)
                {
                    var key = args[1];
                    PrintValueForKey(bucket, key);
                }

                else if (args.Count == 3)
                {
                    var key = args[1];
                    var val = args[2];
                    StoreValueInKey(bucket, key, val);
                }
            }
        }

        private static void DeleteKeyInBucket(string bucket, string key)
        {
            if (!_db.Metadata.Buckets.Contains(bucket))
            {
                Console.WriteLine("Bucket doesn't exist");
                return;
            }

            if (!_db.Data[bucket].Keys.Contains(key))
            {
                Console.WriteLine("Key doesn't exist");
                return;
            }

            _db.Data[bucket].Values.Remove(key);
            _db.Data[bucket].Keys.Remove(key);

            WriteDb();
        }

        private static void DeleteBucket(string bucket)
        {
            if (!_db.Metadata.Buckets.Contains(bucket))
            {
                Console.WriteLine("Bucket doesn't exist");
                return;
            }

            _db.Data.Remove(bucket);
            _db.Metadata.Buckets.Remove(bucket);

            WriteDb(); 
        }

        private static void StoreValueInKey(string bucket, string key, string val)
        {
            if (!_db.Metadata.Buckets.Contains(bucket))
            {
                Console.WriteLine("Bucket doesn't exist");
                return;
            }

            _db.Data[bucket].Values[key] = val;

            if (!_db.Data[bucket].Keys.Contains(key))
                _db.Data[bucket].Keys.Add(key);

            WriteDb();
        }

        private static void PrintValueForKey(string bucket, string key)
        {
            if (!_db.Metadata.Buckets.Contains(bucket))
            {
                Console.WriteLine("Bucket doesn't exist");
                return;
            }

            if (!_db.Data[bucket].Keys.Contains(key))
            {
                Console.WriteLine("Key doesn't exist");
                return;
            }

            Console.WriteLine(_db.Data[bucket].Values[key]);
        }

        private static void CreateOrListBucket(string bucket)
        {
            if (_db.Metadata.Buckets.Contains(bucket))
            {
                Console.WriteLine(bucket);
                _db.Data[bucket].Keys.ForEach(key => 
                    Console.WriteLine("  {0}\t{1}", key, _db.Data[bucket].Values[key])
                );
            }

            else
            {
                _db.Metadata.Buckets.Add(bucket);
                _db.Data.Add(bucket, new BucketData
                {
                    Keys = new List<string>(),
                    Values = new Dictionary<string, string>()
                });

                WriteDb();
            }
        }

        private static void printBucketsAndEntries()
        {
            if (_db.Metadata.Buckets.Count == 0)
                Console.WriteLine("No buckets");

            else
            {
                _db.Metadata.Buckets.ForEach(bucket =>
                {
                    Console.WriteLine(bucket);
                    _db.Data[bucket].Keys.ForEach(key =>
                        Console.WriteLine("  {0}\t{1}", key, _db.Data[bucket].Values[key])
                    );
                });
            }
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

        private static void WriteDb()
        {
            File.WriteAllText(Settings.DB_LOCATION, JSON.Serialize(_db));
        }
    }
}
