using System;
using System.IO;

namespace itko
{
    static class Settings
    {
        private static string DB_FILENAME = "_itko.json";
        public static string DB_LOCATION
        {
            get
            {
                return Path.Combine(
                    Environment.GetEnvironmentVariable("HOMEDRIVE"),
                    Environment.GetEnvironmentVariable("HOMEPATH"),
                    DB_FILENAME
                );
            }
        }
    }
}
