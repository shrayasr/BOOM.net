using System;
using System.IO;

using System.Runtime.InteropServices;

namespace itko
{
    static class Settings
    {
        private static string DB_FILENAME = "_itko.json";
        public static string DB_LOCATION
        {
            get
            {
                var homeDir = "";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    homeDir = Path.Combine(
                        Environment.GetEnvironmentVariable("HOMEDRIVE"),
                        Environment.GetEnvironmentVariable("HOMEPATH")
                    );
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    homeDir = Environment.GetEnvironmentVariable("HOME");
                else
                     throw new PlatformNotSupportedException();

                return Path.Combine(
                    homeDir,
                    DB_FILENAME
                );
            }
        }
    }
}
