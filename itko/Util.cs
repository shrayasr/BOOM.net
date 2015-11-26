#if DNXCORE50
using System.Runtime.InteropServices;
#endif

namespace itko
{
    class Util
    {
        public static bool IsWindows()
        {
            #if DNXCORE50
              return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            #else
              // This happens if I am on .NET framework, so it can run only on
              // windows. Hence always return true.
              // TODO add MONO support
              return true; 
            #endif
        }

        public static bool IsLinux()
        {
            #if DNXCORE50
              return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            #else
              // This happens if I am on .NET framework, so it can run only on
              // windows. Hence always return false.
              // TODO add MONO support
              return false;
            #endif
        }
    }
}
