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
                var homeDir = "";
                if (Util.IsWindows())
                    homeDir = Path.Combine(
                        Environment.GetEnvironmentVariable("HOMEDRIVE"),
                        Environment.GetEnvironmentVariable("HOMEPATH")
                    );
                else if (Util.IsLinux())
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
