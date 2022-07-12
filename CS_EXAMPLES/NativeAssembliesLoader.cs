using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CS_EXAMPLES
{
    public static class NativeAssembliesLoader
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string libname);

        /// <summary>
        /// Loads the required native assemblies for the current architecture (x86 or x64)
        /// </summary>
        /// <param name="rootApplicationPath">
        /// Use Server.MapPath(".") for ASP.NET applications
        /// or
        /// AppDomain.CurrentDomain.BaseDirectory for desktop applications.
        /// </param>
        public static void LoadNativeAssemblies(string rootApplicationPath)
        {
            var nativeBinaryPath = IntPtr.Size > 4
                ? Path.Combine(rootApplicationPath, @"LibraryFolder\x64\")
                : Path.Combine(rootApplicationPath, @"LibraryFolder\x86\");

            LoadNativeAssembly(nativeBinaryPath, "msvcr120.dll");
            LoadNativeAssembly(nativeBinaryPath, "anotherBlaBla.dll");
        }

        private static void LoadNativeAssembly(string nativeBinaryPath, string assemblyName)
        {
            var path = Path.Combine(nativeBinaryPath, assemblyName);
            var ptr = LoadLibrary(path);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception(string.Format(
                    "Error loading {0} (ErrorCode: {1})",
                    assemblyName,
                    Marshal.GetLastWin32Error()));
            }
        }
    }
}