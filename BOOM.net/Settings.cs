using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOM.net
{
    static class Settings
    {
        private static string DB_FILENAME = "_boom.json";
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
